using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.Commands;
using SecretaryApp.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryApp.WPF.ViewModels
{
    public class AddNewEmployeeViewModel : ViewModelBase
    {
       // public SaveEmployeeCommand SaveEmployeeCommand { get; set; }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public AddNewEmployeeViewModel()
        {
     //       SaveEmployeeCommand = new SaveEmployeeCommand(this);
        }

        //public void SaveNewEmployee()
        //{
        //    Employee employee = new Employee();
        //    employee.Name = Name;
        //}
    }
}
