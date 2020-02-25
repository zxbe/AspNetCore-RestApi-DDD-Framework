using System.Threading.Tasks;
using Domain.Authenticate;
using Domain.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        // private IAuthenticateService _authenticateService;
        // public AuthController(IAuthenticateService authenticateService)
        // {
            // _authenticateService = authenticateService;
        // }
        
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequestModel requestModel)
        {
            return Ok();
        }

        
        [HttpPost("[action]")]
        public async Task<ActionResult> Logout([FromBody] UserLogoutRequestModel requestModel)
        {
            return Ok();
        }
        
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult> Registration([FromBody] UserRegistrationRequestModel requestModel)
        {
            return Ok();
        }
        
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> Test()
        {
            return Ok("Кукусики");
        }
      
        private BadRequestObjectResult BadRequest(ErrorCodes code, string property = "")
            => BadRequest(new ErrorContainer(code, property));
    }
}