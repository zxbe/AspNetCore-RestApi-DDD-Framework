using System.Threading.Tasks;

namespace Domain.Authenticate
{
    public interface IAuthenticateService
    {
        Task<UserRegistrationResponseModel> Register(UserRegistrationRequestModel requestModel);
        Task<UserLoginResponseModel> Login(UserLoginRequestModel requestModel);
        Task<UserLogoutResponseModel> Logout(UserLogoutRequestModel requestModel);
    }
}