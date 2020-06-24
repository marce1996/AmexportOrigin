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
    public class EmployeesService<T> : Service<T>, IEmployeesService<T> where T : Employees
    {
        public EmployeesService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
