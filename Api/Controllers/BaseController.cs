using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Base;
using Domain.Error;
using Domain.User;
using Services.Implementations;

namespace Api.Controllers
{
    public abstract class BaseController<T> : ControllerBase where T : BaseModel
    {
        protected BaseController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public abstract Task<ActionResult<T>> Get();
        [HttpGet("{id}")]
        public abstract Task<ActionResult<T>> Get(Guid id);
        [HttpPost]
        public abstract Task<ActionResult<T>> Post([FromBody]T model);
        [HttpPut]
        public abstract Task<ActionResult<T>> Put([FromBody]T model);
        [HttpDelete("{id}")]
        public abstract Task<ActionResult<T>> Delete(Guid id);

        protected UserModel CurrentUser => UserService.GetById(Guid.Parse(User.FindFirstValue(ClaimTypes.Name))).Result;
        protected BadRequestGenericResult<T> BadRequest(ErrorCodes code, List<string> properties)
            => new BadRequestGenericResult<T>(new ErrorContainer(code, properties));

        protected BadRequestGenericResult<T> BadRequest(ErrorCodes code, string property)
            => new BadRequestGenericResult<T>(new ErrorContainer(code, new List<string> { property }));
        protected IUserService UserService { get; }
    }
}