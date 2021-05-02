using SecretaryApp.WPF.State.Navigators;
using System.ComponentModel;

namespace SecretaryApp.WPF.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigator Navigator { get; set; } = new Navigator();

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
