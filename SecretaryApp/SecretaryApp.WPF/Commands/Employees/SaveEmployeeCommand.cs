using SecretaryApp.WPF.ViewModels;
using SecretaryApp.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands
{
    public class SaveEmployeeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
      //  public AddNewEmployeeView AddNewEmployeeView { get; set; }
        public AddNewEmployeeViewModel AddNewEmployeeView { get; set; }

        public SaveEmployeeCommand(AddNewEmployeeViewModel addNewEmployeeView)
        {
            AddNewEmployeeView = addNewEmployeeView;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddNewEmployeeView.SaveNewEmployee();
        }
    }
}
