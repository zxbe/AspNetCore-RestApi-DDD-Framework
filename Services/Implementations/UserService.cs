using System;
using System.Threading.Tasks;
using Domain.User;
using Infrastructure.Repositories.User;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserModel> GetById(Guid guid)
        {
            var res = await _userRepository.GetById(guid);
            return res;
        }
    }
}