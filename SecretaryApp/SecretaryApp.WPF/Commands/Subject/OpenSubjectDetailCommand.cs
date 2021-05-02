using SecretaryApp.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.Subject
{
    public class OpenSubjectDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SubjectViewModel SubjectViewModel { get; set; }

        public OpenSubjectDetailCommand(SubjectViewModel subjectViewModel)
        {
            SubjectViewModel = subjectViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is Domain.Models.Subject)
            {
                Domain.Models.Subject subject = (Domain.Models.Subject)parameter;

                SubjectViewModel.OpenSubjectDetail(subject);
            }
        }
    }
}
