using Microsoft.Data.Sqlite;

namespace DAL.Interfaces
{
    public interface IConnectionProvider
    {
        SqliteConnection GetConnection();
    }
}
