﻿using System;
using System.Threading.Tasks;

namespace Domain.Token
{
    public interface ITokenRepository
    {
        Task<TokenModel> Create(TokenModel data);
        void Delete(Guid sessionId);
        public Task SaveChangesAsync();
    }
}