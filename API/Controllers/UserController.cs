using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.IRepositories;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly BuggyController _buggy;

        public UserController(IUserRepo userRepo, IMapper mapper, BuggyController buggy)
        {
            this._userRepo = userRepo;
            this._mapper = mapper;
            this._buggy = buggy;
        }

        // GET: api/User
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepo.GetUsers();
            if (!ModelState.IsValid) return _buggy.GetBadRequest();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }

        // GET: api/User/5
        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            if (!ModelState.IsValid) return _buggy.GetBadRequest();
            var user = await _userRepo.GetUser(id);
            if (user == null)
                return _buggy.GetNotFound();
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
        
    }
}
