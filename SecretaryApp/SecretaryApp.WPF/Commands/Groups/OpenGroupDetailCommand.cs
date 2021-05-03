using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.Groups
{
    public class OpenGroupDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public GroupViewModel GroupViewModel { get; set; }

        public OpenGroupDetailCommand(GroupViewModel groupViewModel)
        {
            GroupViewModel = groupViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is Group)
            {
                GroupViewModel.OpenGroupDetail((Group)parameter);
            }

        }
    }
}
