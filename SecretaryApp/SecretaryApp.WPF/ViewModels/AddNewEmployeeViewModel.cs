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
        public SaveEmployeeCommand SaveEmployeeCommand { get; set; }

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

        //public string Surname { get; set; }
        //public string FullName { get; set; }
        //public string WorkEmail { get; set; }
        //public string PersonalEmail { get; set; }
        //public string WorkPhone { get; set; }
        //public string PersonalPhone { get; set; }
        //public int WorkPoints_NoEng { get; set; }
        //public int WorkPoints { get; set; }
        //public double WorkingTime { get; set; }
        //public bool DoctoralStudent { get; set; }

        public AddNewEmployeeViewModel()
        {
            SaveEmployeeCommand = new SaveEmployeeCommand(this);

            //AddNewEmployeeView addNewEmployee = new AddNewEmployeeView();
            //addNewEmployee.Height = 450;
            //addNewEmployee.Width = 850;
            //addNewEmployee.Show();
        }

        public void SaveNewEmployee()
        {
            Employee employee = new Employee();
            employee.Name = Name;
        }
    }
}
