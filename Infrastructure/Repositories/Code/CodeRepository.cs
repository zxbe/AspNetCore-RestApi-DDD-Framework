﻿using System;
using System.Threading.Tasks;
using Domain.Code;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Code
{
    public class CodeRepository : BaseRepository<CodeModel>, ICodeRepository
    {

        public async Task<CodeModel> GetByCode(string code)
        {
            var res = Context.Code.FirstOrDefaultAsync(u => u.Code == code);
            return await res;
            
        }

        public async Task<CodeModel> GetByUserId(Guid userId)
        {
            var res = Context.Code.FirstOrDefaultAsync(u => u.Id == userId);
            return await res;
        }
        
        public CodeRepository(Context context) : base(context)
        {
        }
    }
}