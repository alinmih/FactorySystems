-- Alter Procedure PlantSelectById
CREATE PROC Company.PlantSelectById
	(
	@PlantId [int]
	)
AS
	SET NOCOUNT ON

	BEGIN TRANSACTION

	SELECT PlantId, Name, Address, City, Phone, Email
	FROM Company.Plant (nolock)
	WHERE 
		PlantId=@PlantId

	COMMIT