using System;
using System.Collections.Generic;
using InventorySalesSystem.Models;
using InventorySalesSystem.Repositories;

namespace InventorySalesSystem.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void AddCustomer(string fullName, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Müşteri adı boş olamaz.");

            _customerRepository.Add(fullName, phone, email);
        }
    }
}
