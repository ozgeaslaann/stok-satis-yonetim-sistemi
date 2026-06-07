USE InventorySalesDb;
GO

UPDATE Customers
SET FullName = 'Ozge Aslan',
    Email = 'ozge@example.com'
WHERE Id = 1;

UPDATE Customers
SET FullName = 'Sevval Aycil',
    Email = 'sevval@example.com'
WHERE Id = 2;

SELECT Id, FullName, Phone, Email
FROM Customers
ORDER BY Id;
GO
