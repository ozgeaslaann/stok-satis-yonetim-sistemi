USE InventorySalesDb;
GO

DELETE FROM SaleItems;
DELETE FROM Sales;
DELETE FROM Products;
DELETE FROM Categories;
GO

DBCC CHECKIDENT ('Categories', RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);
DBCC CHECKIDENT ('Sales', RESEED, 0);
DBCC CHECKIDENT ('SaleItems', RESEED, 0);
GO

INSERT INTO Categories (Name) VALUES
('Klavye'),
('Mouse'),
('Kulaklik'),
('Depolama'),
('Monitor'),
('Aksesuar');

INSERT INTO Products (Name, CategoryId, UnitPrice, StockQuantity, MinimumStockQuantity) VALUES
('Mekanik Klavye', 1, 1499.90, 14, 4),
('Sessiz Kablosuz Klavye', 1, 699.90, 18, 5),
('Oyuncu Mouse', 2, 899.90, 20, 6),
('Kablosuz Mouse', 2, 499.90, 25, 8),
('RGB Oyuncu Kulakligi', 3, 1299.90, 10, 3),
('Bluetooth Kulaklik', 3, 799.90, 16, 5),
('Harici SSD 1TB', 4, 2499.90, 8, 3),
('USB Bellek 64GB', 4, 299.90, 40, 10),
('24 Inc Full HD Monitor', 5, 3999.90, 7, 2),
('Laptop Standi', 6, 449.90, 22, 6);

SELECT p.Id, p.Name, c.Name AS CategoryName, p.UnitPrice, p.StockQuantity, p.MinimumStockQuantity
FROM Products p
INNER JOIN Categories c ON c.Id = p.CategoryId
ORDER BY p.Id;
GO
