﻿CREATE PROCEDURE Company.OperatorGroupSelect
(@OperatorGroupId [INT], 
 @GroupName       [NVARCHAR](200)
)
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT OperatorGroupId, 
               GroupName
        FROM Company.OperatorGroup WITH(NOLOCK)
        WHERE((OperatorGroupId = @OperatorGroupId) OR (@OperatorGroupId = 0))
             AND GroupName LIKE @GroupName;
    END;