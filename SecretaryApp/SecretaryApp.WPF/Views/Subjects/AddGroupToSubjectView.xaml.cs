using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands.Subject;
using SecretaryApp.WPF.Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace SecretaryApp.WPF.Views.Subjects
{
    /// <summary>
    /// Interaction logic for AddGroupToSubjectView.xaml
    /// </summary>
    public partial class AddGroupToSubjectView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Group> groups;

        public ObservableCollection<Group> Groups
        {
            get
            {
                return groups;
            }
            set
            {
                groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }

        public IDataService<Group> _groupService { get; set; }
        public IDataService<Subject> _subjectService { get; set; }
        public IDataService<WorkLabel> _workLabelService { get; set; }

        public ObservableCollection<Group> SubjectGroups { get; set; }
        public Subject CurrentSubject { get; set; }
        public AddGroupTosubjectCommand AddGroupTosubjectCommand { get; set; }
        public List<WorkLabel> NewWorkLabels { get; set; }

        public AddGroupToSubjectView(IDataService<Subject> dataService, Subject subject, ObservableCollection<Group> subjectGroups)
        {
            DataContext = this;
            AddGroupTosubjectCommand = new AddGroupTosubjectCommand(this);
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SubjectGroups = subjectGroups;
            CurrentSubject = subject;
            var _context = new SecretaryAppDbContextFactory();

            _groupService = new GroupDataService(_context, new GenericDataService<Group>(_context));
            _subjectService = dataService;
            _workLabelService = new WorkLabelDataService(_context, new GenericDataService<WorkLabel>(_context));

            LoadGroups();
        }

        public async void LoadGroups()
        {
            IEnumerable<Group> groupEntities = await _groupService.GetAll();
            Groups = new ObservableCollection<Group>(
                groupEntities.Where(g =>
                {
                    if (g.Subject != null)
                        return g.Subject.Id != CurrentSubject.Id;
                    return true;
                }));
        }

        public void AddGroup(Group group)
        {
            Group selectedGroup = group;

            selectedGroup.Subject = CurrentSubject;

            if (CurrentSubject.Groups == null)
                CurrentSubject.Groups = new List<Group>();

            CurrentSubject.Groups.ToList().Add(selectedGroup);

            NewWorkLabels = WorkLabelAlgorithm.Instance.Algorithm(CurrentSubject, selectedGroup);

            Groups.Remove(selectedGroup);
            SubjectGroups.Add(selectedGroup);

            foreach (var workLabel in NewWorkLabels)
            {
                _workLabelService.Create(workLabel);
            }

            _groupService.Update(selectedGroup.Id, selectedGroup);
        }
    }
}
