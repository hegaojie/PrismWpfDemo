using System;
using Prism.Events;
using PrismWpfDemo.Infrastructures.Mvvm;
using PrismWpfDemo.Movie.Events;

namespace PrismWpfDemo.Movie
{
    public class StatusbarViewModel : ViewModelBase, IStatusbarViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private string _status;

        public StatusbarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<MovieChangedEvent>().Subscribe(AfterMovieChanged);

            Status = "Ready";
        }

        private void AfterMovieChanged(object obj)
        {
            Status = $"'{obj}' was updated at {DateTime.Now}";
        }

        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
    }
}
