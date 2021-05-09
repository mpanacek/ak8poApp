using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SecretaryApp.WPF.Views.Subjects
{
    /// <summary>
    /// Interaction logic for SubjectDetailView.xaml
    /// </summary>
    public partial class SubjectDetailView : Window
    {
        public IDataService<Subject> _subjectService { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public ObservableCollection<Group> GroupsAssignedToSubject { get; set; }
        public List<SubjectGroups>? SubjectGroupsList { get; private set; }
        public Subject SubjectToDisplay { get; set; }

        public SubjectDetailView(Subject subject, SecretaryAppDbContextFactory _context, ObservableCollection<Subject> subjects)
        {
            InitializeComponent();

            _subjectService = new GenericDataService<Subject>(_context);
            SubjectToDisplay = subject;
            SubjectGroupsList = subject.SubjectGroups?.ToList();

            if(SubjectGroupsList != null)
            {
                foreach (var subjectGroup in SubjectGroupsList)
                {
                    GroupsAssignedToSubject.Add(subjectGroup.Group);
                }
            }
            

            Subjects = subjects;
            HeadingDataLabel.Content = SubjectToDisplay.Name;
            shortcutDataLabel.Content = SubjectToDisplay.Shortcut;
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
            Subjects.Remove(SubjectToDisplay);

            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addGroup_Click(object sender, RoutedEventArgs e)
        {
            AddGroupToSubjectView addGroupToSubjectView = new AddGroupToSubjectView();

            addGroupToSubjectView.Show();
        }
    }
}
