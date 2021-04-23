using SecretaryApp.WPF.Commands;
using SecretaryApp.WPF.Models;
using SecretaryApp.WPF.ViewModels;
using System.Windows.Input;

namespace SecretaryApp.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel 
        { 
            get 
            {
                return _currentViewModel;
            }
            set 
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentMainViewModelCommand(this);

     
    }
}
