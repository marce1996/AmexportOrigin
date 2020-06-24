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

        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Any(Expression<Func<T, bool>> expr)
        {
            throw new NotImplementedException();
        }


        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        

        public Task<T> Find(Expression<Func<T, bool>> expr)
        {
            throw new NotImplementedException();
        }

      

        public Task<List<T>> List()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Search(Expression<Func<T, bool>> expr)
        {
            throw new NotImplementedException();
        }


        public Task<T> SearchById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
