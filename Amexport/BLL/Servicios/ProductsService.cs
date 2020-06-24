using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Servicios;
using ENTITI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class ProductsService<T> : Service<T>, IProductsService<T> where T : Products
    {
        public ProductsService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
