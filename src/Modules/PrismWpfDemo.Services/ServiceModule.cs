using System;
using Ninject;
using Prism.Modularity;
using PrismWpfDemo.Business.Interfaces;

namespace PrismWpfDemo.Services
{
    public class ServiceModule : IModule
    {
        private readonly IKernel _kernel;

        public ServiceModule(IKernel kernel)
        {
            _kernel = kernel;
        }
        public void Initialize()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            _kernel.Bind<IMovieService>().To<MovieService>().InSingletonScope();
        }
    }
}
