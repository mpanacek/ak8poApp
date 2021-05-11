using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands
{
    public class AddWorkLabelToEmployeeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public BundleListViewModel BundleListViewModel { get; set; }

        public AddWorkLabelToEmployeeCommand(BundleListViewModel bundleListViewModel)
        {
            BundleListViewModel = bundleListViewModel;
        }

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is WorkLabel)
            {
                BundleListViewModel.SelectedWorkLabelToEmployee((WorkLabel)parameter);
            }
        }
    }
}
