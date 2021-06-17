using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.WorkLabels
{
    public class AddWorkLabelCommand : ICommand
    {
        public WorkLabelsViewModel WorkLabelsViewModel { get; set; }

        public AddWorkLabelCommand(WorkLabelsViewModel workLabelsViewModel)
        {
            WorkLabelsViewModel = workLabelsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            WorkLabelsViewModel.AddNewWorkLabelWindow();
        }
    }
}
