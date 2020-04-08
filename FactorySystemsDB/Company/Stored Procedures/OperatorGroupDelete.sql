CREATE PROCEDURE Company.OperatorGroupDelete @OperatorGroupId [INT]
AS
    BEGIN
        SET NOCOUNT ON;
        DELETE FROM Company.OperatorGroup WITH(ROWLOCK)
        WHERE(OperatorGroupId = @OperatorGroupId);
    END;