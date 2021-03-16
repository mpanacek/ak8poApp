using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretaryApp.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T entity);

        Task<bool> Delete(int id);
    }
}
