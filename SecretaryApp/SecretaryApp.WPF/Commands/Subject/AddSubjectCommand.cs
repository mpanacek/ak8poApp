using SecretaryApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.Subject
{
    public class AddSubjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SubjectViewModel SubjectViewModel { get; set; }

        public AddSubjectCommand(SubjectViewModel subjectViewModel)
        {
            SubjectViewModel = subjectViewModel;
        }

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            SubjectViewModel.AddNewSubject();
        }
    }
}
