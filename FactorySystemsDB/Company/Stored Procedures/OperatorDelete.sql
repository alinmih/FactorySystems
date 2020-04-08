CREATE PROCEDURE Company.OperatorDelete @OperatorId [INT]
AS
    BEGIN
        SET NOCOUNT ON;
        DELETE FROM Company.Operator WITH(ROWLOCK)
        WHERE(OperatorId = @OperatorId);
    END;