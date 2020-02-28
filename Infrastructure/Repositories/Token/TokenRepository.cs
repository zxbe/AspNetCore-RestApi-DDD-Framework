﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Token;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.Token
{
    public class TokenRepository: BaseRepository<TokenModel>, ITokenRepository
    {
        public TokenRepository(Context context) : base(context)
        {
        }
        
        public async Task<TokenModel> Create(TokenModel data)
        {
            await Context.Token.AddAsync(data);
            return data;
        }

        public void Delete(Guid sessionId)
        {
            Context.Token.RemoveRange(Context.Token.Where( u => u.Id == sessionId));
        }
        
    }
}