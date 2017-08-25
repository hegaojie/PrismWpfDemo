using System.Windows;
using System.Windows.Controls;
using Ninject;
using Prism.Modularity;
using Prism.Ninject;
using Prism.Regions;
using PrismWpfDemo.Infrastructures.Mvvm;
using PrismWpfDemo.Movie;
using PrismWpfDemo.Services;

namespace PrismWpfDemo.Client
{
    public class Bootstrapper : NinjectBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Kernel.Get<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell) Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleType = typeof(ServiceModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleType.Name,
                ModuleType = moduleType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            moduleType = typeof(MovieModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleType.Name,
                ModuleType = moduleType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();

            mappings.RegisterMapping(typeof(StackPanel), Kernel.Get<StackpanelRegionAdapter>());
            return mappings;
        }
    }
}
