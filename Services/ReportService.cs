using System.Collections.Generic;
using InventorySalesSystem.Models;
using InventorySalesSystem.Repositories;

namespace InventorySalesSystem.Services
{
    public class ReportService
    {
        private readonly ProductRepository _productRepository;
        private readonly SaleRepository _saleRepository;

        public ReportService(ProductRepository productRepository, SaleRepository saleRepository)
        {
            _productRepository = productRepository;
            _saleRepository = saleRepository;
        }

        public List<Product> GetLowStockProducts()
        {
            return _productRepository.GetLowStock();
        }

        public List<TopProductReport> GetTopProducts()
        {
            return _saleRepository.GetTopProducts();
        }
    }
}
