using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using Starter.Data.Connections;
using Starter.Framework.Extensions;

namespace Starter.Repository.Repositories
{
    public class Repository
    {
        public Repository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, dynamic[] parameters = null)
        {
            try
            {
                using (var command = _connection.CreateSpCommand(sql, parameters))
                {
                    return await ExecuteReader<T>(command);
                }
            }
            catch
            {
                // Log the exception
                throw;
            }
        }

        public async Task ExecuteNonQueryAsync(string sql, dynamic[] parameters = null)
        {
            try
            {
                using (var command = _connection.CreateSpCommand(sql, parameters))
                {
                    await Task.Run(command.ExecuteNonQuery);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> ExecuteReader<T>(IDbCommand command)
        {
            var entities = new List<T>();

            await Task.Run(() =>
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entities.Add(reader.Map<T>());
                    }
                }
            });

            return entities;
        }

        private readonly IConnection _connection;
    }
}