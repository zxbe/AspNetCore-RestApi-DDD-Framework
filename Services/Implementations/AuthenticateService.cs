using System.Threading.Tasks;
using Domain.Authenticate;

namespace Services.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
        public Task<UserRegistrationResponseModel> Register(UserRegistrationRequestModel requestModel)
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