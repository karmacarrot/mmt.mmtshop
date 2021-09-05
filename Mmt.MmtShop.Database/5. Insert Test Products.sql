USE [MMTShop]
GO

INSERT INTO [dbo].[Products] ([ProductSKU],[ProductName],[ProductDescription],[ProductPrice])
     VALUES  (10000, 'Test product', 'this is the description!', 9.99)
INSERT INTO [dbo].[Products] ([ProductSKU],[ProductName],[ProductDescription],[ProductPrice])
     VALUES  (20001, 'Test product 2', 'this is the 2nd description!', 8.99)
INSERT INTO [dbo].[Products] ([ProductSKU],[ProductName],[ProductDescription],[ProductPrice])
     VALUES  (50000, 'not featured product', 'this is not featured!', 9.99)

GO


