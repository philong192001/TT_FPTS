
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

-- SELECT 
CREATE PROCEDURE GetAllProducts
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM products
END
GO
EXEC GetAllProducts

CREATE PROCEDURE GetAllCategories
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM categories
END
GO
EXEC GetAllCategories

CREATE PROCEDURE GetAllBrands
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM brands;
END 
GO 
EXEC GetAllBrands;
-- INSERT
CREATE PROCEDURE InsertProduct
@Name nvarchar (250),
@Price float,
@Quantity int 
AS
BEGIN
	SET NOCOUNT ON;
	Insert into products(name,price,quantity) values (@Name,@Price,@Quantity);
END 
GO
--UPDATE 
CREATE PROC UpdateProduct
@ID int ,
@Name nvarchar (250),
@Price float,
@Quantity int 
AS
BEGIN
	SET NOCOUNT ON
	Update products set 
		name = @Name,
		price = @Price,
		quantity = @Quantity
	Where ID = @ID
END
GO
--DELETE 
CREATE PROC DeleteProduct
@ID int
AS
BEGIN 
	SET NOCOUNT ON
	Delete from  products
	Where ID = @ID
END 
GO
--GET 1 PRODUCTS
CREATE PROC GetProductById
@ID int
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM products WHERE id = @ID
END
GO
--JOIN TABLE
CREATE PROC FullJoin
--@ID int,
--@Name nvarchar(250)
AS
BEGIN
	SELECT products.name from products full outer join brands on products.name = brands.name;
END 
GO

EXEC FullJoin;

