SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE CreateProduct
	@Id INT,
	@Name NVARCHAR(100),
	@Description NVARCHAR(200) = NULL,
	@TraiderId INT NULL = NULL
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	DECLARE @DefaultTraiderId INT = 20;
	SET @DefaultTraiderId = 20;

	BEGIN TRY
		
		IF(@Id IS NULL)
		BEGIN
			COMMIT TRANSACTION;

			RETURN;
		END

		IF ((SELECT COUNT(*) FROM Product WHERE Id = @Id) > 0)
		BEGIN
			COMMIT TRANSACTION;

			RETURN;	
		END;

		IF (@TraiderId IS NULL)
		BEGIN
			SET @TraiderId = @DefaultTraiderId;
		END;

		INSERT INTO Product (Id, Name, Description, TraiderId)
		VALUES (@Id, @Name, @Description, @TraiderId)

		COMMIT TRANSACTION;

		SELECT * FROM Product
		WHERE Id = @Id;

	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION;

	END CATCH;

END
GO
