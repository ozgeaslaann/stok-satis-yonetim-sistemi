using System.IO;
using System.Data.SQLite;

namespace InventorySalesSystem.Data
{
    public class SqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory()
        {
            var dbPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "inventory.db");
            _connectionString = $"Data Source={dbPath};Version=3;";
        }

        public SQLiteConnection Create()
        {
            return new SQLiteConnection(_connectionString);
        }

        public string ConnectionString => _connectionString;
    }
}
