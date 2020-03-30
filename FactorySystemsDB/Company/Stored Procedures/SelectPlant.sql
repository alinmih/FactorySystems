CREATE PROC Company.SelectPlant
	(
		@Name [nvarchar](200),
		@Address [nvarchar](200),
		@City [nvarchar](200),
		@Phone [nvarchar](20),
		@Email [nvarchar](200)
	)
AS
	SET NOCOUNT ON

	BEGIN TRANSACTION

	SELECT PlantId, Name, Address, City, Phone, Email
	FROM Company.Plant (nolock)
	WHERE 
		Name LIKE @Name AND
		Address LIKE @Address AND
		City LIKE @City AND
		Phone LIKE @Phone AND
		Email LIKE @Email

	COMMIT