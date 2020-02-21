using System.Threading.Tasks;

namespace Domain.Authenticate
{
    public interface IAuthenticateService
    {
        Task<UserRegistrationResponseModel> Registration(UserRegistrationRequestModel requestModel);
        Task<UserLoginResponseModel> Login(UserLoginRequestModel requestModel);
        Task<UserLogoutResponseModel> Logout(UserLogoutRequestModel requestModel);
    }
}