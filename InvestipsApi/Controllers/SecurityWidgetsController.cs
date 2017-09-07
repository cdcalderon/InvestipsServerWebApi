using System;
using System.Collections.Generic;
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
    [Route("api/SecurityWidgets")]
    public class SecurityWidgetsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ISecurityRepository _securityRepository;

        public SecurityWidgetsController(IMapper mapper, IUnitOfWork uow, ISecurityRepository securityRepository)
        {
            this._securityRepository = securityRepository;
            this._uow = uow;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWidgetShapes(int id)
        {
            //try
            //{
            var security = await _securityRepository.GetSecurityWithStudies(id);
            if (security == null)
            {
                return NotFound();
            }

            var widgetShapeResource = Mapper.Map<Security, SecurityWidgetResource>(security);
            return Ok(widgetShapeResource);
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e);
            //    throw;
            //}
        }
    }
}