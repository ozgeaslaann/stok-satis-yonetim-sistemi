IF DB_ID('InventorySalesDb') IS NULL
BEGIN
    CREATE DATABASE InventorySalesDb;
END
GO

USE InventorySalesDb;
GO

IF OBJECT_ID('SaleItems', 'U') IS NOT NULL DROP TABLE SaleItems;
IF OBJECT_ID('Sales', 'U') IS NOT NULL DROP TABLE Sales;
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
IF OBJECT_ID('Customers', 'U') IS NOT NULL DROP TABLE Customers;
IF OBJECT_ID('Categories', 'U') IS NOT NULL DROP TABLE Categories;
GO

CREATE TABLE Categories
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    CategoryId INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL,
    MinimumStockQuantity INT NOT NULL,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE Customers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(30) NULL,
    Email NVARCHAR(100) NULL
);

CREATE TABLE Sales
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId INT NOT NULL,
    SaleDate DATETIME NOT NULL CONSTRAINT DF_Sales_SaleDate DEFAULT GETDATE(),
    TotalAmount DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Sales_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);

CREATE TABLE SaleItems
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_SaleItems_Sales FOREIGN KEY (SaleId) REFERENCES Sales(Id),
    CONSTRAINT FK_SaleItems_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

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

INSERT INTO Customers (FullName, Phone, Email) VALUES
('Ozge Aslan', '0555 111 22 33', 'ozge@example.com'),
('Sevval Aycil', '0555 444 55 66', 'sevval@example.com');
GO
