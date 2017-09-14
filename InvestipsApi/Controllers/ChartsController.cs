using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investips.Core;
using Investips.Core.Models;
using InvestipsApi.Controllers.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetChart(int id)
        {
            var chart = await _chartRepository.GetChart(id);
            if (chart == null)
            {
                return NotFound();
            }

            var chartResource =_mapper.Map<Chart, ChartResource>(chart);
            return Ok(chartResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChart([FromBody] ChartResource chartResource)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var chart = _mapper.Map<ChartResource, Chart>(chartResource);
                chart.LastUpdate = DateTime.Now;

                _chartRepository.Add(chart);
                await _uow.CompleteAsync();

                chart = await _chartRepository.GetChart(chart.Id);
                var result = _mapper.Map<Chart, ChartResource>(chart);
                return Ok(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            
        }
    }
}