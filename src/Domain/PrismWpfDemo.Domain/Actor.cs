using PrismWpfDemo.Infrastructures.Mvvm;

namespace PrismWpfDemo.Domain
{
    public class Actor : BindableBase
    {
        private string _name;
        private int _age;
        private string _gender;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        public string Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }
    }
}