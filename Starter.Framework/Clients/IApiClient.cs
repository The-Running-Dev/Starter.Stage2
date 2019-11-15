using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Starter.Framework.Clients
{
    public interface IApiClient
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(Guid id);

        Task CreateAsync<T>(T entity);

        Task UpdateAsync<T>(T entity);

        Task DeleteAsync(Guid id);
    }
}