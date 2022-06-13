using Microsoft.Data.Sqlite;
using DAL.Interfaces;

namespace DAL.Services
{
    public class ConnectionProvider: IConnectionProvider, IDisposable
    {
        private const string _connectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";
        private SqliteConnection _masterConnection = new (_connectionString);

        public SqliteConnection GetConnection()
        {
            InitMasterConnection();
            return new SqliteConnection(_connectionString);
        }

        public void Dispose()
        {
            if (_masterConnection.State != System.Data.ConnectionState.Open) _masterConnection.Close();
        }

        private void InitMasterConnection()
        {
            if (_masterConnection.State == System.Data.ConnectionState.Open) return;
            _masterConnection.Open();
        }
    }
}
