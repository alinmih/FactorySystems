CREATE PROCEDURE Company.OperatorSelect
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
        SELECT O.OperatorId, 
               OD.DutyId, 
               OG.OperatorGroupId, 
               D.DepartmentId, 
               O.BadgeNumber, 
               O.FirstName, 
               O.LastName, 
               O.LastActionTime
        FROM Company.Operator O WITH(NOLOCK)
             INNER JOIN Company.OperatorDuty OD ON O.DutyId = OD.DutyId
             INNER JOIN Company.OperatorGroup OG ON O.OperatorGroupId = OG.OperatorGroupId
             INNER JOIN Company.Department D ON O.DepartmentId = D.DepartmentId
        WHERE((O.OperatorId = @OperatorId) OR (@OperatorId = 0))
             AND ((OD.DutyId = @DutyId) OR (@DutyId = 0))
             AND ((OG.OperatorGroupId = @OperatorGroupId) OR (@OperatorGroupId = 0))
             AND ((D.DepartmentId = @DepartmentId) OR (@DepartmentId = 0))
             AND BadgeNumber LIKE @BadgeNumber
             AND FirstName LIKE @FirstName
             AND LastName LIKE @LastName
             AND LastActionTime <= @LastActionTime;
    END;