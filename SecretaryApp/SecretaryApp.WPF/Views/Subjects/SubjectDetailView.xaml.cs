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
    /// Interaction logic for SubjectDetailView.xaml
    /// </summary>
    public partial class SubjectDetailView : Window
    {
        public IDataService<Subject> _subjectService { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }

        public Subject SubjectToDisplay { get; set; }

        public SubjectDetailView(Subject subject, SecretaryAppDbContextFactory _context, ObservableCollection<Subject> subjects)
        {
            InitializeComponent();

            _subjectService = new GenericDataService<Subject>(_context);
            SubjectToDisplay = subject;

            Subjects = subjects;

            HeadingDataLabel.Content = SubjectToDisplay.Name;
            shortcutDataLabel.Content = SubjectToDisplay.Id;
            nameName.Content = SubjectToDisplay.Name;
            numberOfCreditsDataLabel.Content = SubjectToDisplay.NumberOfCredits;
            numberOfWeeksDataLabel.Content = SubjectToDisplay.NumberOfWeeks;
            hoursOfLecturesDataLabel.Content = SubjectToDisplay.HoursOfLectures;
            hoursOfExcercisesDataLabel.Content = SubjectToDisplay.HoursOfExcercises;
            classSizeDataLabel.Content = SubjectToDisplay.ClassSize;
            endingDataLabel.Content = SubjectToDisplay.WayOfCompletion.ToString();
            languageDataLabel.Content = SubjectToDisplay.Language.ToString();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            _subjectService.Delete(SubjectToDisplay.Id);

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
