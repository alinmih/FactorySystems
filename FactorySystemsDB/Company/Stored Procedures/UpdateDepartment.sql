CREATE PROCEDURE Company.UpdateDepartment
	(
		@DepartmentId [int],
		@PlantId [int],
		@Name [nvarchar](200),
		@Description [nvarchar](4000)

	)
AS
	SET NOCOUNT ON
	
	BEGIN TRANSACTION
		UPDATE Company.Department WITH (rowlock)
		SET  PlantId = @PlantId, Name = @Name, Description = @Description
		WHERE (DepartmentId = @DepartmentId OR @DepartmentId IS NULL)
	COMMIT