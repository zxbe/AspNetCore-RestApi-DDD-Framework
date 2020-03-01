﻿using System.Collections.Generic;

 namespace Domain.Error
{
    public class ErrorContainer
    {
        public ErrorContainer(ErrorCodes errorCode, List<string> property)
        {
            ErrorCode = errorCode;
            Property = property;
        }

        private ErrorCodes ErrorCode { get; }
        public List<string> Property { get; }

        public string Error => ErrorCode.ToString();
        public int Code => (int)ErrorCode;
    }
}
