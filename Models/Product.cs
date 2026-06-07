namespace InventorySalesSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinimumStockQuantity { get; set; }

        public bool IsLowStock()
        {
            return StockQuantity <= MinimumStockQuantity;
        }
    }
}
