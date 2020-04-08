CREATE PROCEDURE Company.OperatorUpdate
(@OperatorId      [INT], 
 @DutyId          [INT], 
 @OperatorGroupId [INT], 
 @DepartmentId    [INT], 
 @BadgeNumber     [NVARCHAR](200), 
 @FirstName       [NVARCHAR](200), 
 @LastName        [NVARCHAR](200), 
 @LastActionTime  [DATETIME2](7)
)
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Company.Operator WITH(ROWLOCK)
          SET 
              DutyId = @DutyId, 
              OperatorGroupId = @OperatorGroupId, 
              DepartmentId = @DepartmentId, 
              BadgeNumber = @BadgeNumber, 
              FirstName = @FirstName, 
              LastName = @LastName, 
              LastActionTime = @LastActionTime
        WHERE(OperatorId = @OperatorId);
    END;