using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands;
using SecretaryApp.WPF.Commands.Employees;
using SecretaryApp.WPF.Logic;
using SecretaryApp.WPF.Views.Employee;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SecretaryApp.WPF.ViewModels
{
    public class BundleListViewModel : ViewModelBase
    {
        private IDataService<Employee> _employeeService { get; set; }
        private IDataService<WorkLabel> _worklabelDataService { get; set; }

        public AddWorkLabelToEmployeeCommand AddWorkLabelToEmployeeCommand { get; set; }
        public OpenManageEmployeeWorkLabelsViewCommand OpenManageEmployeeWorkLabelsViewCommand { get; set; }


        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set 
            { 
                selectedEmployee = value;
            }
        }

        private ObservableCollection<WorkLabel> workLabels;

        public ObservableCollection<WorkLabel> WorkLabels
        {
            get
            {
                return workLabels;
            }
            set
            {
                workLabels = value;
                OnPropertyChanged(nameof(WorkLabels));
            }
        }

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

        public BundleListViewModel(SecretaryAppDbContextFactory _context)
        {
            _employeeService = new EmployeeDataService(_context, new GenericDataService<Employee>(_context));
            _worklabelDataService = new WorkLabelDataService(_context, new GenericDataService<WorkLabel>(_context));
            AddWorkLabelToEmployeeCommand = new AddWorkLabelToEmployeeCommand(this);
            OpenManageEmployeeWorkLabelsViewCommand = new OpenManageEmployeeWorkLabelsViewCommand(this);
            LoadData();
        }

        public async void LoadData()
        {
            IEnumerable<Employee> entities = await _employeeService.GetAll();
            Employees = new ObservableCollection<Employee>(entities);

            IEnumerable<WorkLabel> workLabels = await _worklabelDataService.GetAll();
            WorkLabels = new ObservableCollection<WorkLabel>(workLabels.Where(w => w.Employee == null));
        }

        public void SelectedWorkLabelToEmployee(WorkLabel label)
        {
            if(SelectedEmployee != null)
            {
                label.Employee = SelectedEmployee;

                _worklabelDataService.Update(label.Id, label);


                WorkLabels.Remove(label);
                Employees.Remove(SelectedEmployee);
                Employees.Add(SelectedEmployee);
                SelectedEmployee = null;
            }
        }

        public void OpenEmployeeManageWorkLabel(Employee employee)
        {
            EmployeeManageWorkLabels employeeManageWorkLabels = new EmployeeManageWorkLabels(employee, _worklabelDataService, _employeeService, WorkLabels);
            employeeManageWorkLabels.Show();
        }
    }
}
