using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servicios
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IAsyncRepository<T> _repository;

        public Service(IAsyncRepository<T> repository)
        {
            _repository = repository;
        }
        public Task<T> Add(T reg)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Any(Expression<Func<T, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T reg)
        {
            throw new NotImplementedException();
        }

        public Task<T> Find(Expression<Func<T, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> List()
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

        public Task Update(T reg)
        {
            throw new NotImplementedException();
        }
    }
}
