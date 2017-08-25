using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrismWpfDemo.Infrastructures.Mvvm
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            property = value;
            OnPropertyChanged(propertyName);
        }
    }
}
