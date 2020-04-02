CREATE PROCEDURE Company.MachineStatusInsert
(@Status          [NVARCHAR](50), 
 @MachineStatusId [INT]          = 0 OUTPUT
)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Company.MachineStatus WITH(ROWLOCK)(STATUS)
        VALUES(@Status);
        SELECT @MachineStatusId = SCOPE_IDENTITY();
    END;