﻿using Domain.Error;

namespace Domain.Base
{
    public class ResultContainer<T>
    {
        public ResultContainer(T result)
        {
            Result = result;
        }

        public ResultContainer(ErrorCodes errorCode, string errorField)
        {
            Error = errorCode;
            ErrorField = errorField;
        }

        public ErrorCodes? Error { get; set; }
        public string ErrorField { get; set; }
        public T Result { get; }
    }
}
