-- Alter Procedure DepartmentInsert

CREATE PROCEDURE [Company].[DepartmentInsert]
(@PlantId      [INT], 
 @Name         [NVARCHAR](200), 
 @Description  [NVARCHAR](4000), 
 @DepartmentId INT              = 0 OUTPUT
)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Company.Department WITH(ROWLOCK)
        (PlantId, 
         Name, 
         Description
        )
        VALUES
        (@PlantId, 
         @Name, 
         @Description
        );
        SELECT @DepartmentId = SCOPE_IDENTITY();
    END;