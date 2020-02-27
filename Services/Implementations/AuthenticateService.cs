using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Authenticate;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Services.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
        private IConfiguration _configuration;

        public AuthenticateService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public Task<UserRegistrationResponseModel> Registration(UserRegistrationRequestModel requestModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserLoginResponseModel> Login(UserLoginRequestModel requestModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserLogoutResponseModel> Logout(UserLogoutRequestModel requestModel)
        {
            throw new System.NotImplementedException();
        }
        
    }
}