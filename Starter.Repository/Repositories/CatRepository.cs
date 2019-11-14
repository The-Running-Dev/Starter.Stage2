using System;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using Starter.Data.Entities;
using Starter.Data.Connections;
using Starter.Data.Repositories;

namespace Starter.Repository.Repositories
{
    public class CatRepository : Repository, ICatRepository
    {
        public CatRepository(IConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<Cat>> GetAllAsync()
        {
            return await ExecuteQueryAsync<Cat>(GetAllSp);
        }

        public async Task<Cat> GetByIdAsync(Guid id)
        {
            var entities = await ExecuteQueryAsync<Cat>(GetByIdSp, new[] { new SqlParameter("id", id) });

            return entities.FirstOrDefault();
        }

        public async Task AddAsync(Cat entity)
        {
            await ExecuteNonQueryAsync(AddSp, new[]
            {
                new SqlParameter("name", entity.Name),
                new SqlParameter("abilityId", entity.AbilityId)
            });
        }

        public async Task UpdateAsync(Cat entity)
        {
            await ExecuteNonQueryAsync(UpdateSp, new[]
            {
                new SqlParameter("id", entity.Id),
                new SqlParameter("name", entity.Name),
                new SqlParameter("abilityId", entity.AbilityId)
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            await ExecuteNonQueryAsync(DeleteSp, new[]
            {
                new SqlParameter("id", id)
            });
        }

        private readonly string GetAllSp = "GetAllCats";

        private readonly string GetByIdSp = "GetCatById";

        private readonly string AddSp = "AddCat";

        private readonly string UpdateSp = "UpdateCat";

        private readonly string DeleteSp = "DeleteCat";
    }
}