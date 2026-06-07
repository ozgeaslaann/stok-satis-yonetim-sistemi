using System;
using System.Collections.Generic;
using System.Data.SQLite;
using InventorySalesSystem.Data;
using InventorySalesSystem.Models;

namespace InventorySalesSystem.Repositories
{
    public class SaleRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public SaleRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // stockUpdates: productId -> newStockQuantity, updated atomically within the sale transaction
        public int AddSale(int customerId, List<SaleItem> items, Dictionary<int, int> stockUpdates)
        {
            using (var connection = _connectionFactory.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var totalAmount = 0m;
                        foreach (var item in items)
                            totalAmount += item.LineTotal;

                        var saleId = InsertSale(connection, transaction, customerId, totalAmount);

                        foreach (var item in items)
                            InsertSaleItem(connection, transaction, saleId, item);

                        foreach (var entry in stockUpdates)
                            UpdateStock(connection, transaction, entry.Key, entry.Value);

                        transaction.Commit();
                        return saleId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Sale> GetRecentSales()
        {
            var sales = new List<Sale>();

            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"SELECT s.Id, s.CustomerId, c.FullName AS CustomerName, s.SaleDate, s.TotalAmount
                      FROM Sales s
                      INNER JOIN Customers c ON c.Id = s.CustomerId
                      ORDER BY s.SaleDate DESC
                      LIMIT 20";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sales.Add(new Sale
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            CustomerName = reader["CustomerName"].ToString(),
                            SaleDate = DateTime.Parse(reader["SaleDate"].ToString()),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                        });
                    }
                }
            }

            return sales;
        }

        public List<TopProductReport> GetTopProducts()
        {
            var reports = new List<TopProductReport>();

            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"SELECT p.Name AS ProductName,
                             SUM(si.Quantity) AS TotalQuantity,
                             SUM(si.Quantity * si.UnitPrice) AS TotalAmount
                      FROM SaleItems si
                      INNER JOIN Products p ON p.Id = si.ProductId
                      GROUP BY p.Name
                      ORDER BY TotalQuantity DESC
                      LIMIT 10";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reports.Add(new TopProductReport
                        {
                            ProductName = reader["ProductName"].ToString(),
                            TotalQuantity = Convert.ToInt32(reader["TotalQuantity"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                        });
                    }
                }
            }

            return reports;
        }

        private static int InsertSale(SQLiteConnection connection, SQLiteTransaction transaction, int customerId, decimal totalAmount)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText =
                    @"INSERT INTO Sales (CustomerId, TotalAmount) VALUES (@CustomerId, @TotalAmount);
                      SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@TotalAmount", (double)totalAmount);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private static void InsertSaleItem(SQLiteConnection connection, SQLiteTransaction transaction, int saleId, SaleItem item)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText =
                    @"INSERT INTO SaleItems (SaleId, ProductId, Quantity, UnitPrice)
                      VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice)";
                command.Parameters.AddWithValue("@SaleId", saleId);
                command.Parameters.AddWithValue("@ProductId", item.ProductId);
                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                command.Parameters.AddWithValue("@UnitPrice", (double)item.UnitPrice);
                command.ExecuteNonQuery();
            }
        }

        private static void UpdateStock(SQLiteConnection connection, SQLiteTransaction transaction, int productId, int newStockQuantity)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "UPDATE Products SET StockQuantity = @StockQuantity WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", productId);
                command.Parameters.AddWithValue("@StockQuantity", newStockQuantity);
                command.ExecuteNonQuery();
            }
        }
    }
}
