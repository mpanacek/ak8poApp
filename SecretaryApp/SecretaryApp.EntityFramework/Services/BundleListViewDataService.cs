using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SecretaryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryApp.EntityFramework.Services
{
    public class BundleListViewDataService
    {

        private readonly SecretaryAppDbContextFactory _contextFactory;

        public BundleListViewDataService(SecretaryAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create<T>(T entity) where T : DomainObject
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete<T>(int id) where T : DomainObject
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get<T>(int id) where T : DomainObject
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : DomainObject
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> Update<T>(int id, T entity) where T : DomainObject
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                var entityState = context.Set<T>().Update(entity).State;


                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Employee> entities = await context.Set<Employee>()
                    .Include(e => e.WorkLabels)
                    .ToListAsync();

                return entities;
            }
        }

        public async Task<IEnumerable<WorkLabel>> GetAllWorkLabels()
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<WorkLabel> entities = await context.Set<WorkLabel>()
                    .Include(w => w.Subject)
                    .Include(w => w.Employee)
                    .AsNoTracking()
                    .ToListAsync();

                return entities;
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                Employee entity = await context.Set<Employee>()
                    .Include(e => e.WorkLabels)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }
    }
}
