-- Alter Procedure DepartmentDelete
CREATE PROCEDURE [Company].[DepartmentDelete] @DepartmentId [INT]
AS
    BEGIN
        SET NOCOUNT ON;
        DELETE FROM Company.Department WITH(ROWLOCK)
        WHERE(DepartmentId = @DepartmentId);
    END;