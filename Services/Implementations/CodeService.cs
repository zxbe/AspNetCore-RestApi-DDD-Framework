﻿using System.Threading.Tasks;
using Domain.Code;
using PasswordGenerator;

namespace Services.Implementations
{
    public class CodeService : ICodeService
    {
        public string GenerateCode(int len)
        {
            return new Password().IncludeLowercase().IncludeUppercase().LengthRequired(len).Next();
        }
    }
}