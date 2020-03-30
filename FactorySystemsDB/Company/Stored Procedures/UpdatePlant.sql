CREATE PROCEDURE Company.UpdatePlant
	(
		@PlantId [int],
		@Name [nvarchar](200),
		@Address [nvarchar](200),
		@City [nvarchar](200),
		@Phone [nvarchar](20),
		@Email [nvarchar](200)
	)
AS
	SET NOCOUNT ON
	
	BEGIN TRANSACTION
		UPDATE Company.Plant WITH (rowlock)
		SET  Name = @Name, Address = @Address, City = @City, Phone = @Phone, Email = @Email
		WHERE (PlantId = @PlantId OR @PlantId IS NULL)
	COMMIT