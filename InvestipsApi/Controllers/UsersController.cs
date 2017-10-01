using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investips.Core;
using Microsoft.AspNetCore.Mvc;

namespace InvestipsApi.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IMapper mapper, IUnitOfWork uow)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }
    }
}