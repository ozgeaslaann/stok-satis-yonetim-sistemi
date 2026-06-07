using System;
using System.Collections.Generic;
using InventorySalesSystem.Models;
using InventorySalesSystem.Services;

namespace InventorySalesSystem.UI
{
    public class ConsoleMenu
    {
        private readonly InventoryService _inventoryService;
        private readonly CustomerService _customerService;
        private readonly SalesService _salesService;
        private readonly ReportService _reportService;

        public ConsoleMenu(
            InventoryService inventoryService,
            CustomerService customerService,
            SalesService salesService,
            ReportService reportService)
        {
            _inventoryService = inventoryService;
            _customerService = customerService;
            _salesService = salesService;
            _reportService = reportService;
        }

        public void Run()
        {
            while (true)
            {
                ClearScreen();
                Console.WriteLine("=== Stok ve Satis Yonetim Sistemi ===");
                Console.WriteLine("1 - Urunleri listele");
                Console.WriteLine("2 - Urun ekle");
                Console.WriteLine("3 - Stok guncelle");
                Console.WriteLine("4 - Musterileri listele");
                Console.WriteLine("5 - Musteri ekle");
                Console.WriteLine("6 - Satis yap");
                Console.WriteLine("7 - Son satislar");
                Console.WriteLine("8 - Dusuk stok raporu");
                Console.WriteLine("9 - En cok satilan urunler");
                Console.WriteLine("0 - Cikis");
                Console.Write("Secim: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            PrintProducts(_inventoryService.GetProducts());
                            break;
                        case "2":
                            AddProduct();
                            break;
                        case "3":
                            UpdateStock();
                            break;
                        case "4":
                            PrintCustomers(_customerService.GetCustomers());
                            break;
                        case "5":
                            AddCustomer();
                            break;
                        case "6":
                            CreateSale();
                            break;
                        case "7":
                            PrintSales(_salesService.GetRecentSales());
                            break;
                        case "8":
                            PrintProducts(_reportService.GetLowStockProducts());
                            break;
                        case "9":
                            PrintTopProducts(_reportService.GetTopProducts());
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Gecersiz secim.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }

                Pause();
            }
        }

        private void AddProduct()
        {
            Console.Write("Urun adi: ");
            var name = Console.ReadLine();
            var categoryId = ReadInt("Kategori Id: ");
            var price = ReadDecimal("Birim fiyat: ");
            var stock = ReadInt("Stok miktari: ");
            var minimumStock = ReadInt("Minimum stok: ");

            _inventoryService.AddProduct(name, categoryId, price, stock, minimumStock);
            Console.WriteLine("Urun eklendi.");
        }

        private void UpdateStock()
        {
            var productId = ReadInt("Urun Id: ");
            var stock = ReadInt("Yeni stok miktari: ");

            _inventoryService.UpdateStock(productId, stock);
            Console.WriteLine("Stok guncellendi.");
        }

        private void AddCustomer()
        {
            Console.Write("Ad soyad: ");
            var fullName = Console.ReadLine();
            Console.Write("Telefon: ");
            var phone = Console.ReadLine();
            Console.Write("E-posta: ");
            var email = Console.ReadLine();

            _customerService.AddCustomer(fullName, phone, email);
            Console.WriteLine("Musteri eklendi.");
        }

        private void CreateSale()
        {
            PrintCustomers(_customerService.GetCustomers());
            var customerId = ReadInt("Musteri Id: ");

            PrintProducts(_inventoryService.GetProducts());
            var productId = ReadInt("Urun Id: ");
            var quantity = ReadInt("Miktar: ");

            var saleId = _salesService.CreateSale(customerId, productId, quantity);
            Console.WriteLine("Satis tamamlandi. Satis Id: " + saleId);
        }

        private static void PrintProducts(List<Product> products)
        {
            Console.WriteLine("ID | Urun | Kategori | Fiyat | Stok | Min");
            Console.WriteLine("------------------------------------------");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} | {product.Name} | {product.CategoryName} | {FormatMoney(product.UnitPrice)} | {product.StockQuantity} | {product.MinimumStockQuantity}");
            }
        }

        private static void PrintCustomers(List<Customer> customers)
        {
            Console.WriteLine("ID | Musteri | Telefon | E-posta");
            Console.WriteLine("--------------------------------");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id} | {customer.FullName} | {customer.Phone} | {customer.Email}");
            }
        }

        private static void PrintSales(List<Sale> sales)
        {
            Console.WriteLine("ID | Musteri | Tarih | Tutar");
            Console.WriteLine("-----------------------------");
            foreach (var sale in sales)
            {
                Console.WriteLine($"{sale.Id} | {sale.CustomerName} | {sale.SaleDate:g} | {FormatMoney(sale.TotalAmount)}");
            }
        }

        private static void PrintTopProducts(List<TopProductReport> reports)
        {
            Console.WriteLine("Urun | Adet | Tutar");
            Console.WriteLine("-------------------");
            foreach (var report in reports)
            {
                Console.WriteLine($"{report.ProductName} | {report.TotalQuantity} | {FormatMoney(report.TotalAmount)}");
            }
        }

        private static int ReadInt(string label)
        {
            while (true)
            {
                Console.Write(label);
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    return value;
                }

                Console.WriteLine("Lutfen sayi girin.");
            }
        }

        private static decimal ReadDecimal(string label)
        {
            while (true)
            {
                Console.Write(label);
                if (decimal.TryParse(Console.ReadLine(), out var value))
                {
                    return value;
                }

                Console.WriteLine("Lutfen gecerli fiyat girin.");
            }
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Devam etmek icin Enter'a basin...");
            Console.ReadLine();
        }

        private static string FormatMoney(decimal amount)
        {
            return amount.ToString("N2") + " TL";
        }

        private static void ClearScreen()
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine();
            }
        }
    }
}
