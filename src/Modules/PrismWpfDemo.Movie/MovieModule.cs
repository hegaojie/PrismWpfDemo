using Prism.Modularity;
using Prism.Regions;

namespace PrismWpfDemo.Movie
{
    public class MovieModule : IModule
    {
        private IRegionManager _regionManager;

        public MovieModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ToolbarRegion", typeof(ToolbarView));
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ContentView));

        }
    }
}
