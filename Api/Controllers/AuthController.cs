using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Authenticate;
using Domain.Error;
using Domain.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthenticateService _authenticateService;

        public AuthController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequestDto requestDto)
        {
            if(User.Identity.IsAuthenticated)
            {
                return Forbid();
            }   

            requestDto.UserAgent = Request.Headers["User-Agent"].ToString();
            var result = await _authenticateService.Login(requestDto);

            if (result.Error != null)
            {
                var error = result.Error ?? ErrorCodes.NotFound;
                BadRequest(error, result.ErrorField);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult> Registration([FromBody] UserRegistrationRequestDto requestDto)
        {
            requestDto.UserAgent = Request.Headers["User-Agent"].ToString();
            requestDto.AppVersion = Request.Headers["X-Application-Version"].ToString();
            var result = await _authenticateService.Registration(requestDto);

            if (result.Error != null)
            {
                var error = result.Error ?? ErrorCodes.NotFound;
                BadRequest(error, result.ErrorField);
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Logout()
        {
            var value = Guid.Parse(User.FindFirstValue(ClaimTypes.Sid));
            await _authenticateService.Logout(value);
            return Ok();
        }
        
        [HttpPost("[action]")]
        public async Task<ActionResult> PasswordForgot([FromBody] UserPasswordForgotRequestDto requestDto)
        {
            await _authenticateService.PasswordForgot(requestDto);
            return Ok();
        }
        
        // [HttpPost("[action]")]
        // public async Task<ActionResult> PasswordChange([FromBody] UserPasswordChangeRequestDto)
        // {
            // var value = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            // return Ok();
        // }
        
        private BadRequestObjectResult BadRequest(ErrorCodes code, List<string> property)
            => BadRequest(new ErrorContainer(code, property));
        
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> Test()
        {
            return Ok("Кукусики");
        }
    }
}