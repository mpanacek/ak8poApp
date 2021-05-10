using SecretaryApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecretaryApp.Domain.Services;

namespace SecretaryApp.EntityFramework.Services
{
    public class GroupDataService : IDataService<Group>
    {
        private readonly SecretaryAppDbContextFactory _contextFactory;
        private readonly GenericDataService<Group> _genericDataService;

        public GroupDataService(SecretaryAppDbContextFactory contextFactory, GenericDataService<Group> genericDataService)
        {
            _contextFactory = contextFactory;
            _genericDataService = genericDataService;
        }

        public async Task<Group> Create(Group entity)
        {
           return await _genericDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _genericDataService.Delete(id);
        }

        public async Task<Group> Get(int id)
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                Group entity = await context.Set<Group>()
                    .Include(g => g.Subject)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            using (SecretaryAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Group> entities = await context.Set<Group>()
                    .Include(g => g.Subject)
                    .ToListAsync();

                return entities;
            }
        }

        public async Task<Group> Update(int id, Group entity)
        {
            return await _genericDataService.Update(id, entity);
        }
    }
}
