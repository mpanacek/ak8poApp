using Microsoft.EntityFrameworkCore;
using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretaryApp.EntityFramework.Services
{
    public class WorkLabelDataService : IDataService<WorkLabel>
    {
        private readonly SecretaryAppDbContextFactory _contextFactory;
        private readonly GenericDataService<WorkLabel> _genericDataService;

        public WorkLabelDataService(SecretaryAppDbContextFactory contextFactory, GenericDataService<WorkLabel> genericDataService)
        {
            _contextFactory = contextFactory;
            _genericDataService = genericDataService;
        }

        public async Task<WorkLabel> Create(WorkLabel entity)
        {
            return await _genericDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericDataService.Delete(id);
        }

        public async Task<WorkLabel> Get(int id)
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                WorkLabel entity = await context.Set<WorkLabel>()
                    .Include(w => w.Subject)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<WorkLabel>> GetAll()
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<WorkLabel> entities = await context.Set<WorkLabel>()
                    .Include(w => w.Subject)
                    .ToListAsync();

                return entities;
            }
        }

        public async Task<WorkLabel> Update(int id, WorkLabel entity)
        {
            return await _genericDataService.Update(id, entity);
        }
    }
}
