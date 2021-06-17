using Microsoft.EntityFrameworkCore;
using SecretaryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretaryApp.EntityFramework
{
    public class SecretaryAppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
      //  public DbSet<SubjectGroups> SubjectGroups { get; set; }
        public DbSet<WorkLabel> WorkLabels { get; set; }

        public SecretaryAppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subject>()
                .HasMany<WorkLabel>(s => s.WorkLabels)
                .WithOne(w => w.Subject)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>()
               .HasMany<Group>(s => s.Groups)
               .WithOne(g => g.Subject)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
               .HasMany<WorkLabel>(e => e.WorkLabels)
               .WithOne(w => w.Employee)
               .OnDelete(DeleteBehavior.SetNull);


            //modelBuilder.Entity<SubjectGroups>()
            //    .HasKey(c => new { c.GroupId, c.SubjectId });
        }

    }
}
