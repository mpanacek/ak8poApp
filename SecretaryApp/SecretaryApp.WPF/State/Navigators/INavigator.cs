using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.State.Navigators
{
    public enum ViewType
    {
        Employee,
        Subject,
        Group,
        BundleList,
        WorkLabels
    }

    public interface INavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
