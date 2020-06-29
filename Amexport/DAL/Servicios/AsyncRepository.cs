using DAL.Interfaces;
using ENTITI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servicios
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {

        protected readonly amexportEntities context;

        public AsyncRepository(amexportEntities context)
        {
            this.context = context;
            this.context.Configuration.ProxyCreationEnabled = false;

        }

        protected DbSet<T> EntitySet
        {
            get

            {
                return context.Set<T>();
            }
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public virtual async Task<T> Add(T entity)
        {
            EntitySet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.AnyAsync(expr);
        }


        public async Task Delete(T entity)
        {
            EntitySet.Remove(entity);
            await context.SaveChangesAsync();
        }

        

        public async Task<T> Find(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.FirstOrDefaultAsync(expr);
        }

      

        public async Task<List<T>> List()
        {
            return await EntitySet.ToListAsync();
        }

        public virtual async Task<List<T>> Search(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.Where(expr).ToListAsync();
        }


        public virtual async Task<T> SearchById(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        public virtual async Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
