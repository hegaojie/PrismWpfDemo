using System.Windows.Controls;
using PrismWpfDemo.Infrastructures.Mvvm;
using PrismWpfDemo.Movie.Interfaces;

namespace PrismWpfDemo.Movie.Views
{
    /// <summary>
    /// Interaction logic for MovieListView.xaml
    /// </summary>
    public partial class MovieListView : UserControl, IMovieListView
    {
        public MovieListView(IMovieListViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public object ViewModel
        {
            get { return (IMovieListViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}
