﻿using System;
using System.Threading.Tasks;

namespace Domain.Token
{
    public interface ITokenRepository
    {
        Task<TokenModel> Create(TokenModel data, Guid creatorId);
        Task<TokenModel> Delete(TokenModel model);
    }
}