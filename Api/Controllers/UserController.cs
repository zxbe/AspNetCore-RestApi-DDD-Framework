﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController<UserModel>
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<UserModel>> Self()
        {
            var value = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            return await _userService.GetById(value);
        }

        [Authorize(Roles = "Administrator")]
        public override Task<ActionResult<UserModel>> Get()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Administrator")]
        public override Task<ActionResult<UserModel>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Administrator")]
        public override Task<ActionResult<UserModel>> Post(UserModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<UserModel>> Put(UserModel model)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Administrator")]
        public override Task<ActionResult<UserModel>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}