using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Starter.Data.Entities;

namespace Starter.Data.Interfaces.Services
{
    /// <summary>
    /// Defines the contract for Cat business logic
    /// </summary>
    public interface ICatService
    {
        Task<IEnumerable<Cat>> GetAllAsync();

        Task<Cat> GetByIdAsync(Guid id);

        Task SaveAsync(Cat entity);

        Task DeleteAsync(Cat entity);
    }
}