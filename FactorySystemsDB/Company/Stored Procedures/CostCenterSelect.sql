-- Batch submitted through debugger: SQLQuery2.sql|7|0|C:\Users\Alin Mihailescu\AppData\Local\Temp\~vsB52C.sql

-- Alter Procedure CostCenterSelect
CREATE PROCEDURE [Company].[CostCenterSelect]
(@CostCenterId [INT], 
 @DepartmentId [INT], 
 @Name         [NVARCHAR](200), 
 @Description  [NVARCHAR](4000), 
 @Cost         [MONEY], 
 @AverageCost  [MONEY], 
 @ModifiedDate [DATETIME2](7)
)
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT cc.CostCenterId, 
               d.DepartmentId, 
               cc.Name, 
               cc.Description, 
               cc.Cost, 
               cc.AverageCost, 
               cc.ModifiedDate
        FROM Company.CostCenter CC(NOLOCK)
             INNER JOIN Company.Department D ON CC.DepartmentId = D.DepartmentId
        WHERE((cc.CostCenterId = @CostCenterId) OR (@CostCenterId = 0))
             AND ((d.DepartmentId = @DepartmentId) OR (@DepartmentId = 0))
             AND dbo.fn_CheckParamIsNull(cc.Name,@Name)=1
			 AND dbo.fn_CheckParamIsNull(cc.Description,@Description)=1
             AND ((cc.Cost = @Cost) OR (@Cost = 0))
             AND ((cc.AverageCost = @AverageCost) OR (@AverageCost = 0))
             AND dbo.fn_CheckDateIsNull(cc.ModifiedDate,@ModifiedDate)=1
    END;