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
    public class OrdersService<T> : Service<T>, IOrdersService<T> where T : Orders
    {
        public OrdersService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    
    }
}
