CREATE PROCEDURE Company.MachineInsert
(@CostCenterId      [INT], 
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
 @ModifiedDate      [DATETIME2](7), 
 @MachineId         [INT]            = 0 OUTPUT
)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Company.Machine WITH(ROWLOCK)
        (CostCenterId, 
         MachineCategoryId, 
         MachineStatusId, 
         Name, 
         Description, 
         RatePerHour, 
         SetupTime, 
         ProcessTime, 
         PartsPerCycle, 
         AlarmOnOff, 
         AlarmDate, 
         ActivityDate, 
         LastActivityDate, 
         ModifiedDate
        )
        VALUES
        (@CostCenterId, 
         @MachineCategoryId, 
         @MachineStatusId, 
         @Name, 
         @Description, 
         @RatePerHour, 
         @SetupTime, 
         @ProcessTime, 
         @PartsPerCycle, 
         @AlarmOnOff, 
         @AlarmDate, 
         @ActivityDate, 
         @LastActivityDate, 
         @ModifiedDate
        );
        SELECT @MachineId = SCOPE_IDENTITY();
    END;