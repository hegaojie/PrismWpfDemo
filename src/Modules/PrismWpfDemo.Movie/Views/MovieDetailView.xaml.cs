using System.Windows.Controls;
using PrismWpfDemo.Infrastructures.Mvvm;

namespace PrismWpfDemo.Movie
{
    /// <summary>
    /// Interaction logic for MovieDetailView.xaml
    /// </summary>
    public partial class MovieDetailView : UserControl, IMovieDetailView
    {
        public MovieDetailView(IMovieDetailViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public object ViewModel
        {
            get { return (IMovieDetailViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
    
}
