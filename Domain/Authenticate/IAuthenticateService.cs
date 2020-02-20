using System.Threading.Tasks;

namespace Domain.Authenticate
{
    public interface IAuthenticateService
    {
        Task<UserLoginResponseModel> Login();
        Task<UserLogoutResponseModel> Logout();
    }
}