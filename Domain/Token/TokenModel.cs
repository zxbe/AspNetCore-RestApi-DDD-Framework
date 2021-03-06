﻿using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.User;

namespace Domain.Token
{
    public class TokenModel: BaseModel
    {
        public string AppVersion { get; set; }
        public string UserAgent { get; set; }

        [Required]
        public string Token { get; set; }
        
        [Required]
        public Guid? UserId { get; set; }
        
        public UserModel User { get; set; }
    }
}