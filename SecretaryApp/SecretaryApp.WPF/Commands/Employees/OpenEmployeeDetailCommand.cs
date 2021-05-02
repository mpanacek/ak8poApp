using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands
{
    public class OpenEmployeeDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public EmployeeViewModel EmployeeViewModel { get; set; }

        public OpenEmployeeDetailCommand(EmployeeViewModel employeeViewModel)
        {
            EmployeeViewModel = employeeViewModel;
        }


        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is Employee)
            {
                Employee employee = (Employee)parameter;
                EmployeeViewModel.OpenEmployeeDetail(employee);
            }
        }
    }
}
