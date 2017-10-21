using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Investips.Core;
using Investips.Core.Models;
using InvestipsApi.Controllers.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Investips.Core.Extensions;
using InvestipsApi.Helpers;

namespace InvestipsApi.Controllers
{
    [Route("/api/Charts")]
    public class ChartsController : Controller
    {
        //Add Mapper 
        private readonly IMapper _mapper;
        private readonly IChartRepository _chartRepository;
        private readonly IUnitOfWork _uow;

        private readonly String _flagger = "optional";

        public ChartsController(IMapper mapper, IChartRepository chartRepository, IUnitOfWork uow)
        {
            _mapper = mapper;
            _chartRepository = chartRepository;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharts(string client, string user, int chart)
        {

            if (chart > 0)
            {
                var chartObject = await _chartRepository.GetChart(chart);
                if (chartObject == null)
                {
                    return NotFound();
                }

                var chartResource = _mapper.Map<Chart, ChartResource>(chartObject);
                var data = new
                {
                    status = "ok",
                    data = new
                    {
                        content = System.Net.WebUtility.UrlDecode(chartResource.Content),
                        name = chartResource.Name,
                        id = chartResource.Id
                    }
                };

                return Json(data);
            }
            else
            {
                var charts = await _chartRepository.GetCharts();
                var result = _mapper.Map<List<Chart>, List<ChartResource>>(charts);

                var dataContent = result.Select(x => new
                {
                    timestamp = 1505119125.0,
                    symbol = x.Symbol,
                    resolution = "D",
                    id = x.Id,
                    name = x.Name
                });
                var data = new {status = "ok", data = dataContent};

                return Json(data);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChart(int chart)
        {
            var chartObject = await _chartRepository.GetChart(chart);
            if (chartObject == null)
            {
                return NotFound();
            }

            var chartResource =_mapper.Map<Chart, ChartResource>(chartObject);
            return Ok(chartResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChart()
        {
            try
            {
                int chart = 0;
                IQueryCollection queryStrings;
                var bodyStr = GetBodyStr(out queryStrings);
                chart = QueryStringHelper.GetChartId(queryStrings);

                if (!string.IsNullOrEmpty(bodyStr))
                {
                    var chartResource = QueryStringHelper.GetChartResource(bodyStr);
                    if (chart > 0)
                    {
                        var chartE = await _chartRepository.GetChart(chart);

                        if (chartE == null)
                        {
                            return NotFound();
                        }

                        _mapper.Map<ChartResource, Chart>(chartResource, chartE);
                        await _uow.CompleteAsync();
                        chartE = await _chartRepository.GetChart(chartE.Id);
                        var dataUpdate = new {status = "ok", id = chartE.Id};

                        return Json(dataUpdate);
                    }
                    else
                    {
                        var chartEntity = _mapper.Map<ChartResource, Chart>(chartResource);
                        chartEntity.LastUpdate = DateTime.Now;

                        _chartRepository.Add(chartEntity);
                        await _uow.CompleteAsync();

                        chartEntity = await _chartRepository.GetChart(chartEntity.Id);
                        var result = _mapper.Map<Chart, ChartResource>(chartEntity);

                        var dataCreate = new {status = "ok", id = result.Id};

                        return Json(dataCreate);
                    }
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }

        }

        private string GetBodyStr(out IQueryCollection queryStrings)
        {
            string bodyStr;
            var req = HttpContext.Request;
            queryStrings = Request.Query;
            req.EnableRewind();

            using (StreamReader reader
                = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }

            req.Body.Position = 0;
            return bodyStr;
        }
    }
}
