using SecretaryApp.Domain.Models;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands;
using SecretaryApp.WPF.Commands.Employees;
using SecretaryApp.WPF.Views.Employee;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SecretaryApp.WPF.ViewModels
{
    public class BundleListViewModel : ViewModelBase
    {
        public BundleListViewDataService _bundleListViewDataService { get; set; }

        public AddWorkLabelToEmployeeCommand AddWorkLabelToEmployeeCommand { get; set; }
        public OpenManageEmployeeWorkLabelsViewCommand OpenManageEmployeeWorkLabelsViewCommand { get; set; }
        public RemoveWorkLabelInBundleListCommand RemoveWorkLabelInBundleListCommand { get; set; }

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
            _bundleListViewDataService = new BundleListViewDataService(new SecretaryAppDbContextFactory());
            
            AddWorkLabelToEmployeeCommand = new AddWorkLabelToEmployeeCommand(this);
            RemoveWorkLabelInBundleListCommand = new RemoveWorkLabelInBundleListCommand(this);
            OpenManageEmployeeWorkLabelsViewCommand = new OpenManageEmployeeWorkLabelsViewCommand(this);
            LoadData();
        }

        public async void LoadData()
        {
            IEnumerable<Employee> entities = await _bundleListViewDataService.GetAllEmployees();
            Employees = new ObservableCollection<Employee>(entities);

            IEnumerable<WorkLabel> workLabels = await _bundleListViewDataService.GetAllWorkLabels();
            WorkLabels = new ObservableCollection<WorkLabel>(workLabels.Where(w => w.Employee == null));
        }

        public async void SelectedWorkLabelToEmployee(WorkLabel label)
        {
            if(SelectedEmployee != null)
            {
                label.Employee = SelectedEmployee;


                await _bundleListViewDataService.Update<WorkLabel>(label.Id, label);

                WorkLabels.Remove(label);
                Employees.Remove(SelectedEmployee);
                Employees.Add(SelectedEmployee);
                SelectedEmployee = null;
            }
        }

        public async void RemoveWorkLabel(WorkLabel workLabel)
        {
            WorkLabels.Remove(workLabel); 
           await _bundleListViewDataService.Delete<WorkLabel>(workLabel.Id);
        }

        public void OpenEmployeeManageWorkLabel(Employee employee)
        {
            EmployeeManageWorkLabels employeeManageWorkLabels = new EmployeeManageWorkLabels(employee, _bundleListViewDataService, WorkLabels);
            employeeManageWorkLabels.ShowDialog();
        }
    }
}
