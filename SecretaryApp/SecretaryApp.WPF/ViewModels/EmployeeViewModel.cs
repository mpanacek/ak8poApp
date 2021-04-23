using Caliburn.Micro;
using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands;
using SecretaryApp.WPF.Models;
using SecretaryApp.WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SecretaryApp.WPF.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> employees;

        public IDataService<Employee> _employeeService { get; set; }

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public AddEmployeeCommand AddEmployeeCommand { get; set; }

        public EmployeeViewModel(SecretaryAppDbContextFactory _context)
        {
            AddEmployeeCommand = new AddEmployeeCommand(this);
            _employeeService = new GenericDataService<Employee>(_context);
            LoadEmployees();
        }

        private async void LoadEmployees()
        {
            IEnumerable<Employee> entities = await _employeeService.GetAll();
            Employees = new ObservableCollection<Employee>(entities);
        }

        public void AddNewEmployeeOpenWindow()
        {
            AddNewEmployeeView addNewEmployee = new AddNewEmployeeView();
           // addNewEmployee.Show();
        }
    }
}
