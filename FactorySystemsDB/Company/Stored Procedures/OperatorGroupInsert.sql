CREATE PROCEDURE Company.OperatorGroupInsert
(@GroupName       [NVARCHAR](200), 
 @OperatorGroupId [INT]           = 0 OUTPUT
)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Company.OperatorGroup WITH(ROWLOCK)(GroupName)
        VALUES(@GroupName);
        SELECT @OperatorGroupId = SCOPE_IDENTITY();
    END;