using System;
using System.Threading.Tasks;
using Domain.User;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        public Task<UserModel> GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}