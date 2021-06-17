using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands.WorkLabels;
using SecretaryApp.WPF.Views.WorkLabels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SecretaryApp.WPF.ViewModels
{
    public class WorkLabelsViewModel : ViewModelBase
    {
        public IDataService<WorkLabel> _workLabelService { get; set; }

        public AddWorkLabelCommand AddWorkLabelCommand { get; set; }
        public OpenWorkLabelDetailCommand OpenWorkLabelDetailCommand { get; set; }

        public WorkLabelsViewModel(SecretaryAppDbContextFactory secretaryAppDbContextFactory)
        {
            _workLabelService = new WorkLabelDataService(secretaryAppDbContextFactory, new GenericDataService<WorkLabel>(secretaryAppDbContextFactory));

            AddWorkLabelCommand = new AddWorkLabelCommand(this);
            OpenWorkLabelDetailCommand = new OpenWorkLabelDetailCommand(this);

            LoadWorkLabels();
        }

        private ObservableCollection<WorkLabel> workLabels;

        public ObservableCollection<WorkLabel> WorkLabels
        {
            get
            {
                return workLabels;
            }
            set
            {
                workLabels = value;
                OnPropertyChanged(nameof(WorkLabels));
            }
        }

        public async void LoadWorkLabels()
        {
            IEnumerable<WorkLabel> entities = await _workLabelService.GetAll();
            WorkLabels = new ObservableCollection<WorkLabel>(entities);
        }

        public void AddNewWorkLabelWindow()
        {
            AddWorkLabelView workLabelsView = new AddWorkLabelView(WorkLabels, _workLabelService);
            workLabelsView.Show();
        }

        public void OpenWorkLabelDetail(WorkLabel parameter)
        {
            WorkLabelDetailView workLabelDetailView = new WorkLabelDetailView(parameter, _workLabelService, WorkLabels);
            workLabelDetailView.Show();
        }
    }
}