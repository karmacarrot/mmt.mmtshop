USE [MMTShop]
GO

/****** Object:  Trigger [dbo].[InsertProduct]    Script Date: 04/09/2021 16:00:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[InsertProduct] ON [dbo].[Products] 
INSTEAD OF INSERT 
AS
INSERT INTO dbo.Products (ProductSKU, ProductName, ProductDescription, ProductPrice, ProductCategoryId)
SELECT ProductSKU, ProductName, ProductDescription, ProductPrice, LEFT(TRIM(STR(ProductSKU)), 1)
  FROM inserted

GO

ALTER TABLE [dbo].[Products] ENABLE TRIGGER [InsertProduct]
GO


