using System.Windows;
using Ninject;
using Prism.Modularity;
using Prism.Ninject;
using PrismWpfDemo.Movie;

namespace PrismWpfDemo.Client
{
    public class ApplicationBootstrapper : NinjectBootstrapper
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

            var moduleType = typeof(MovieModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleType.Name,
                ModuleType = moduleType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });


        }
    }
}
