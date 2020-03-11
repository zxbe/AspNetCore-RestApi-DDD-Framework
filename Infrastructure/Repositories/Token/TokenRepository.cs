﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Token;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.Token
{
    public class TokenRepository: BaseRepository<TokenModel>
    {
        public TokenRepository(Context context) : base(context)
        {
        }
        
    }
}