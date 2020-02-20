using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.User
{
    public interface IUserService
    {
        Task<UserModel> GetByPhone(string phone);
        Task<UserModel> GetByEmail(string email);
        Task<UserModel> GetById(Guid guid);
    }
}