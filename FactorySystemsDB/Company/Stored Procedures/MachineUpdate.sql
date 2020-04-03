CREATE PROCEDURE Company.MachineUpdate
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
 @AlarmOnOff        [INT], 
 @AlarmDate         [DATETIME2](7), 
 @ActivityDate      [DATETIME2](7), 
 @LastActivityDate  [DATETIME2](7), 
 @ModifiedDate      [DATETIME2](7)
)
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Company.Machine WITH(ROWLOCK)
          SET 
              CostCenterId = @CostCenterId, 
              MachineCategoryId = @MachineCategoryId, 
              MachineStatusId = @MachineStatusId, 
              Name = @Name, 
              Description = @Description, 
              RatePerHour = @RatePerHour, 
              SetupTime = @SetupTime, 
              ProcessTime = @ProcessTime, 
              PartsPerCycle = @PartsPerCycle, 
              AlarmOnOff = @AlarmOnOff, 
              AlarmDate = @AlarmDate, 
              ActivityDate = @ActivityDate, 
              LastActivityDate = @LastActivityDate, 
              ModifiedDate = @ModifiedDate
        WHERE(MachineId = @MachineId);
    END;