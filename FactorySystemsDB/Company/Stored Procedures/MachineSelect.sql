CREATE PROCEDURE [Company].[MachineSelect]
(@MachineId         [INT], 
 @CostCenterId      [INT], 
 @MachineCategoryId [INT], 
 @MachineStatusId   [INT], 
 @Name              [NVARCHAR](200), 
 @Description       [NVARCHAR](4000), 
 @RatePerHour       [MONEY], 
 @SetupTime         [NUMERIC](18, 3), 
 @ProcessTime       [NUMERIC](18, 3), 
 @PartsPerCycle     [NUMERIC](18, 1), 
 @AlarmOnOff        [int], 
 @AlarmDate         [DATETIME2](7), 
 @ActivityDate      [DATETIME2](7), 
 @LastActivityDate  [DATETIME2](7), 
 @ModifiedDate      [DATETIME2](7)
)
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT M.MachineId, 
               CC.CostCenterId, 
               MC.MachineCategoryId, 
               MS.MachineStatusId, 
               M.Name, 
               M.Description, 
               M.RatePerHour, 
               M.SetupTime, 
               M.ProcessTime, 
               M.PartsPerCycle, 
               M.AlarmOnOff, 
               M.AlarmDate, 
               M.ActivityDate, 
               M.LastActivityDate, 
               M.ModifiedDate
        FROM Company.Machine M WITH(NOLOCK)
             INNER JOIN Company.CostCenter CC ON M.CostCenterId = CC.CostCenterId
             INNER JOIN Company.MachineCategory MC ON M.MachineCategoryId = MC.MachineCategoryId
             INNER JOIN Company.MachineStatus MS ON M.MachineStatusId = MS.MachineStatusId
        WHERE((M.MachineId = @MachineId) OR (@MachineId = 0))
             AND ((CC.CostCenterId = @CostCenterId) OR (@CostCenterId = 0))
             AND ((MC.MachineCategoryId = @MachineCategoryId) OR (@MachineCategoryId = 0))
             AND ((MS.MachineStatusId = @MachineStatusId) OR (@MachineStatusId = 0))
             AND dbo.fn_CheckParamIsNull(m.Name,@Name)=1
             AND dbo.fn_CheckParamIsNull(m.Description,@Description)=1
             AND ((M.RatePerHour = @RatePerHour) OR (@RatePerHour = 0))
             AND ((M.SetupTime = @SetupTime) OR (@SetupTime = 0))
             AND ((M.ProcessTime = @ProcessTime) OR (@ProcessTime = 0))
             AND ((M.PartsPerCycle = @PartsPerCycle) OR (@PartsPerCycle = 0))
             AND dbo.fn_CheckParamIsNull(m.AlarmOnOff,@AlarmOnOff)=1
             AND dbo.fn_CheckDateIsNull(M.AlarmDate ,@AlarmDate)=1
			 AND dbo.fn_CheckDateIsNull(M.ActivityDate ,@ActivityDate)=1
			 AND dbo.fn_CheckDateIsNull(M.LastActivityDate ,@LastActivityDate)=1
			 AND dbo.fn_CheckDateIsNull(M.ModifiedDate ,@ModifiedDate)=1
    END;