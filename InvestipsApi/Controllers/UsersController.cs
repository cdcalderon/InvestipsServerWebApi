using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investips.Core;
using Microsoft.AspNetCore.Mvc;
using InvestipsApi.Controllers.Resources;
using Investips.Core.Models;

namespace InvestipsApi.Controllers
{
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        public UsersController(IMapper mapper, IUnitOfWork uow, IUserRepository userRepository)
        {
            _uow = uow;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            var porfolioResource = _mapper.Map<User, UserResource>(user);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserResource userResource)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = Mapper.Map<UserResource, User>(userResource);

                _userRepository.Add(user);
                await _uow.CompleteAsync();

                user = await _userRepository.GetUser(user.Id);
                var result = _mapper.Map<User, UserResource>(user);
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