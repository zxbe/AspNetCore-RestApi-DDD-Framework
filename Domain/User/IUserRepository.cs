using System;
using System.Threading.Tasks;

namespace Domain.User
{
    public interface IUserRepository
    {
        Task<UserModel> GetByPhone(string phone);
        Task<UserModel> GetByEmail(string email);
        Task<UserModel> GetById(Guid guid);
        Task<UserModel> Create(UserModel data);
        Task<UserModel> Edit(UserModel data);
    }
}