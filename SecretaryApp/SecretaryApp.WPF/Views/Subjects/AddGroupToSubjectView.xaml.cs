using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands.Subject;
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
        public ObservableCollection<Group> SubjectGroups { get; set; }
        public Subject CurrentSubject { get; set; }
        public AddGroupTosubjectCommand AddGroupTosubjectCommand { get; set; }


        public AddGroupToSubjectView(SecretaryAppDbContextFactory _context, Subject subject, ObservableCollection<Group> subjectGroups)
        {
            DataContext = this;
            AddGroupTosubjectCommand = new AddGroupTosubjectCommand(this);
            InitializeComponent();
            SubjectGroups = subjectGroups;
            CurrentSubject = subject;
            _groupService = new GroupDataService(_context, new GenericDataService<Group>(_context));
            _subjectService = new GenericDataService<Subject>(_context);
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

            Groups.Remove(selectedGroup);

            _groupService.Update(selectedGroup.Id, selectedGroup);
            _subjectService.Update(CurrentSubject.Id, CurrentSubject);
        }
    }
}
