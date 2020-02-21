using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.User;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.User
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<UserModel> GetByPhone(string phone)
        {
            var user = Context.Users.FirstOrDefaultAsync(u => u.Phone == phone);
            return await user;
        }

        public async Task<UserModel> GetByEmail(string email)
        {
            var user = Context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return await user;
        }

        public async Task<UserModel> GetById(Guid guid)
        {
            var user = Context.Users.FirstOrDefaultAsync(u => u.Id == guid);
            return await user;
        }

        public async Task<UserModel> Create(UserModel data)
        {
            Context.Users.Add(data);
            await Context.SaveChangesAsync();
            return await Context.Users.LastAsync();
        }

        public async Task<UserModel> Edit(UserModel data)
        {
            Context.Users.Update(data);
            await Context.SaveChangesAsync();
            return data;
        }
    }
}