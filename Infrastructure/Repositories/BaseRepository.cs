using Domain.Base;
using Infrastructure.Contexts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TModel> where TModel : BaseModel
    {
        protected ILogger Logger;
        protected Context Context;

        public BaseRepository(Context context, ILogger logger)
        {
            Context = context;
            Logger = logger;
        }

    }
}