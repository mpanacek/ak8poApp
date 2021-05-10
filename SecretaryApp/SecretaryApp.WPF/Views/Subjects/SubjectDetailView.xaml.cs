using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace SecretaryApp.WPF.Views.Subjects
{
    /// <summary>
    /// Interaction logic for SubjectDetailView.xaml
    /// </summary>
    public partial class SubjectDetailView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Group> groupsAssignedToSubject;
        public ObservableCollection<Group> GroupsAssignedToSubject 
        {
            get 
            { 
                return groupsAssignedToSubject; 
            }
            set 
            { 
                groupsAssignedToSubject = value;
                OnPropertyChanged(nameof(GroupsAssignedToSubject));
            }
        }


        public IDataService<Subject> _subjectService { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public Subject SubjectToDisplay { get; set; }

        public SubjectDetailView(Subject subject, SecretaryAppDbContextFactory _context, ObservableCollection<Subject> subjects)
        {
            DataContext = this;
            InitializeComponent();

            _subjectService = new SubjectDataService(_context, new GenericDataService<Subject>(_context));
            SubjectToDisplay = subject;

            if (SubjectToDisplay.Groups != null)
                GroupsAssignedToSubject = new ObservableCollection<Group>(SubjectToDisplay?.Groups);
            else GroupsAssignedToSubject = new ObservableCollection<Group>();

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
            AddGroupToSubjectView addGroupToSubjectView = new AddGroupToSubjectView(new SecretaryAppDbContextFactory(), SubjectToDisplay, GroupsAssignedToSubject);

            addGroupToSubjectView.Show();
        }
    }
}
