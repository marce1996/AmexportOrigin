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
    public class CategoriesService<T> : Service<T>, ICategoriesService<T> where T : Categories
    {
        public CategoriesService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
