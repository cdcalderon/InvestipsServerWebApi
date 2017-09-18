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

namespace InvestipsApi.Controllers
{
   // [Produces("application/json")]
    [Route("/api/Charts")]
    public class ChartsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IChartRepository _chartRepository;
        private readonly IUnitOfWork _uow;

        public ChartsController(IMapper mapper, IChartRepository chartRepository, IUnitOfWork uow)
        {
            _mapper = mapper;
            _chartRepository = chartRepository;
            _uow = uow;
        }


        [HttpGet]
        public async Task<IActionResult> GetCharts(string client, string user, int chart) {

            if(chart > 0) {
                var chartObject = await _chartRepository.GetChart(chart);
            if (chartObject == null)
            {
                return NotFound();
            }

            var chartResource =_mapper.Map<Chart, ChartResource>(chartObject);

            System.Net.WebUtility.UrlDecode("");

            var data = new { status = "ok", data = new {
                content = System.Net.WebUtility.UrlDecode(chartResource.Content),
                name = chartResource.Name,
                id = chartResource.Id
            }};

            return Json(data);

            //return Ok(chartResource);

            } else {
            var charts = await _chartRepository.GetCharts();
            var result = _mapper.Map<List<Chart>, List<ChartResource>>(charts);

            var dataContent = result.Select(x => new {
                timestamp = 1505119125.0,
            symbol = x.Symbol,
            resolution= "D",
            id= x.Id,
            name = x.Name
            });
            var data = new { status = "ok", data = dataContent };

             return Json(data);
            }
            

        // var dataContent = new List<object>() {new {
        //     timestamp = 1505119125.0,
        //     symbol = "AAPL",
        //     resolution= "D",
        //     id= 66535,
        //     name = "AAPL Fib Extension"
        // }};
        // var data = new { status = "ok", data = dataContent };

        // return Json(data);

            //return Ok(res);
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
                string chartStr = "";
                var bodyStr = "";
                var req = HttpContext.Request;
                var queryStrings = Request.Query;
                 var qsList = new List<string>();

                foreach(var key in queryStrings.Keys)
                {
                    if(key == "chart"){
                        chart = Int32.Parse(queryStrings[key]);
                    }
                    qsList.Add(queryStrings[key]);
                }

                // Allows using several time the stream in ASP.Net Core
                req.EnableRewind();

                // Arguments: Stream, Encoding, detect encoding, buffer size 
                // AND, the most important: keep stream opened
                using (StreamReader reader
                    = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = reader.ReadToEnd();
                }

                // Rewind, so the core is not lost when it looks the body for the request
                req.Body.Position = 0;


                if(!string.IsNullOrEmpty(bodyStr)){
                    var dic = bodyStr.Split('&').Select(x => x.Split('=')).Select(t =>
                    new {
                        Prop = t[0],
                        Value = t[1]
                    }).ToDictionary(x => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Prop.ToLower()), x => x.Value);

                var chartResource = dic.DictionaryToObject<ChartResource>();
                // if (!ModelState.IsValid)
                // {
                //     return BadRequest(ModelState);
                // }

                if(chart > 0) {
                    var chartE = await _chartRepository.GetChart(chart);

                    if(chartE == null) {
                        return NotFound();
                    }

                        _mapper.Map<ChartResource, Chart>(chartResource, chartE);
                       await _uow.CompleteAsync();
                       chartE = await _chartRepository.GetChart(chartE.Id);
                       var dataUpdate = new { status = "ok", id = chartE.Id };

                       return Json(dataUpdate);
                } else {
                var chartEntity = _mapper.Map<ChartResource, Chart>(chartResource);
                chartEntity.LastUpdate = DateTime.Now;

                _chartRepository.Add(chartEntity);
                await _uow.CompleteAsync();

                chartEntity = await _chartRepository.GetChart(chartEntity.Id);
                var result = _mapper.Map<Chart, ChartResource>(chartEntity);

                var dataCreate = new { status = "ok", id = result.Id };

                return Json(dataCreate);        
                }

                }

                return BadRequest();
                

                //{"status": "ok", "id": 67977}
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            
        }
    }
}
