using System;
using System.ComponentModel;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using PrismWpfDemo.Business.Interfaces;
using PrismWpfDemo.Infrastructures.Mvvm;
using PrismWpfDemo.Movie.Events;

namespace PrismWpfDemo.Movie
{
    public class MovieDetailViewModel : ViewModelBase, IMovieDetailViewModel, INavigationAware, IRegionMemberLifetime
    {
        private Domain.Movie _movie;
        private readonly IEventAggregator _eventAggregator;
        private readonly IMovieService _movieService;

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public Domain.Movie Movie
        {
            get { return _movie; }
            set
            {
                if (_movie != null) _movie.PropertyChanged -= MovieOnPropertyChanged;
                SetProperty(ref _movie, value);
                _movie.PropertyChanged += MovieOnPropertyChanged;
            }
        }

        private void MovieOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }


        public MovieDetailViewModel(IEventAggregator eventAggregator, IMovieService movieService)
        {
            _eventAggregator = eventAggregator;
            _movieService = movieService;

            //InitMovie();

            SaveCommand = new DelegateCommand(Save, CanSave);
            CloseCommand = new DelegateCommand(Close);

            //GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
        }

        private void InitMovie()
        {
            Movie = new Domain.Movie
            {
                Name = "The Great Wall",
                Description = "Chiense/American",
                Rating = 5
            };
        }

        public void LoadMovie(Domain.Movie movie)
        {
            Movie = movie;
        }

        private bool CanSave()
        {
            return Movie != null && Movie.Rating > 1;
        }

        private void Save()
        {
            _movieService.SaveMovie(Movie);

            _eventAggregator.GetEvent<MovieChangedEvent>().Publish(Movie.Name);
        }

        private void Close()
        {
            //todo: Close movie detail view
        }

        public string Message { get; set; }

        public string ViewName
        {
            get { return Movie != null ? Movie.Name : String.Empty; }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var movie = navigationContext.Parameters["Movie"];
            Movie = (Domain.Movie)movie;

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public bool KeepAlive {
            get { return true; }
        }
    }
}
