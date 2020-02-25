using System.Threading.Tasks;
using Domain.Base;
using Infrastructure.Contexts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TModel> where TModel : BaseModel
    {
        protected Context Context;

        public BaseRepository(Context context)
        {
            Context = context;
        }

        public async Task SaveChangesAsync() => await Context.SaveChangesAsync();

    }
}