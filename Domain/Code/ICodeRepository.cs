﻿using System;
using System.Threading.Tasks;

namespace Domain.Code
{
    public interface ICodeRepository
    {
        Task<CodeModel> GetByCode(string code);
        Task<CodeModel> GetByUserId(Guid userId);
        Task<CodeModel> Create(CodeModel model);
        CodeModel Edit(CodeModel model);
        Task SaveChangesAsync();

    }
}