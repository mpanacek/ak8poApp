using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands.Subjects;
using System;
using System.Linq;
using System.Windows;

namespace SecretaryApp.WPF.Views.Subjects
{
    /// <summary>
    /// Interaction logic for EditSubjectView.xaml
    /// </summary>
    public partial class EditSubjectView : Window
    {
        private IDataService<Subject> _subjectService { get; set; }
        public Subject SubjectToEdit { get; set; }

        public EditSubjectView(IDataService<Subject> dataService, Subject subject)
        {
            DataContext = this;
            InitializeComponent();

            _subjectService = dataService;

            SubjectToEdit = subject;
            headingDataLabel.Content = SubjectToEdit.Name;

            shortcutTextBox.Text = SubjectToEdit.Shortcut;
            shortcutTextBox.IsEnabled = false;

            nameTextBox.Text = SubjectToEdit.Name;
            numberOfCreditsTextBox.Text = SubjectToEdit.NumberOfCredits.ToString();

            hoursOfLecturesTextBox.Text = SubjectToEdit.HoursOfLectures.ToString();
            hoursOfExcercisesTextBox.Text = SubjectToEdit.HoursOfExcercises.ToString();

            classSizeTextBox.Text = SubjectToEdit.ClassSize.ToString();
            numberOfWeeksTextBox.Text = SubjectToEdit.NumberOfWeeks.ToString();

            endingComboBox.ItemsSource = Enum.GetValues(typeof(WayOfCompletion)).Cast<WayOfCompletion>();
            endingComboBox.SelectedItem = SubjectToEdit.WayOfCompletion;

            languageComboBox.ItemsSource = Enum.GetValues(typeof(Language)).Cast<Language>();
            languageComboBox.SelectedItem = SubjectToEdit.Language;
        }

        public void SaveEditedSubject(object sender, RoutedEventArgs e)
        {
            if (shortcutTextBox.Text != "" && nameTextBox.Text != "" && numberOfCreditsTextBox.Text != "" && numberOfWeeksTextBox.Text != "" && hoursOfLecturesTextBox.Text != ""
                && hoursOfExcercisesTextBox.Text != "" && classSizeTextBox.Text != "")
            {
                SubjectToEdit.Name = nameTextBox.Text;
                SubjectToEdit.NumberOfCredits = int.Parse(numberOfCreditsTextBox.Text);
                SubjectToEdit.NumberOfWeeks = int.Parse(numberOfWeeksTextBox.Text);
                SubjectToEdit.HoursOfLectures = int.Parse(hoursOfLecturesTextBox.Text);
                SubjectToEdit.HoursOfExcercises = int.Parse(hoursOfExcercisesTextBox.Text);

                if(SubjectToEdit.ClassSize != int.Parse(classSizeTextBox.Text))
                {
                    //recalculate number of students in the work labels
                }

                SubjectToEdit.ClassSize = int.Parse(classSizeTextBox.Text);
                SubjectToEdit.WayOfCompletion = (WayOfCompletion)endingComboBox.SelectedItem;
                SubjectToEdit.Language = (Language)languageComboBox.SelectedItem;

                _subjectService.Update(SubjectToEdit.Id, SubjectToEdit);
                Close();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
