using Dapper;
using System.Data.SqlClient;
using TrainReservation.Business;

namespace TrainReservation.Dal
{
    public class DapperTrainRepository : ITrainRepository
    {
        private readonly string connectionString;

        public DapperTrainRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<string> Get(string trainName)
        {
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var parameters = new { trainNameParam = trainName };

            var data = connection.Query<string>(@"SELECT CONCAT(SeatNumber, CoachName) 
                FROM TrainReservations
                WHERE TrainName = @trainNameParam", parameters);

            return data;
        }
    }
}