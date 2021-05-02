using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.State.SubNavigators
{
    public enum ViewType
    {
        AddNewEmployee
    }

    public interface ISubNavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
