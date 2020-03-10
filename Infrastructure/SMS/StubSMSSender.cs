using System;
using System.Threading.Tasks;

namespace Infrastructure.SMS
{
    public class StubSMSSender : ISMSSender
    {
        public async Task<SendSmsResponseModel> SendSMS(string phoneNumber, string text)
        {
            return new SendSmsResponseModel
            {
                MessageId = Guid.NewGuid(),
                SentAt = DateTime.UtcNow
            };
        }
    }
}
