CREATE PROCEDURE Company.MachineStatusUpdate
(@MachineStatusId [INT], 
 @Status          [NVARCHAR](50)
)
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Company.MachineStatus WITH(ROWLOCK)
          SET 
              STATUS = @Status
        WHERE(MachineStatusId = @MachineStatusId);
    END;