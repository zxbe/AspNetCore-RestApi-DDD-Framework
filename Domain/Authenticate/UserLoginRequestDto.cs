﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Authenticate
{
    public class UserLoginRequestDto
    {
        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }

        public string UserAgent { get; set; }
    }
}