using System.Threading.Tasks;

namespace Infrastructure.SMS
{
    public interface ISMSSender
    {
        Task<SendSmsResponseModel> SendSMS(string phoneNumber, string text);
    }
}
