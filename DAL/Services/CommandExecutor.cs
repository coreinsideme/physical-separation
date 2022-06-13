using Microsoft.Data.Sqlite;

using DAL.Interfaces;

namespace DAL.Services
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IConnectionProvider _connectionProvider;

        public CommandExecutor(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public T ExecuteSelect<T>(string commandText)
        {
            using var connection = _connectionProvider.GetConnection();

            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            return (T)command.ExecuteScalar();
        }

        public void Execute(string commandText)
        {
            using var connection = _connectionProvider.GetConnection();
            
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.ExecuteNonQuery();
        }
    }
}
