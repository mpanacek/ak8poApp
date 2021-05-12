using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands;
using SecretaryApp.WPF.Models;
using SecretaryApp.WPF.State.Navigators;
using SecretaryApp.WPF.State.SubNavigators;
using SecretaryApp.WPF.Views;
using SecretaryApp.WPF.Views.Employee;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SecretaryApp.WPF.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        public IDataService<Employee> _employeeService { get; set; }

        private ObservableCollection<Employee> employees;

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
        public OpenEmployeeDetailCommand OpenEmployeeDetailCommand { get; set; }


        public EmployeeViewModel(SecretaryAppDbContextFactory _context)
        {
            AddEmployeeCommand = new AddEmployeeCommand(this);
            OpenEmployeeDetailCommand = new OpenEmployeeDetailCommand(this);

            _employeeService = new EmployeeDataService(_context, new GenericDataService<Employee>(_context));
            LoadEmployees();
        }

        public async void LoadEmployees()
        {
            IEnumerable<Employee> entities = await _employeeService.GetAll();
            Employees = new ObservableCollection<Employee>(entities);
        }

        public void AddNewEmployeeOpenWindow()
        {
            AddNewEmployeeView addNewEmployee = new AddNewEmployeeView(_employeeService, Employees);

            addNewEmployee.Height = 450;
            addNewEmployee.Width = 850;
            addNewEmployee.Show();
        }

        public void OpenEmployeeDetail(Employee employee)
        {
            EmployeeDetail employeeDetail = new EmployeeDetail(employee, _employeeService, Employees);

            employeeDetail.Height = 450;
            employeeDetail.Width = 850;
            employeeDetail.Show();
        }
    }
}
