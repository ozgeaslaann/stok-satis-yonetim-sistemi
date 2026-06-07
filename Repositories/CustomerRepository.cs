using System;
using System.Collections.Generic;
using System.Data.SQLite;
using InventorySalesSystem.Data;
using InventorySalesSystem.Models;

namespace InventorySalesSystem.Repositories
{
    public class CustomerRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public CustomerRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();

            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, FullName, Phone, Email FROM Customers ORDER BY FullName";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        customers.Add(MapCustomer(reader));
                }
            }

            return customers;
        }

        public Customer GetById(int id)
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Id, FullName, Phone, Email FROM Customers WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                    return reader.Read() ? MapCustomer(reader) : null;
            }
        }

        public void Add(string fullName, string phone, string email)
        {
            using (var connection = _connectionFactory.Create())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Customers (FullName, Phone, Email) VALUES (@FullName, @Phone, @Email)";
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Phone", phone ?? string.Empty);
                command.Parameters.AddWithValue("@Email", email ?? string.Empty);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static Customer MapCustomer(SQLiteDataReader reader)
        {
            return new Customer
            {
                Id = Convert.ToInt32(reader["Id"]),
                FullName = reader["FullName"].ToString(),
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"].ToString()
            };
        }
    }
}
