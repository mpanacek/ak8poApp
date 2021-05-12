using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Logic;

namespace SecretaryApp.WPF.Views.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeDetail.xaml
    /// </summary>
    public partial class EmployeeDetail : Window
    {
        public Domain.Models.Employee EmployeeToDisplay { get; set; }

        public ObservableCollection<Domain.Models.Employee> Employees;
        public IDataService<Domain.Models.Employee> _employeeService { get; set; }

        public EmployeeDetail(Domain.Models.Employee employee, IDataService<Domain.Models.Employee> dataService, ObservableCollection<Domain.Models.Employee> employees)
        {
            InitializeComponent();


            EmployeeToDisplay = employee;

            fullNameLabel.Content = EmployeeToDisplay.FullName;
            nameDataLabel.Content = EmployeeToDisplay.Name;
            surnameDataLabel.Content = EmployeeToDisplay.Surname;
            workMailDataLabel.Content = EmployeeToDisplay.WorkEmail;
            privateMailDataLabel.Content = EmployeeToDisplay.PersonalEmail;
            workPhoneDataLabel.Content = EmployeeToDisplay.WorkPhone;
            privatePhoneDataLabel.Content = EmployeeToDisplay.PersonalPhone;
            privatePhoneDataLabel.Content = EmployeeToDisplay.PersonalPhone;
            doktorantCheckBox.IsChecked = EmployeeToDisplay.DoctoralStudent;
            workPhoneDataLabel.Content = EmployeeToDisplay.WorkPhone;
            workPointsNoEngDataLabel.Content = EmployeeToDisplay.WorkPoints_NoEng;
            workPointsDataLabel.Content = EmployeeToDisplay.WorkPoints;
            workingTimeDataLabel.Content = EmployeeToDisplay.WorkingTime;


            _employeeService = dataService;

            Employees = employees;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            _employeeService.Delete(EmployeeToDisplay.Id);

            Employees.Remove(EmployeeToDisplay);
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
