using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Ninject;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using PrismWpfDemo.Domain;
using PrismWpfDemo.Infrastructures.Mvvm;
using PrismWpfDemo.Movie.Events;
using PrismWpfDemo.Movie.Interfaces;
using PrismWpfDemo.Movie.ViewModels;
using PrismWpfDemo.Movie.Views;

namespace PrismWpfDemo.Movie
{
    public class MovieModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IKernel _kernel;
        private readonly IEventAggregator _eventAggregator;

        public MovieModule(IRegionManager regionManager, IKernel kernel, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _kernel = kernel;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<MovieSelectedEvent>().Subscribe(NavigateToSelectedMovie);
        }

        private void NavigateToSelectedMovie(Domain.Movie movie)
        {
            //var region = _regionManager.Regions[RegionTags.ContentRegion];
            //var views = region.Views;

            //var view = _kernel.Get<IMovieDetailView>();
            //var viewModel = view.ViewModel as MovieDetailViewModel;
            //viewModel.LoadMovie(movie);
            //region.Add(view, null, true);
            //region.Activate(view);

            var parameters = new NavigationParameters();
            parameters.Add("Movie", movie);
            _regionManager.RequestNavigate(RegionTags.ContentRegion, new Uri("MovieDetailView", UriKind.Relative), parameters);
        }

        public void Initialize()
        {
            RegisterDependencies();

            var region = _regionManager.Regions[RegionTags.ToolbarRegion];
            region.Add(new ToolbarView());

            region = _regionManager.Regions[RegionTags.SidebarRegion];
            region.Add(_kernel.Get<IMovieListView>());

            region = _regionManager.Regions[RegionTags.StatusbarRegion];
            region.Add(_kernel.Get<IStatusbarView>());
            
            _regionManager.RegisterViewWithRegion(RegionTags.ActorDetailRegion, () => _kernel.Get<IActorDetailView>());
            _regionManager.RegisterViewWithRegion(RegionTags.ContentRegion, typeof(MovieDetailView));

        }

        private void RegisterDependencies()
        {
            _kernel.Bind<IStatusbarView>().To<StatusbarView>();
            _kernel.Bind<IStatusbarViewModel>().To<StatusbarViewModel>();

            _kernel.Bind<IMovieListView>().To<MovieListView>();
            _kernel.Bind<IMovieListViewModel>().To<MovieListViewModel>();


            _kernel.Bind<IMovieDetailView>().To<MovieDetailView>(); //doesn't have to register
            _kernel.Bind<IMovieDetailViewModel>().To<MovieDetailViewModel>();


            _kernel.Bind<IActorDetailView>().To<ActorDetailView>();
            _kernel.Bind<IActorDetailViewModel>().To<ActorDetailViewModel>();



        }
    }
}
