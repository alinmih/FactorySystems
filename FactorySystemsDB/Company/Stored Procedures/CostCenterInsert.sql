-- Alter Procedure CostCenterInsert
CREATE PROC Company.CostCenterInsert
(@DepartmentId [INT], 
 @Name         [NVARCHAR](200), 
 @Description  [NVARCHAR](4000), 
 @Cost         [MONEY], 
 @AverageCost  [MONEY], 
 @ModifiedDate [DATETIME2](7), 
 @CostCenterId INT              = 0 OUTPUT
)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Company.CostCenter WITH(ROWLOCK)
        (DepartmentId, 
         Name, 
         Description, 
         Cost, 
         AverageCost, 
         ModifiedDate
        )
        VALUES
        (@DepartmentId, 
         @Name, 
         @Description, 
         @Cost, 
         @AverageCost, 
         @ModifiedDate
        );
        SELECT @CostCenterId = SCOPE_IDENTITY();
    END;