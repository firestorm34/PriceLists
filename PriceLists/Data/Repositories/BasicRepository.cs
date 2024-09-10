using Microsoft.EntityFrameworkCore;

namespace PriceLists.Data.Repositories
{
    public class GenericRepository<TEntity> 
        where TEntity : class
    {
        DbContext context;
        public GenericRepository(DbContext context)
        {
            this.context = context;
        }
        public virtual TEntity? Add(TEntity entity)
        {
            if(entity == null) {
                return null;
            }
            context.Set<TEntity>().Add(entity);
            return entity;

        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return;
            }
            context.Remove(entity);
            return;
        }


        public virtual async Task<TEntity?> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public virtual TEntity? Update(TEntity entity)
        {
            if(entity == null)
            {
                return null;
            }
            context.Update(entity);

            return entity;


        }
    }
}
