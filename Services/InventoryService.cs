using System;
using System.Collections.Generic;
using InventorySalesSystem.Models;
using InventorySalesSystem.Repositories;

namespace InventorySalesSystem.Services
{
    public class InventoryService
    {
        private readonly ProductRepository _productRepository;

        public InventoryService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetById(id);
        }

        public void AddProduct(string name, int categoryId, decimal unitPrice, int stockQuantity, int minimumStockQuantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ürün adı boş olamaz.");

            if (unitPrice <= 0)
                throw new ArgumentException("Birim fiyat 0'dan büyük olmalıdır.");

            if (stockQuantity < 0 || minimumStockQuantity < 0)
                throw new ArgumentException("Stok değerleri negatif olamaz.");

            _productRepository.Add(name, categoryId, unitPrice, stockQuantity, minimumStockQuantity);
        }

        public void UpdateStock(int productId, int newStockQuantity)
        {
            if (newStockQuantity < 0)
                throw new ArgumentException("Stok miktarı negatif olamaz.");

            _productRepository.UpdateStock(productId, newStockQuantity);
        }

        public void UpdateProduct(int id, string name, int categoryId, decimal unitPrice, int stockQuantity, int minimumStockQuantity)
        {
            if (id <= 0)
                throw new ArgumentException("Güncellenecek ürün seçilmelidir.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ürün adı boş olamaz.");

            if (unitPrice <= 0)
                throw new ArgumentException("Birim fiyat 0'dan büyük olmalıdır.");

            if (stockQuantity < 0 || minimumStockQuantity < 0)
                throw new ArgumentException("Stok değerleri negatif olamaz.");

            _productRepository.Update(id, name, categoryId, unitPrice, stockQuantity, minimumStockQuantity);
        }

        public List<Product> GetLowStockProducts()
        {
            return _productRepository.GetLowStock();
        }
    }
}
