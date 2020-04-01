CREATE PROC Company.DepartmentSelect
(@DepartmentId INT, 
 @PlantId      INT, 
 @Name         [NVARCHAR](200), 
 @Description  NVARCHAR(4000)
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
        WHERE((d.DepartmentId = @DepartmentId)
              OR (@DepartmentId = 0))
             AND ((p.PlantId = @PlantId)
                  OR (@PlantId = 0))
             AND d.Name LIKE @Name;
    END;