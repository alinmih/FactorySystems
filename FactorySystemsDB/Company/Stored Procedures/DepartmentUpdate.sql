-- Alter Procedure DepartmentUpdate
CREATE PROCEDURE Company.DepartmentUpdate
(@DepartmentId [INT], 
 @PlantId      [INT], 
 @Name         [NVARCHAR](200), 
 @Description  [NVARCHAR](4000)
)
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Company.Department WITH(ROWLOCK)
          SET 
              PlantId = @PlantId, 
              Name = @Name, 
              Description = @Description
        WHERE(DepartmentId = @DepartmentId);
    END;