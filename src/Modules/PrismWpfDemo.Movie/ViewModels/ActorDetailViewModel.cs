using PrismWpfDemo.Domain;
using PrismWpfDemo.Infrastructures.Mvvm;

namespace PrismWpfDemo.Movie.ViewModels
{
    public class ActorDetailViewModel : ViewModelBase, IActorDetailViewModel
    {
        private Actor _selectedActor;

        public Actor SelectedActor
        {
            get { return _selectedActor; }
            set { SetProperty(ref _selectedActor, value); }
        }
    }
}
