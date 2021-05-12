using Microsoft.EntityFrameworkCore;
using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretaryApp.EntityFramework.Services
{
    public class EmployeeDataService : IDataService<Employee>
    {
        private readonly SecretaryAppDbContextFactory _contextFactory;
        private readonly GenericDataService<Employee> _genericDataService;

        public EmployeeDataService(SecretaryAppDbContextFactory contextFactory, GenericDataService<Employee> genericDataService)
        {
            _contextFactory = contextFactory;
            _genericDataService = genericDataService;
        }

        public async Task<Employee> Create(Employee entity)
        {
            return await _genericDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericDataService.Delete(id);
        }

        public async Task<Employee> Get(int id)
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                Employee entity = await context.Set<Employee>()
                    .Include(e => e.WorkLabels)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Employee> entities = await context.Set<Employee>()
                    .Include(e => e.WorkLabels)
                    .ToListAsync();

                return entities;
            }
        }

        public async Task<Employee> Update(int id, Employee entity)
        {
            return await _genericDataService.Update(id, entity);
        }
    }
}
