using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Authenticate;
using Domain.Error;
using Domain.Token;
using Domain.User;
using Infrastructure.Crypto;
using Microsoft.Extensions.Configuration;

namespace Services.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly CryptoHelper _cryptoHelper;
        private readonly ITokenService _tokenService;
        private readonly string _secretKey;

        public AuthenticateService(
            IConfiguration configuration,
            IUserRepository userRepository,
            CryptoHelper cryptoHelper,
            ITokenService tokenService,
            ITokenRepository tokenRepository
        )
        {
            _userRepository = userRepository;
            _cryptoHelper = cryptoHelper;
            _tokenService = tokenService;
            _tokenRepository = tokenRepository;
            _secretKey = configuration["AppSettings:Secret"];
        }

        public async Task<UserRegistrationResponseDto> Registration(UserRegistrationRequestDto requestDto)
        {
            var userEmailExists = await _userRepository.GetByEmail(requestDto.Email);
            if (userEmailExists != null)
            {
                return new UserRegistrationResponseDto
                {
                    Error = ErrorCodes.UserEmailExists,
                    ErrorField = new List<string> {"Email"}
                };
            }

            var userPhoneExists = await _userRepository.GetByPhone(requestDto.Phone);
            if (userPhoneExists != null)
            {
                return new UserRegistrationResponseDto
                {
                    Error = ErrorCodes.UserPhoneExists,
                    ErrorField = new List<string> {"Phone"}
                };
            }

            var res = await _userRepository.Create(new UserModel
                {
                    NameFirst = requestDto.NameFirst,
                    NameSecond = requestDto.NameSecond,
                    NamePatronymic = requestDto.NamePatronymic,
                    Password = _cryptoHelper.GetHash(requestDto.Password),
                    Phone = requestDto.Phone,
                    Email = requestDto.Email.ToLower()
                }
            );
            var sessionId = Guid.NewGuid();
            var token = _tokenService.GenerateToken(res.Id, sessionId, _secretKey);

            await _tokenRepository.Create(new TokenModel
                {
                    Id = sessionId,
                    UserAgent = requestDto.UserAgent,
                    Token = token,
                    UserId = res.Id
                }
            );
            await _userRepository.SaveChangesAsync();

            return new UserRegistrationResponseDto
            {
                Id = res.Id,
                AuthToken = token
            };
        }


        public async Task<UserLoginResponseDto> Login(UserLoginRequestDto requestDto)
        {
            var user = await _userRepository.GetByEmail(requestDto.Email);
            if (user == null)
            {
                return new UserLoginResponseDto
                {
                    Error = ErrorCodes.IncorrectEmailOrPassword,
                    ErrorField = new List<string> {"Email", "Password"}
                };
            }

            if (_cryptoHelper.GetHash(requestDto.Password) != user.Password)
            {
                return new UserLoginResponseDto
                {
                    Error = ErrorCodes.IncorrectEmailOrPassword,
                    ErrorField = new List<string> {"Email", "Password"}
                };
            }

            var sessionId = Guid.NewGuid();
            var token = _tokenService.GenerateToken(user.Id, sessionId, _secretKey);

            await _tokenRepository.Create(new TokenModel
                {
                    Id = sessionId,
                    UserAgent = requestDto.UserAgent,
                    Token = token,
                    UserId = user.Id
                }
            );
            await _tokenRepository.SaveChangesAsync();
            return new UserLoginResponseDto
            {
                Id = user.Id,
                AuthToken = token
            };
        }

        public async Task<UserLogoutResponseDto> Logout(Guid sessionId)
        {
            _tokenRepository.Delete(sessionId);
            await _tokenRepository.SaveChangesAsync();
            return new UserLogoutResponseDto();
        }
    }
}