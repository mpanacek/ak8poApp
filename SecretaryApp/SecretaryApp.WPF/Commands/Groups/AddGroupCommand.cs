using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.Groups
{
    public class AddGroupCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public GroupViewModel GroupViewModel { get; set; }

        public AddGroupCommand(GroupViewModel groupViewModel)
        {
            GroupViewModel = groupViewModel;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            GroupViewModel.AddNewGroup();
        }
    }
}
