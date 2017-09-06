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
    [Produces("application/json")]
    [Route("api/widgetshapes")]
    public class WidgetShapesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ISecurityRepository _securityRepository;

        public WidgetShapesController(IMapper mapper, IUnitOfWork uow, ISecurityRepository securityRepository)
        {
            this._securityRepository = securityRepository;
            this._uow = uow;
            this._mapper = mapper;
        }

        [HttpGet("security/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetWidgetShapes(int id)
        {
            try
            {
                var security = await _securityRepository.GetSecurityWithStudies(id);
                if (security == null)
                {
                    return NotFound();
                }

                var widgetShapeResource = Mapper.Map<Security, WidgetShapesResource>(security);
                return Ok(widgetShapeResource);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}