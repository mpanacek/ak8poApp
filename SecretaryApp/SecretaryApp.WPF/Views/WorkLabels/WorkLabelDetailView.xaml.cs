using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework.Services;
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

namespace SecretaryApp.WPF.Views.WorkLabels
{
    /// <summary>
    /// Interaction logic for WorkLabelDetailView.xaml
    /// </summary>
    public partial class WorkLabelDetailView : Window
    {
        
        private IDataService<WorkLabel> _workLabelService;

        public WorkLabel CurrentWorkLabel { get; set; }

        public ObservableCollection<WorkLabel> WorkLabels { get; set; }

        public WorkLabelDetailView(WorkLabel workLabel, IDataService<WorkLabel> serivce, ObservableCollection<WorkLabel> workLabels)
        {
            InitializeComponent();

            CurrentWorkLabel = workLabel;
            _workLabelService = serivce;
            WorkLabels = workLabels;

            if (CurrentWorkLabel.Name == null)
                headerLabel.Content = "Názov sa nenašiel";
            else headerLabel.Content = CurrentWorkLabel.Name;

            numberOfStudentsDataLabel.Content = CurrentWorkLabel.NumberOfStudents;
            numberOfHoursDataLabel.Content = CurrentWorkLabel.NumberOfHours;
            numberOfWeeksDataLabel.Content = CurrentWorkLabel.NumberOfWeeks;

            if (CurrentWorkLabel.Employee == null)
                responsibleEmployeeDataLabel.Content = "Žiadny";
            else responsibleEmployeeDataLabel.Content = CurrentWorkLabel.Employee.FullName;

            if (CurrentWorkLabel.Subject == null)
                SubjectDataLabelDataLabel.Content = "Žiadny";
            else SubjectDataLabelDataLabel.Content = CurrentWorkLabel.Subject.Name;

            languageDataLabel.Content = CurrentWorkLabel.Language;
            workPointsDataLabel.Content = CurrentWorkLabel.NumberOfPoints;
        }



        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            WorkLabels.Remove(CurrentWorkLabel);

            _workLabelService.Delete(CurrentWorkLabel.Id);
            Close();
        }
    }
}
