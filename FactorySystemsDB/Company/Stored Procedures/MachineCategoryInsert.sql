CREATE PROCEDURE Company.MachineCategoryInsert
(@Category          [NVARCHAR](50), 
 @MachineCategoryId [INT]          = 0 OUTPUT
)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Company.MachineCategory WITH(ROWLOCK)(Category)
        VALUES(@Category);
        SELECT @MachineCategoryId = SCOPE_IDENTITY();
    END;