using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands.Groups;
using SecretaryApp.WPF.Views.Groups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SecretaryApp.WPF.ViewModels
{
    public class GroupViewModel : ViewModelBase 
    {
        public IDataService<Group> _groupService { get; set; }

        public AddGroupCommand AddGroupCommand { get; set; }
        public OpenGroupDetailCommand OpenGroupDetailCommand { get; set; }
        public OpenGroupViewCommand OpenGroupViewEditCommand { get; set; }

        private ObservableCollection<Group> groups;

        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set 
            { 
                groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }

        internal void OpenEditView(Group parameter)
        {
            EditGroupView editGroupView = new EditGroupView(_groupService, new SecretaryAppDbContextFactory(), parameter);
            editGroupView.Show();
        }

        public GroupViewModel(SecretaryAppDbContextFactory _context)
        {
            _groupService = new GroupDataService(_context, new GenericDataService<Group>(_context));
            AddGroupCommand = new AddGroupCommand(this);
            OpenGroupDetailCommand = new OpenGroupDetailCommand(this);
            OpenGroupViewEditCommand = new OpenGroupViewCommand(this);

            LoadGroups();
        }

        public async void LoadGroups()
        {
            IEnumerable<Group> entities = await _groupService.GetAll();
            Groups = new ObservableCollection<Group>(entities);
        }


        public void AddNewGroup()
        {
            AddNewGroupView addNewGroupView = new AddNewGroupView(_groupService, Groups);

            addNewGroupView.Height = 450;
            addNewGroupView.Width = 850;
            addNewGroupView.Show();
        }

        public void OpenGroupDetail(Group group)
        {
            GroupDetailView groupDetailView = new GroupDetailView(group, _groupService, Groups);

            groupDetailView.Height = 450;
            groupDetailView.Width = 850;
            groupDetailView.Show();
        }
    }
}
