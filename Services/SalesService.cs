using System;
using System.Collections.Generic;
using InventorySalesSystem.Models;
using InventorySalesSystem.Repositories;

namespace InventorySalesSystem.Services
{
    public class SalesService
    {
        private readonly ProductRepository _productRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SaleRepository _saleRepository;

        public SalesService(
            ProductRepository productRepository,
            CustomerRepository customerRepository,
            SaleRepository saleRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _saleRepository = saleRepository;
        }

        public int CreateSale(int customerId, int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Satış miktarı 0'dan büyük olmalıdır.");

            var customer = _customerRepository.GetById(customerId);
            if (customer == null)
                throw new InvalidOperationException("Müşteri bulunamadı.");

            var product = _productRepository.GetById(productId);
            if (product == null)
                throw new InvalidOperationException("Ürün bulunamadı.");

            if (product.StockQuantity < quantity)
                throw new InvalidOperationException("Yeterli stok yok.");

            var item = new SaleItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = quantity,
                UnitPrice = product.UnitPrice
            };

            var stockUpdates = new Dictionary<int, int>
            {
                { product.Id, product.StockQuantity - quantity }
            };

            return _saleRepository.AddSale(customerId, new List<SaleItem> { item }, stockUpdates);
        }

        public List<Sale> GetRecentSales()
        {
            return _saleRepository.GetRecentSales();
        }
    }
}
