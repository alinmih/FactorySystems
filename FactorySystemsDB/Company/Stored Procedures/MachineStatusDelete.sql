CREATE PROCEDURE Company.MachineStatusDelete @MachineStatusId [INT]
AS
    BEGIN
        SET NOCOUNT ON;
        DELETE FROM Company.MachineStatus WITH(ROWLOCK)
        WHERE(MachineStatusId = @MachineStatusId);
    END;