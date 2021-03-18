using Microsoft.EntityFrameworkCore;
using SecretaryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretaryApp.EntityFramework
{
    class SecretaryAppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGroups> SubjectGroups { get; set; }
        public DbSet<WeightsOfWorkPoints> WeightsOfWorkPoints { get; set; }
        public DbSet<WorkLabel> WorkLabels { get; set; }

        public SecretaryAppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
