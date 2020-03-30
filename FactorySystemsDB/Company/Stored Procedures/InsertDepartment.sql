
CREATE PROCEDURE Company.InsertDepartment
	(
		@PlantId [int],
		@Name [nvarchar](200),
		@Description [nvarchar](4000)
	)
AS
	SET NOCOUNT ON
	
	BEGIN TRANSACTION

	INSERT INTO Company.Department WITH (rowlock)
	(
		PlantId, Name, Description
	)
	VALUES
	(
		@PlantId,
		@Name,
		@Description

	)
	COMMIT