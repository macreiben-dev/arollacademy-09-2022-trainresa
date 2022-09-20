using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories.DapperSamples
{
    public sealed class ProceduralRepository
    {
        private readonly string connectionString;

        public ProceduralRepository(string connectionString)
        {
            if (connectionString is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            this.connectionString = connectionString;
        }

        public IEnumerable<SimpleData> All()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var data = connection.Query<SimpleData>("SELECT Id, VeryImportantData FROM SimpleDatas");

                return data;
            }
        }

        public void Update(SimpleData data)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Update(data);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Delete(new SimpleData()
                {
                    Id = id
                });
            }
        }
    }
}
