using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands.Employees;
using SecretaryApp.WPF.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SecretaryApp.WPF.Views.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeManageWorkLabels.xaml
    /// </summary>
    public partial class EmployeeManageWorkLabels : Window, INotifyPropertyChanged
    {
        IDataService<Domain.Models.Employee> _employeeDataService { get; set; }
       // IDataService<WorkLabel> _workLabelDataService { get; set; }

        private ObservableCollection<WorkLabel> workLabels;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<WorkLabel> UnassignedWorkLabels;

        public RemoveWorkLabelCommand RemoveWorkLabelCommand { get; set; }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<WorkLabel> WorkLabels
        {
            get { return workLabels; }
            set 
            { 
                workLabels = value;
                OnPropertyChanged(nameof(WorkLabels));
            }
        }

        public Domain.Models.Employee EmployeeToDisplay { get; set; }

        public EmployeeManageWorkLabels(Domain.Models.Employee employee, SecretaryAppDbContextFactory _context, ObservableCollection<WorkLabel> unassignedWorkLabels)
        {
            InitializeComponent();

            DataContext = this;
            
            _employeeDataService = new EmployeeDataService(_context, new GenericDataService<Domain.Models.Employee>(_context));
          //  _workLabelDataService = new WorkLabelDataService(_context, new GenericDataService<WorkLabel>(_context));

            EmployeeToDisplay = employee;
            UnassignedWorkLabels = unassignedWorkLabels;

            WorkLabels = new ObservableCollection<WorkLabel>(EmployeeToDisplay.WorkLabels);
            fullNameLabel.Content = EmployeeToDisplay.FullName;
            workPointsDataLabel.Content = EmployeeToDisplay.WorkPoints;
            workPointsNoEngDataLabel.Content = EmployeeToDisplay.WorkPoints_NoEng;

            RemoveWorkLabelCommand = new RemoveWorkLabelCommand(this);
        }


        public void RemoveWorkLabel(WorkLabel parameter)
        {
            parameter.Employee = null;
            WorkLabels.Remove(parameter);
            UnassignedWorkLabels.Add(parameter);

            workPointsDataLabel.Content = EmployeeToDisplay.WorkPoints;
            workPointsNoEngDataLabel.Content = EmployeeToDisplay.WorkPoints_NoEng;

            WorkLabelAlgorithm.Instance._workLabelService.Update(parameter.Id, parameter);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
