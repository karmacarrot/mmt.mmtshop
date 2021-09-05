USE [MMTShop]
GO

/****** Object:  Trigger [dbo].[InsertProduct]    Script Date: 05/09/2021 18:48:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[InsertProduct] ON [dbo].[Products] 
INSTEAD OF INSERT 
AS
INSERT INTO dbo.Products (ProductSKU, ProductName, ProductDescription, ProductPrice, CategoryId)
SELECT ProductSKU, ProductName, ProductDescription, ProductPrice, LEFT(TRIM(STR(ProductSKU)), 1)
  FROM inserted

GO

ALTER TABLE [dbo].[Products] ENABLE TRIGGER [InsertProduct]
GO


