using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SecretaryApp.WPF.Views.WorkLabels
{
    /// <summary>
    /// Interaction logic for AddWorkLabelView.xaml
    /// </summary>
    public partial class AddWorkLabelView : Window
    {
        public ObservableCollection<WorkLabel> WorkLabels { get; set; }

        private IDataService<WorkLabel> _workLabelService;

        public AddWorkLabelView(ObservableCollection<WorkLabel> workLabels, IDataService<WorkLabel> service)
        {
            InitializeComponent();

            WorkLabels = workLabels;
            _workLabelService = service;

            languageComboBox.ItemsSource = Enum.GetValues(typeof(Language)).Cast<Language>();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(nameTextBox.Text != "" && numberOfStudentsTextBox.Text != "" && numberOfHoursTextBox.Text != "" && numberOfWeeksTextBox.Text != "")
            {
                WorkLabel workLabel = new WorkLabel();

                workLabel.Name = nameTextBox.Text;
                workLabel.NumberOfStudents = int.Parse(numberOfStudentsTextBox.Text);
                workLabel.NumberOfHours = int.Parse(numberOfHoursTextBox.Text);
                workLabel.NumberOfWeeks = int.Parse(numberOfWeeksTextBox.Text);
                workLabel.Language = (Language)languageComboBox.SelectedItem;

                WorkLabels.Add(workLabel);
                _workLabelService.Create(workLabel);

                Close();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
