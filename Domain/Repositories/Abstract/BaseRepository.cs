using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.Domain.Infrastructure;

namespace VueDemo.Domain.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        internal readonly ComicsContext context;

        public BaseRepository(ComicsContext context)
        {
            this.context = context;
        }

        public async Task Save(T entity)
        {
            await Save(entity, 0);
        }

        public async Task Save(T entity, int id = 0)
        {
            try
            {
                if (id == 0)
                {
                    await context.Set<T>().AddAsync(entity);
                }
                else
                {
                    context.Set<T>().Update(entity);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                var entityToSetDeleted = await context.Set<T>().FindAsync(id);

                if (entityToSetDeleted != null)
                {
                    context.Set<T>().Remove(entityToSetDeleted);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        public IQueryable<T> Get()
        {
            return context.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> Find(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
