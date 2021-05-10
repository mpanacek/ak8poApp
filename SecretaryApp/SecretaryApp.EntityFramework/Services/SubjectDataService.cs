using Microsoft.EntityFrameworkCore;
using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretaryApp.EntityFramework.Services
{
    public class SubjectDataService : IDataService<Subject>
    {
        private readonly SecretaryAppDbContextFactory _contextFactory;
        private readonly GenericDataService<Subject> _genericDataService;

        public SubjectDataService(SecretaryAppDbContextFactory contextFactory, GenericDataService<Subject> genericDataService)
        {
            _contextFactory = contextFactory;
            _genericDataService = genericDataService;
        }

        public async Task<Subject> Create(Subject entity)
        {
            return await _genericDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericDataService.Delete(id);
        }

        public async Task<Subject> Get(int id)
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                Subject entity = await context.Set<Subject>()
                    .Include(s => s.Groups)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Subject> entities = await context.Set<Subject>()
                    .Include(s => s.Groups)
                    .ToListAsync();

                return entities;
            }
        }

        public async Task<Subject> Update(int id, Subject entity)
        {
            return await _genericDataService.Update(id, entity);
        }
    }
}
