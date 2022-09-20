using NFluent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Xunit;

namespace Repositories.DapperSamples.Acceptance.Tests
{
    public class ProceduralRepositoryTest
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=arolla-bootstrappers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ProceduralRepositoryTest()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "DELETE SimpleDatas";
                cmd.ExecuteNonQuery();
            }

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO SimpleDatas(VeryImportantData) VALUES ('DataValue01')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO SimpleDatas(VeryImportantData) VALUES ('DataValue02')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO SimpleDatas(VeryImportantData) VALUES ('DataValue03')";
                cmd.ExecuteNonQuery();
            }
        }

        private ProceduralRepository GetTarget()
        {
            return new ProceduralRepository(ConnectionString);
        }

        [Fact]
        public void Demo_All()
        {
            var target = GetTarget();

            var actual = target.All();

            Check.That(actual.Count()).IsEqualTo(3);
        }

        [Fact]
        public void Demo_Update()
        {
            
            var originalData = ReadData();

            var original = originalData.First();

            SimpleData patched = new SimpleData()
            {
                Id = original.Id,
                VeryImportantData = "patched"
            };

            // ACT
            var target = GetTarget();

            target.Update(patched);

            var actualData = ReadData()
                .FirstOrDefault(c => c.Id == original.Id);

            // ASSERT
            Check.That(actualData.VeryImportantData).IsEqualTo("patched");
        }

        [Fact]
        public void Demo_Delete()
        {
            var data = ReadData();

            int originalCount = data.Count() - 1;

            // ACT
            var target = GetTarget();

            target.Delete(data.FirstOrDefault().Id);

            var updatedData = ReadData();

            // ASSERT
            Check.That(updatedData.Count()).IsEqualTo(originalCount);
        }

        private IEnumerable<SimpleData> ReadData()
        {
            List<SimpleData> data = new List<SimpleData>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT Id, VeryImportantData FROM SimpleDatas";
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var idIndex = reader.GetOrdinal("Id");
                        var veryImportantDataIndex = reader.GetOrdinal("VeryImportantData");

                        int idValue = reader.GetInt32(idIndex);
                        string veryImportantDataValue = reader.GetString(veryImportantDataIndex);

                        data.Add(new SimpleData
                        {
                            Id = idValue,
                            VeryImportantData = veryImportantDataValue
                        });
                    }
                }
            }

            return data;
        }
    }
}
