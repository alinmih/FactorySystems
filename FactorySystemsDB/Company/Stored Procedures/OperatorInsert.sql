CREATE PROCEDURE Company.OperatorInsert
(@DutyId          [INT], 
 @OperatorGroupId [INT], 
 @DepartmentId    [INT], 
 @BadgeNumber     [NVARCHAR](200), 
 @FirstName       [NVARCHAR](200), 
 @LastName        [NVARCHAR](200), 
 @LastActionTime  [DATETIME2](7), 
 @OperatorId      [INT]           = 0 OUTPUT
)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Company.Operator WITH(ROWLOCK)
        (DutyId, 
         OperatorGroupId, 
         DepartmentId, 
         BadgeNumber, 
         FirstName, 
         LastName, 
         LastActionTime
        )
        VALUES
        (@DutyId, 
         @OperatorGroupId, 
         @DepartmentId, 
         @BadgeNumber, 
         @FirstName, 
         @LastName, 
         @LastActionTime
        );
        SELECT @OperatorId = SCOPE_IDENTITY();
    END;