using SecretaryApp.WPF.State.SubNavigators;
using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands
{
    public class UpdateCurrentSubViewModel : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ISubNavigator _subNavigator;

        public UpdateCurrentSubViewModel(ISubNavigator subNavigator)
        {
            _subNavigator = subNavigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                switch (viewType)
                {
                    case ViewType.AddNewEmployee:
                        _subNavigator.CurrentViewModel = new AddNewEmployeeViewModel();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
