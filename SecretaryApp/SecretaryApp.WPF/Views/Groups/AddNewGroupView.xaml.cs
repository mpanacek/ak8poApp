using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SecretaryApp.WPF.Views.Groups
{
    /// <summary>
    /// Interaction logic for AddNewGroupView.xaml
    /// </summary>
    public partial class AddNewGroupView : Window
    {
        public IDataService<Group> _groupService { get; set; }
        public ObservableCollection<Group> Groups { get; set; }

        public AddNewGroupView(IDataService<Group> dataService, ObservableCollection<Group> groups)
        {
            InitializeComponent();

            semesterComboBox.ItemsSource = Enum.GetValues(typeof(Semester)).Cast<Semester>();
            studyFormComboBox.ItemsSource = Enum.GetValues(typeof(StudyForm)).Cast<StudyForm>();
            studyTypeComboBox.ItemsSource = Enum.GetValues(typeof(StudyType)).Cast<StudyType>();
            languageComboBox.ItemsSource = Enum.GetValues(typeof(Language)).Cast<Language>();

            Groups = groups;
            _groupService = dataService;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Group group = new Group();

            if(shortcutTextBox.Text != "" && nameTextBox.Text != "" && numberOfStudentsTextBox.Text != "")
            {
                group.Name = nameTextBox.Text;
                group.Shortcut = shortcutTextBox.Text;
                group.NumberOfStudents = int.Parse(numberOfStudentsTextBox.Text);
                group.Semester = (Semester)semesterComboBox.SelectedItem;
                group.StudyForm = (StudyForm)studyFormComboBox.SelectedItem;
                group.StudyType = (StudyType)studyTypeComboBox.SelectedItem;
                group.Language = (Language)languageComboBox.SelectedItem;

                _groupService.Create(group);
                Groups.Add(group);
                Close();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
