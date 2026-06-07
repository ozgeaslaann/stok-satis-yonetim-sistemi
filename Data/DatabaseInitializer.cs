using System.Data.SQLite;

namespace InventorySalesSystem.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(SqlConnectionFactory factory)
        {
            using (var connection = factory.Create())
            {
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        PRAGMA foreign_keys = ON;

                        CREATE TABLE IF NOT EXISTS Categories (
                            Id   INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS Products (
                            Id                   INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name                 TEXT    NOT NULL,
                            CategoryId           INTEGER NOT NULL REFERENCES Categories(Id),
                            UnitPrice            REAL    NOT NULL,
                            StockQuantity        INTEGER NOT NULL,
                            MinimumStockQuantity INTEGER NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS Customers (
                            Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                            FullName TEXT NOT NULL,
                            Phone    TEXT,
                            Email    TEXT
                        );

                        CREATE TABLE IF NOT EXISTS Sales (
                            Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                            CustomerId  INTEGER NOT NULL REFERENCES Customers(Id),
                            SaleDate    TEXT    NOT NULL DEFAULT (datetime('now','localtime')),
                            TotalAmount REAL    NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS SaleItems (
                            Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                            SaleId    INTEGER NOT NULL REFERENCES Sales(Id),
                            ProductId INTEGER NOT NULL REFERENCES Products(Id),
                            Quantity  INTEGER NOT NULL,
                            UnitPrice REAL    NOT NULL
                        );

                        INSERT OR IGNORE INTO Categories (Id, Name) VALUES
                            (1, 'Klavye'),
                            (2, 'Mouse'),
                            (3, 'Kulaklık'),
                            (4, 'Depolama'),
                            (5, 'Monitör'),
                            (6, 'Aksesuar');
                    ";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
