﻿using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.User;

namespace Domain.Code
{
    public class CodeModel : BaseModel
    {
        [Required] public Guid? UserId { get; set; }

        [Required] public DateTime DateExpiration { get; set; }

        [Required] public string Code { get; set; }
        [Required] public CodeReason ReasonId { get; set; }
        
        public UserModel User { get; set; }
    }
}