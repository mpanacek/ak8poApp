using SecretaryApp.WPF.ViewModels;
using SecretaryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.Subjects
{
    public class EditSubjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SubjectViewModel SubjectViewModel { get; set; }

        public EditSubjectCommand(SubjectViewModel subjectViewModel)
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
                SubjectViewModel.EditSubject(subject);
            }
        }
    }
}
