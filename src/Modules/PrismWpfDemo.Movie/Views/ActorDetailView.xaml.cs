using System.Windows.Controls;
using Prism.Common;
using Prism.Regions;
using PrismWpfDemo.Domain;
using PrismWpfDemo.Infrastructures.Mvvm;
using PrismWpfDemo.Movie.ViewModels;

namespace PrismWpfDemo.Movie.Views
{
    /// <summary>
    /// Interaction logic for ActorDetailView.xaml
    /// </summary>
    public partial class ActorDetailView : UserControl, IActorDetailView
    {
        public ActorDetailView(IActorDetailViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            RegionContext.GetObservableContext(this).PropertyChanged += (s, e) =>
            {
                var context = (ObservableObject<object>) s;
                var selectedActor = (Actor) context.Value;
                (ViewModel as ActorDetailViewModel).SelectedActor = selectedActor;
            };
        }

        public object ViewModel
        {
            get { return (IActorDetailViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}
