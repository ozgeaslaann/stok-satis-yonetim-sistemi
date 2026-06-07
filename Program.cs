using System;
using System.Windows.Forms;
using InventorySalesSystem.Data;
using InventorySalesSystem.Repositories;
using InventorySalesSystem.Services;

namespace InventorySalesSystem
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var connectionFactory = new SqlConnectionFactory();

            try
            {
                DatabaseInitializer.Initialize(connectionFactory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Veritabanı başlatılırken hata oluştu:\n" + ex.Message,
                    "Başlatma Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var productRepository = new ProductRepository(connectionFactory);
            var customerRepository = new CustomerRepository(connectionFactory);
            var saleRepository = new SaleRepository(connectionFactory);

            var inventoryService = new InventoryService(productRepository);
            var customerService = new CustomerService(customerRepository);
            var salesService = new SalesService(productRepository, customerRepository, saleRepository);
            var reportService = new ReportService(productRepository, saleRepository);

            Application.Run(new MainForm(
                inventoryService,
                customerService,
                salesService,
                reportService));
        }
    }
}
