using System.Windows.Controls;
using PrismWpfDemo.Infrastructures.Mvvm;

namespace PrismWpfDemo.Movie
{
    /// <summary>
    /// Interaction logic for StatusbarView.xaml
    /// </summary>
    public partial class StatusbarView : UserControl, IStatusbarView
    {
        public StatusbarView(IStatusbarViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public object ViewModel
        {
            get { return (IStatusbarViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}
