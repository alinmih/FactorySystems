CREATE PROCEDURE [Company].[InsertPlant]
	(
		@Name [nvarchar](200),
		@Address [nvarchar](200),
		@City [nvarchar](200),
		@Phone [nvarchar](20),
		@Email [nvarchar](200),
		@PlantId int=0 output
	)
AS
	SET NOCOUNT ON
	
	BEGIN TRANSACTION

	INSERT INTO Company.Plant WITH (rowlock)
	(
		Name, Address, City, Phone, Email
	)
	VALUES
	(
		@Name,
		@Address,
		@City,
		@Phone,
		@Email

	)
	SELECT @PlantId=SCOPE_IDENTITY()

	COMMIT