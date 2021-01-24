create table MMTShop.dbo.tblProducts (
ProductID int identity(1,1) primary key,
SKU int unique not null,
Name varchar(100) not null,
Description varchar(255) not null,
Price decimal not null,
Available tinyint not null
);

create table MMTShop.dbo.tblCategories (
CategoryID int identity(1,1) primary key,
Name varchar(100) not null,
SKUFilter int not null,
Available tinyint not null
);

CREATE PROCEDURE sp_GetAllAvailableCategories
AS
	SELECT * FROM tblCategories
	WHERE Available = 1;

CREATE PROCEDURE sp_GetAllProductsByCategory
@CategoryID int = 0
AS
BEGIN
	IF(@CategoryID = 0)
	Begin
		SELECT * FROM tblProducts
		WHERE Available = 1
	End
	Else
	Begin
		DECLARE @SKUFilter int
		SET @SKUFilter = (SELECT SkuFilter FROM tblCategories WHERE CategoryID = @CategoryID)

		SELECT * FROM tblProducts
		WHERE Available = 1
		AND LEFT(SKU, 1) = CAST(@SKUFilter as nvarchar)
	End
END;

CREATE PROCEDURE sp_GetFeaturedProducts 
AS
BEGIN
	DECLARE @Featured table(Filter nvarchar)
	insert into @Featured
	values ('1'),('2'),('3');

	SELECT p.* FROM tblProducts p
	JOIN @Featured f ON LEFT(p.SKU, 1) = f.Filter
	WHERE p.Available = 1
END;