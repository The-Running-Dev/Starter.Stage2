using System;

using Starter.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Starter.Data.Repositories
{
    /// <summary>
    /// Defines the contract for base repository functions
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        //Task<IEnumerable<TEntity>> ExecuteQueryAsync(string sql, IDbDataParameter[] parameters = null);

        //Task ExecuteNonQueryAsync(string sql, IDbDataParameter[] parameters = null);

        //Task<IEnumerable<TEntity>> ExecuteReader(IDbCommand command);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Guid id);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid id);
    }
}