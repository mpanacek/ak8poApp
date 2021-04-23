using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IDataService<Employee> _employeeService { get; set; }

        public List<Employee> Employees { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _employeeService = new GenericDataService<Employee>(new SecretaryAppDbContextFactory());
            Employees = _employeeService.GetAll().Result.ToList();
        }
    }
}
