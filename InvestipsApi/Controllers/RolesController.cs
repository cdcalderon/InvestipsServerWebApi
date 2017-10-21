using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investips.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestipsApi.Controllers
{
    
    [Route("api/Roles")]
    public class RolesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RolesController(IMapper mapper, IUnitOfWork uow)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }
    }
}