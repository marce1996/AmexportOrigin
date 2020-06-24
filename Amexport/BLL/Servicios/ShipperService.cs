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
    public class ShipperService<T> : Service<T>, IShippersService<T> where T : Shippers
    {
        public ShipperService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
