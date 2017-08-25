using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using PrismWpfDemo.Business.Interfaces;
using PrismWpfDemo.Infrastructures.Mvvm;
using PrismWpfDemo.Movie.Events;
using PrismWpfDemo.Movie.Interfaces;

namespace PrismWpfDemo.Movie.ViewModels
{
    public class MovieListViewModel : ViewModelBase, IMovieListViewModel
    {
        private ObservableCollection<Domain.Movie> _movies;
        private readonly IMovieService _movieService;
        private bool _isBusy;
        private Domain.Movie _selectedMovie;
        private readonly IEventAggregator _eventAggregator;


        public ObservableCollection<Domain.Movie> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public MovieListViewModel(IMovieService movieService, IEventAggregator eventAggregator)
        {
            _movieService = movieService;
            _eventAggregator = eventAggregator;

            LoadMoviesAsync();

            NavigateCommand = new DelegateCommand(NavigateToMovie);
        }

        private void NavigateToMovie()
        {
            //todo: navigate to movie detail view
        }

        private async void LoadMoviesAsync()
        {
            IsBusy = true;
            var movies = await _movieService.LoadMoviesAsync();
            IsBusy = false;
            Movies = new ObservableCollection<Domain.Movie>(movies);
        }

        public Domain.Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                SetProperty(ref _selectedMovie, value);
#if DEBUG
                Console.WriteLine("{0} is selected.", SelectedMovie.Name);
#endif
                
                //todo:
                _eventAggregator.GetEvent<MovieSelectedEvent>().Publish(SelectedMovie);
            }
        }

        public DelegateCommand NavigateCommand { get; set; }
    }
}
