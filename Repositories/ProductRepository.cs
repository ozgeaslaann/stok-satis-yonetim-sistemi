using System;
using System.Collections.Generic;
using System.Data.SQLite;
using InventorySalesSystem.Data;
using InventorySalesSystem.Models;

namespace InventorySalesSystem.Repositories
{
    public class ProductRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public ProductRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"SELECT p.Id, p.Name, c.Name AS CategoryName, p.UnitPrice, p.StockQuantity, p.MinimumStockQuantity
                      FROM Products p
                      INNER JOIN Categories c ON c.Id = p.CategoryId
                      ORDER BY p.Name";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        products.Add(MapProduct(reader));
                }
            }

            return products;
        }

        public Product GetById(int id)
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"SELECT p.Id, p.Name, c.Name AS CategoryName, p.UnitPrice, p.StockQuantity, p.MinimumStockQuantity
                      FROM Products p
                      INNER JOIN Categories c ON c.Id = p.CategoryId
                      WHERE p.Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                    return reader.Read() ? MapProduct(reader) : null;
            }
        }

        public void Add(string name, int categoryId, decimal unitPrice, int stockQuantity, int minimumStockQuantity)
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"INSERT INTO Products (Name, CategoryId, UnitPrice, StockQuantity, MinimumStockQuantity)
                      VALUES (@Name, @CategoryId, @UnitPrice, @StockQuantity, @MinimumStockQuantity)";
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@UnitPrice", (double)unitPrice);
                command.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                command.Parameters.AddWithValue("@MinimumStockQuantity", minimumStockQuantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, string name, int categoryId, decimal unitPrice, int stockQuantity, int minimumStockQuantity)
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"UPDATE Products
                      SET Name = @Name,
                          CategoryId = @CategoryId,
                          UnitPrice = @UnitPrice,
                          StockQuantity = @StockQuantity,
                          MinimumStockQuantity = @MinimumStockQuantity
                      WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@UnitPrice", (double)unitPrice);
                command.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                command.Parameters.AddWithValue("@MinimumStockQuantity", minimumStockQuantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStock(int productId, int newStockQuantity)
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Products SET StockQuantity = @StockQuantity WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", productId);
                command.Parameters.AddWithValue("@StockQuantity", newStockQuantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Product> GetLowStock()
        {
            var products = new List<Product>();

            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"SELECT p.Id, p.Name, c.Name AS CategoryName, p.UnitPrice, p.StockQuantity, p.MinimumStockQuantity
                      FROM Products p
                      INNER JOIN Categories c ON c.Id = p.CategoryId
                      WHERE p.StockQuantity <= p.MinimumStockQuantity
                      ORDER BY p.StockQuantity";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        products.Add(MapProduct(reader));
                }
            }

            return products;
        }

        private static Product MapProduct(SQLiteDataReader reader)
        {
            return new Product
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                CategoryName = reader["CategoryName"].ToString(),
                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                MinimumStockQuantity = Convert.ToInt32(reader["MinimumStockQuantity"])
            };
        }
    }
}
