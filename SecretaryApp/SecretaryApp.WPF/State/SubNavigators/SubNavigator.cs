using SecretaryApp.WPF.Commands;
using SecretaryApp.WPF.Models;
using SecretaryApp.WPF.ViewModels;
using System.Windows.Input;

namespace SecretaryApp.WPF.State.SubNavigators
{
    public class SubNavigator : ObservableObject, ISubNavigator
    {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel 
        {
            get
            {
                return currentViewModel;
            }

            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentSubViewModel(this);
    }
}
