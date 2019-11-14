using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Framework.Clients
{
    public interface IApiClient
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task AddAsync<T>(T entity);

        Task UpdateAsync<T>(T entity);

        Task DeleteAsync(Guid id);
    }
}