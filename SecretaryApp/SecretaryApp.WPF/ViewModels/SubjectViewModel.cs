using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands.Subject;
using SecretaryApp.WPF.Commands.Subjects;
using SecretaryApp.WPF.Views.Subjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SecretaryApp.WPF.ViewModels
{
    public class SubjectViewModel : ViewModelBase
    {
        public IDataService<Subject> _subjectService { get; set; }

        public AddSubjectCommand AddSubjectCommand { get; set; }
        public OpenSubjectDetailCommand OpenSubjectDetailCommand { get; set; }
        public EditSubjectCommand EditSubjectCommand { get; set; }


        private ObservableCollection<Subject> subjects;

        public ObservableCollection<Subject> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        public void EditSubject(Subject subject)
        {
            EditSubjectView editSubjectView = new EditSubjectView(_subjectService, subject);

            editSubjectView.Show();
        }

        public SubjectViewModel(SecretaryAppDbContextFactory _context)
        {
            _subjectService = new SubjectDataService(_context, new GenericDataService<Subject>(_context));
            AddSubjectCommand = new AddSubjectCommand(this);
            OpenSubjectDetailCommand = new OpenSubjectDetailCommand(this);
            EditSubjectCommand = new EditSubjectCommand(this);

            LoadSubjects();
        }

        public async void LoadSubjects()
        {
            IEnumerable<Subject> entities = await _subjectService.GetAll();
            Subjects = new ObservableCollection<Subject>(entities);
        }

        public void AddNewSubject()
        {
            AddNewSubjectView addNewSubjectView = new AddNewSubjectView(_subjectService, Subjects);

            addNewSubjectView.Height = 450;
            addNewSubjectView.Width = 850;
            addNewSubjectView.Show();
        }

        public void OpenSubjectDetail(Subject subject)
        {
            SubjectDetailView subjectDetailView = new SubjectDetailView(subject, _subjectService, Subjects);

            subjectDetailView.Height = 450;
            subjectDetailView.Width = 850;
            subjectDetailView.Show();
        }
    }
}
