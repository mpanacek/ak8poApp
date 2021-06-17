using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Logic;
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
using System.Windows.Shapes;

namespace SecretaryApp.WPF.Views.Groups
{
    /// <summary>
    /// Interaction logic for EditGroupView.xaml
    /// </summary>
    public partial class EditGroupView : Window
    {
        private IDataService<Group> _groupService { get; set; }
        private IDataService<WorkLabel> _workLabelService { get; set; }
        public Group GroupToEdit { get; set; }

        public List<WorkLabel> NewWorkLabels { get; set; }
        public EditGroupView(IDataService<Group> dataService, SecretaryAppDbContextFactory _context, Group group)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _groupService = dataService;
            _workLabelService = new WorkLabelDataService(_context, new GenericDataService<WorkLabel>(_context));

            GroupToEdit = group;

            headingLabel.Content = GroupToEdit;
            shortcutTextBox.Text = GroupToEdit.Shortcut;
            shortcutTextBox.IsEnabled = false;

            nameTextBox.Text = GroupToEdit.Name;
            numberOfStudentsTextBox.Text = GroupToEdit.NumberOfStudents.ToString();

            semesterComboBox.ItemsSource = Enum.GetValues(typeof(Semester)).Cast<Semester>();
            semesterComboBox.SelectedItem = GroupToEdit.Semester;

            studyFormComboBox.ItemsSource = Enum.GetValues(typeof(StudyForm)).Cast<StudyForm>();
            studyFormComboBox.SelectedItem = GroupToEdit.StudyForm;

            studyTypeComboBox.ItemsSource = Enum.GetValues(typeof(StudyType)).Cast<StudyType>();
            studyTypeComboBox.SelectedItem = GroupToEdit.StudyType;

            languageComboBox.ItemsSource = Enum.GetValues(typeof(Language)).Cast<Language>();
            languageComboBox.SelectedItem = GroupToEdit.Language;
        }

        public async void SaveEditedGroup(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != "" && numberOfStudentsTextBox.Text != "")
            {
                GroupToEdit.Name = nameTextBox.Text;
                GroupToEdit.Shortcut = shortcutTextBox.Text;

                IEnumerable<WorkLabel> oldWorkLabels = await _workLabelService.GetAll();

                int newNumberOfStudents = int.Parse(numberOfStudentsTextBox.Text);
                if (GroupToEdit.NumberOfStudents != newNumberOfStudents)
                {
                    Subject subject = GroupToEdit.Subject;

                    if(subject!= null)
                    {
                       NewWorkLabels = WorkLabelAlgorithm.Instance.RecalculationAlgorithm(subject, newNumberOfStudents, oldWorkLabels);
                    }
                }

                GroupToEdit.NumberOfStudents = int.Parse(numberOfStudentsTextBox.Text);
                GroupToEdit.Semester = (Semester)semesterComboBox.SelectedItem;
                GroupToEdit.StudyForm = (StudyForm)studyFormComboBox.SelectedItem;
                GroupToEdit.StudyType = (StudyType)studyTypeComboBox.SelectedItem;
                GroupToEdit.Language = (Language)languageComboBox.SelectedItem;

                await _groupService.Update(GroupToEdit.Id, GroupToEdit);

                foreach (var workLabel in NewWorkLabels)
                {
                    await _workLabelService.Update(workLabel.Id, workLabel);
                }

                Close();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
