-- Alter Procedure DepartmentDelete
CREATE PROCEDURE Company.DepartmentDelete
		@DepartmentId [int]
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
	
	BEGIN TRANSACTION
		DELETE FROM Company.Department
		WHERE (DepartmentId = @DepartmentId OR @DepartmentId IS NULL)
	COMMIT