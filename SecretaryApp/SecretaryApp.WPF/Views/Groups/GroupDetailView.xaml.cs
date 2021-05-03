using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace SecretaryApp.WPF.Views.Groups
{
    /// <summary>
    /// Interaction logic for GroupDetailView.xaml
    /// </summary>
    public partial class GroupDetailView : Window
    {
        public IDataService<Group> _groupService { get; set; }
        public ObservableCollection<Group> Groups { get; set; }

        public Group GroupToDisplay { get; set; }

        public GroupDetailView(Group group, SecretaryAppDbContextFactory _context, ObservableCollection<Group> groups)
        {
            InitializeComponent();

            _groupService = new GenericDataService<Group>(_context);
            GroupToDisplay = group;
            Groups = groups;

            headingDataLabel.Content = GroupToDisplay.Name;
            shortcutDataLabel.Content = GroupToDisplay.Shortcut;
            nameDataLabel.Content = GroupToDisplay.Name;
            numberOfStudentsDataLabel.Content = GroupToDisplay.NumberOfStudents;
            semesterDataLabel.Content = GroupToDisplay.Semester.ToString();
            studyFormDataLabel.Content = GroupToDisplay.StudyForm.ToString();
            studyTypeDataLabel.Content = GroupToDisplay.StudyType.ToString();
            languageDataLabel.Content = GroupToDisplay.Language.ToString();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            _groupService.Delete(GroupToDisplay.Id);
            Groups.Remove(GroupToDisplay);
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
