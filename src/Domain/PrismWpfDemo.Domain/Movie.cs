using System;
using System.Collections.ObjectModel;
using PrismWpfDemo.Infrastructures.Mvvm;

namespace PrismWpfDemo.Domain
{
    public class Movie : BindableBase
    {
        private string _name;
        private string _description;
        private int _rating;
        private DateTime? _lastUpdated;
        private ObservableCollection<Actor> _actors;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value);}
        }

        public int Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set { SetProperty(ref _lastUpdated, value); }
        }

        public ObservableCollection<Actor> Actors
        {
            get { return _actors; }
            set { SetProperty(ref _actors, value); }
        }

        public Movie()
        {
            Actors = new ObservableCollection<Actor>();
        }
    }
}
