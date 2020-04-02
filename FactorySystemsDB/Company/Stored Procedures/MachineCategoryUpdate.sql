CREATE PROCEDURE Company.MachineCategoryUpdate
(@MachineCategoryId [INT], 
 @Category          [NVARCHAR](50)
)
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Company.MachineCategory WITH(ROWLOCK)
          SET 
              Category = @Category
        WHERE(MachineCategoryId = @MachineCategoryId);
    END;