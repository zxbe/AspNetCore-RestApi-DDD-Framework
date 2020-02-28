﻿using System;
using System.Threading.Tasks;

namespace Domain.Authenticate
{
    public interface IAuthenticateService
    {
        Task<UserRegistrationResponseDto> Registration(UserRegistrationRequestDto requestDto);
        Task<UserLoginResponseDto> Login(UserLoginRequestDto requestDto);
        Task<UserLogoutResponseDto> Logout(Guid sessionId);
    }
}