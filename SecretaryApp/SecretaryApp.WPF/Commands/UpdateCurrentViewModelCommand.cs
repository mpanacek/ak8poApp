using SecretaryApp.WPF.State.Navigators;
using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                switch(viewType)
                {
                    case ViewType.Employee:
                        _navigator.CurrentViewModel = new EmployeeViewModel();
                        break;

                    case ViewType.Subject:
                        _navigator.CurrentViewModel = new SubjectViewModel();
                        break;

                    case ViewType.Group:
                        _navigator.CurrentViewModel = new GroupViewModel();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
