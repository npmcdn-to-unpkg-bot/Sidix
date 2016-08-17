using Dixus.Repositorios.Abstract;
using Dixus.Repositorios.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dixus.BusinessRules.Inversiones;
using Dixus.Entidades;
using Dixus.BusinessRules.ProyectosDeInversion;

namespace Dixus.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ICalculadoraPrecioUnitarioDeInversiones>().To<CalculadoraPrecioUnitarioDeInversiones>();
            kernel.Bind<ICalculadoraDeCobroPorInfraestructura>().To<CalculadoraDeCobroPorInfraestructura>();
            kernel.Bind<ICalculadoraDeProyectosDeInversion>().To<CalculadoraDeProyectosDeInversion>();
            
        }
    }
}