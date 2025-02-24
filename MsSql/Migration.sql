USE Store

-- Migration for Web Store

DECLARE @ErrorMessage NVARCHAR(MAX) = '';

BEGIN TRANSACTION;

BEGIN TRY

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Traider')
	
	CREATE TABLE Traider
	(
		Id INT PRIMARY KEY,
		Name NVARCHAR(100) NULL,
	);

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Product')

	CREATE TABLE Product
	(
		Id INT PRIMARY KEY,
		Name NVARCHAR(100) CHECK (Name != ''),
		Description NVARCHAR(256) DEFAULT('description not provided'),
		TraiderId INT,
		CONSTRAINT TraiderId FOREIGN KEY (TraiderId) REFERENCES Traider(Id)
	);

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Category')

	CREATE TABLE Category
	(
		Id INT PRIMARY KEY,
		Description NVARCHAR(256) NULL,
	);

	-- Many To Many Table

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ProductCategory')

	CREATE TABLE ProductCategory
	(
		ProductId INT,
		CategoryId INT,
		CONSTRAINT PC_TraiderId FOREIGN KEY (ProductId) REFERENCES Product(Id) ON DELETE CASCADE,
		CONSTRAINT PC_CategoryId FOREIGN KEY (CategoryId) REFERENCES Category(Id) ON DELETE CASCADE
	)

	-- You can add here Stored Procedure creation either
	
	COMMIT TRANSACTION;

END TRY
BEGIN CATCH

	ROLLBACK TRANSACTION;

	SET @ErrorMessage = ERROR_MESSAGE();

	PRINT 'Migration Failed: ' + @ErrorMessage;

END CATCH;