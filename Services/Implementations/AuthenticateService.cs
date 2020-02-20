using System.Threading.Tasks;
using Domain.Authenticate;

namespace Services.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
        public Task<UserLoginResponseModel> Login()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserLogoutResponseModel> Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}