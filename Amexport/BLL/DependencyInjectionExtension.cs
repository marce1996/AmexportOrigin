using DAL.Interfaces;
using DAL.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace BLL
{
    public class DependencyInjectionExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
        }
    }
}
