using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
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

namespace SecretaryApp.WPF.Views.Subjects
{
    /// <summary>
    /// Interaction logic for AddNewSubjectView.xaml
    /// </summary>
    public partial class AddNewSubjectView : Window
    {
        public IDataService<Subject> _subjectService { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }

        public AddNewSubjectView(SecretaryAppDbContextFactory _context, ObservableCollection<Subject> subjects)
        {
            InitializeComponent();

            endingComboBox.ItemsSource = Enum.GetValues(typeof(WayOfCompletion)).Cast<WayOfCompletion>();
            languageComboBox.ItemsSource = Enum.GetValues(typeof(Language)).Cast<Language>();

            Subjects = subjects;
            _subjectService = new GenericDataService<Subject>(_context);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Subject subject = new Subject();

            if(shortcutTextBox.Text != "" && nameTextBox.Text != "" && numberOfCreditsTextBox.Text != "" && numberOfWeeksTextBox.Text != "" && hoursOfLecturesTextBox.Text != ""
                && hoursOfExcercisesTextBox.Text != "" && classSizeTextBox.Text != "")
            {
                foreach (var subjectItem in Subjects)
                {
                    if (subjectItem.Shortcut == shortcutTextBox.Text)
                        break;
                }

                subject.Shortcut = shortcutTextBox.Text;
                subject.Name = nameTextBox.Text;
                subject.NumberOfCredits = int.Parse(numberOfCreditsTextBox.Text);
                subject.NumberOfWeeks = int.Parse(numberOfWeeksTextBox.Text);
                subject.HoursOfLectures = int.Parse(hoursOfLecturesTextBox.Text);
                subject.HoursOfExcercises = int.Parse(hoursOfExcercisesTextBox.Text);
                subject.ClassSize = int.Parse(classSizeTextBox.Text);

                subject.WayOfCompletion = (WayOfCompletion)endingComboBox.SelectedItem;
                subject.Language = (Language)languageComboBox.SelectedItem;
            }

            _subjectService.Create(subject);
            Subjects.Add(subject);

            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
