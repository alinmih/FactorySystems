CREATE PROC Company.DepartmentSelect
(@Name    [NVARCHAR](200), 
 @PlantId INT = NULL
)
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT d.DepartmentId, 
               d.PlantId, 
               d.Name, 
               d.Description
        FROM Company.Department D(NOLOCK)
             INNER JOIN Company.Plant P ON d.PlantId = p.PlantId
        WHERE d.Name LIKE @Name
              AND d.PlantId = ISNULL(@PlantId, D.PlantId);
    END;