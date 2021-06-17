using SecretaryApp.Domain.Models;
using SecretaryApp.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SecretaryApp.WPF.Views.Validation;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.ViewModels;
using SecretaryApp.WPF.State.Navigators;
using System.Collections.ObjectModel;

namespace SecretaryApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddNewEmployeeView.xaml
    /// </summary>
    public partial class AddNewEmployeeView : Window
    {
        public IDataService<Domain.Models.Employee> _employeeService { get; set; }

        ObservableCollection<Domain.Models.Employee> Employees;
        public AddNewEmployeeView(IDataService<Domain.Models.Employee> dataService, ObservableCollection<Domain.Models.Employee> employees)
        {
            _employeeService = dataService;
            Employees = employees;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private int text;

        public int Text
        {
            get { return text; }
            set { text = value; }
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Domain.Models.Employee employee = new Domain.Models.Employee();

            if(nameTextBox.Text != "" && surnameTextBox.Text != "" && workingTimeTextBox.Text != "" && int.Parse(workingTimeTextBox.Text) > 0 && int.Parse(workingTimeTextBox.Text) <= 100  && workMailTextBox.Text != ""
                && privateMailTextBox.Text != "" && privatePhoneTextBox.Text != "" && workPhoneTextBox.Text != "")
            {
                employee.Name = nameTextBox.Text.ToString();
                employee.Surname = surnameTextBox.Text.ToString();
                employee.FullName = employee.Name + " " + employee.Surname;
                employee.WorkEmail = workMailTextBox.Text.ToString();
                employee.PersonalEmail = privateMailTextBox.Text.ToString();
                employee.WorkPhone = workPhoneTextBox.Text.ToString();
                employee.PersonalPhone = privatePhoneTextBox.Text.ToString();
                employee.DoctoralStudent = (bool)doktorantCheckBox.IsChecked;
                employee.WorkingTime = int.Parse(workingTimeTextBox.Text.ToString());

                _employeeService.Create(employee);
                Employees.Add(employee);

                Close();
            }

            
        }
    }
}
