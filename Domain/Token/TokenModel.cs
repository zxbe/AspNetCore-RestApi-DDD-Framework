﻿using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.Token
{
    public class TokenModel: BaseModel
    {
        public string UserAgent { get; set; }

        [Required]
        public string Token { get; set; }
        
        [Required]
        public Guid? UserId { get; set; }
    }
}