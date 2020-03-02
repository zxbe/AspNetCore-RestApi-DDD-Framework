﻿using System.Threading.Tasks;

namespace Domain.Code
{
    public interface ICodeService
    {
        string GenerateCode(int len);
    }
}