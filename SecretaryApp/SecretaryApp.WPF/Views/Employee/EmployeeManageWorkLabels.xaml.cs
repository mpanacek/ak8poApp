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
using System.Linq;


namespace SecretaryApp.WPF.Views.Employee
{
    public delegate void UpdateUi();

    /// <summary>
    /// Interaction logic for EmployeeManageWorkLabels.xaml
    /// </summary>
    /// 
    public partial class EmployeeManageWorkLabels : Window, INotifyPropertyChanged
    {
        public BundleListViewDataService _bundleListViewDataService { get; set; }

        public event UpdateUi UpdateUI;

        private ObservableCollection<WorkLabel> workLabels;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<WorkLabel> UnassignedWorkLabels;

        public RemoveWorkLabelCommand RemoveWorkLabelCommand { get; set; }

        private ObservableCollection<Domain.Models.Employee> employees;

        public ObservableCollection<Domain.Models.Employee> Employees
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

        public EmployeeManageWorkLabels(Domain.Models.Employee employee, BundleListViewDataService dataService,  
            ObservableCollection<WorkLabel> unassignedWorkLabels)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = this;

            _bundleListViewDataService = dataService;

            EmployeeToDisplay = employee;
            UnassignedWorkLabels = unassignedWorkLabels;

            WorkLabels = new ObservableCollection<WorkLabel>(EmployeeToDisplay.WorkLabels);
            fullNameLabel.Content = EmployeeToDisplay.FullName;
            workPointsDataLabel.Content = EmployeeToDisplay.WorkPoints;
            workPointsNoEngDataLabel.Content = EmployeeToDisplay.WorkPoints_NoEng;
            Employees = employees;
            UpdateUI += updateUI;
            
            
            RemoveWorkLabelCommand = new RemoveWorkLabelCommand(this);
        }


        public async void RemoveWorkLabel(WorkLabel parameter)
        {
            parameter.Employee = null;
            parameter.EmployeeId = null;
            WorkLabels.Remove(parameter);
            UnassignedWorkLabels.Add(parameter);

            await _bundleListViewDataService.Update<WorkLabel>(parameter.Id, parameter);

            List<WorkLabel> empWorkLabels = EmployeeToDisplay.WorkLabels.ToList();
            empWorkLabels.Remove(parameter);

            EmployeeToDisplay.WorkLabels = empWorkLabels;
            UpdateUI?.Invoke();
        }

        private void updateUI()
        {
            workPointsDataLabel.Content = EmployeeToDisplay.WorkPoints;
            workPointsNoEngDataLabel.Content = EmployeeToDisplay.WorkPoints_NoEng;
        }
        
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
