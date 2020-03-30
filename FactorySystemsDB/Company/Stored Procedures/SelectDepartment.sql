CREATE PROCEDURE Company.SelectDepartment
	(
		@DepartmentId [int],
		@PlantId [int],
		@Name [nvarchar](200),
		@Description [nvarchar](4000)
	)
AS
	SET NOCOUNT ON

	BEGIN TRANSACTION

	SELECT DepartmentId, PlantId, Name, Description
	FROM Company.Department (nolock)
	WHERE 
		DepartmentId LIKE @DepartmentId AND
		PlantId LIKE @PlantId AND
		Name LIKE @Name AND
		Description LIKE @Description

	COMMIT