using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.WorkLabels
{
    public class OpenWorkLabelDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public WorkLabelsViewModel WorkLabelsViewModel { get; set; }

        public OpenWorkLabelDetailCommand(WorkLabelsViewModel workLabelsViewModel)
        {
            WorkLabelsViewModel = workLabelsViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is WorkLabel)
                WorkLabelsViewModel.OpenWorkLabelDetail((WorkLabel)parameter);
        }
    }
}
