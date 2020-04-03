CREATE PROCEDURE Company.MachineDelete @MachineId [INT]
AS
    BEGIN
        SET NOCOUNT ON;
        DELETE FROM Company.Machine WITH(ROWLOCK)
        WHERE(MachineId = @MachineId);
    END;