using Domain.Error;

namespace Domain.Base
{
    public class BaseResponseModel
    {
        public ErrorCodes? Error { get; set; }
        public string ErrorField { get; set; }
    }
}