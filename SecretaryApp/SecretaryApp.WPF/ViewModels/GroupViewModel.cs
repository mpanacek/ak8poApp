﻿using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework;
using SecretaryApp.EntityFramework.Services;
using SecretaryApp.WPF.Commands.Groups;
using SecretaryApp.WPF.Views.Groups;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SecretaryApp.WPF.ViewModels
{
    public class GroupViewModel : ViewModelBase 
    {
        public IDataService<Group> _groupService { get; set; }

        public AddGroupCommand AddGroupCommand { get; set; }
        public OpenGroupDetailCommand OpenGroupDetailCommand { get; set; }


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

        public GroupViewModel(SecretaryAppDbContextFactory _context)
        {
            _groupService = new GenericDataService<Group>(_context);
            AddGroupCommand = new AddGroupCommand(this);
            OpenGroupDetailCommand = new OpenGroupDetailCommand(this);

            LoadGroups();
        }

        public async void LoadGroups()
        {
            IEnumerable<Group> entities = await _groupService.GetAll();
            Groups = new ObservableCollection<Group>(entities);
        }


        public void AddNewGroup()
        {
            AddNewGroupView addNewGroupView = new AddNewGroupView(new SecretaryAppDbContextFactory(), Groups);

            addNewGroupView.Height = 450;
            addNewGroupView.Width = 850;
            addNewGroupView.Show();
        }

        public void OpenGroupDetail(Group group)
        {
            GroupDetailView groupDetailView = new GroupDetailView(group, new SecretaryAppDbContextFactory(), Groups);

            groupDetailView.Height = 450;
            groupDetailView.Width = 850;
            groupDetailView.Show();
        }
    }
}
