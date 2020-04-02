CREATE PROCEDURE Company.MachineCategoryDelete @MachineCategoryId [INT]
AS
    BEGIN
        SET NOCOUNT ON;
        DELETE FROM Company.MachineCategory WITH(ROWLOCK)
        WHERE(MachineCategoryId = @MachineCategoryId);
    END;