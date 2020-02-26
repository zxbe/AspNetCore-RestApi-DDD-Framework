using System.Collections.Generic;
using Domain.Error;
using Microsoft.VisualBasic;

namespace Domain.Base
{
    public class BaseResponseModel
    {
        public ErrorCodes? Error { get; set; }
        public List<Strings> ErrorField { get; set; }
    }
}