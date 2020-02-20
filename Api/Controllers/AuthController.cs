using System;
using System.Threading.Tasks;
using Domain.Authenticate;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IAuthenticateService _authenticateService;
        public AuthController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        
        [HttpPost("[action]")]
        public async Task<ActionResult> Login()
        {
            return Ok();
        }

        
        [HttpPost("[action]")]
        public async Task<ActionResult> Logout()
        {
            return Ok();
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }

    }
}