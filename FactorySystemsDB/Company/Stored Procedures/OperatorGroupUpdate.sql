CREATE PROCEDURE Company.OperatorGroupUpdate
(@OperatorGroupId [INT], 
 @GroupName       [NVARCHAR](200)
)
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Company.OperatorGroup WITH(ROWLOCK)
          SET 
              GroupName = @GroupName
        WHERE(OperatorGroupId = @OperatorGroupId);
    END;