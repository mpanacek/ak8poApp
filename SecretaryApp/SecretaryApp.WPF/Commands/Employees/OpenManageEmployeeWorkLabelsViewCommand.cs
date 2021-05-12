using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.Employees
{
    public class OpenManageEmployeeWorkLabelsViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public BundleListViewModel BundleListViewModel { get; set; }

        public OpenManageEmployeeWorkLabelsViewCommand(BundleListViewModel bundleListViewModel)
        {
            BundleListViewModel = bundleListViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Employee)
                BundleListViewModel.OpenEmployeeManageWorkLabel((Employee)parameter);
        }
    }
}
