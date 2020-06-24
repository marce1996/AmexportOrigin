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
    public class CustomersService<T> : Service<T>, ICustomersService<T> where T : Customers
    {
        public CustomersService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
