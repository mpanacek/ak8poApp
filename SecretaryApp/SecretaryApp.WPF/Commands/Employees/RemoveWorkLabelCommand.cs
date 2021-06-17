using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.Views.Employee;
using System;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.Employees
{
    public class RemoveWorkLabelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public EmployeeManageWorkLabels EmployeeManageWorkLabels { get; set; }

        public RemoveWorkLabelCommand(EmployeeManageWorkLabels employeeManageWorkLabels)
        {
            EmployeeManageWorkLabels = employeeManageWorkLabels;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is WorkLabel)
            {
                EmployeeManageWorkLabels.RemoveWorkLabel((WorkLabel)parameter);
            }
        }
    }
}
