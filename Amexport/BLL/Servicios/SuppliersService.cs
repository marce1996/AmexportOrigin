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
    public class SuppliersService<T> : Service<T>, ISuppliersService<T> where T : Suppliers
    {
        public SuppliersService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
