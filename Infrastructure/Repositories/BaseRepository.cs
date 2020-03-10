using System;
using System.Threading.Tasks;
using Domain.Base;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<TModel> where TModel : BaseModel
    {
        protected Context Context;
        protected readonly DbSet<TModel> ContextEntity;

        protected BaseRepository(Context context)
        {
            Context = context;
            ContextEntity = Context.Set<TModel>();
        }
        
        public async Task<TModel> GetById(Guid guid)
        {
            var data  = ContextEntity.FirstOrDefaultAsync(u => u.Id == guid);
            return await data;
        }

        public async Task<TModel> Create(TModel data, Guid? creatorId)
        {
            data.CreatorId = creatorId;
            await ContextEntity.AddAsync(data);
            await Context.SaveChangesAsync();
            return data;
        }

        public async Task<TModel> Edit(TModel data)
        {
            ContextEntity.Update(data);
            await Context.SaveChangesAsync();
            return data;
        }
        
        public async Task<TModel> Delete(TModel model)
        {
            model.IsDelete = true;
            model.DateDelete = DateTime.Now;
            Context.Update(model);
            await Context.SaveChangesAsync();
            return model;
        }
    }
}