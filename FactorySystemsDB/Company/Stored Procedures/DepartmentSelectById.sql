CREATE PROC Company.DepartmentSelectById(@DepartmentId [INT])
AS
     SET NOCOUNT ON;
     BEGIN TRANSACTION;
     SELECT D.DepartmentId, 
            D.PlantId, 
            D.Name, 
            D.Description
     FROM Company.Department D
     WHERE DepartmentId = @DepartmentId;
     COMMIT;