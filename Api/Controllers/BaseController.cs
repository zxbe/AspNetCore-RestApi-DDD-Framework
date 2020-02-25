using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Base;
using Domain.Error;

namespace Api.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseModel
    {
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
        private BadRequestObjectResult BadRequest(ErrorCodes code, string property = "")
            => BadRequest(new ErrorContainer(code, property));
    }
}