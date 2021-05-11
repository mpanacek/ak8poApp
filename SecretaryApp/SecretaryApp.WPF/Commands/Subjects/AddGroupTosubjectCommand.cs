using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.Views.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecretaryApp.WPF.Commands.Subject
{
    public class AddGroupTosubjectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public AddGroupToSubjectView AddGroupToSubjectView { get; set; }

        public AddGroupTosubjectCommand(AddGroupToSubjectView addGroupToSubjectView)
        {
            AddGroupToSubjectView = addGroupToSubjectView;
        }

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is Group)
            {
                Group selectedGroup = (Group)parameter;
                AddGroupToSubjectView.AddGroup(selectedGroup);
            }
        }
    }
}
