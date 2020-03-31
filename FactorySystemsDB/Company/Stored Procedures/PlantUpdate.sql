-- Alter Procedure PlantUpdate
CREATE PROC Company.PlantUpdate
(@PlantId [INT], 
 @Name    [NVARCHAR](200), 
 @Address [NVARCHAR](200), 
 @City    [NVARCHAR](200), 
 @Phone   [NVARCHAR](20), 
 @Email   [NVARCHAR](200)
)
AS
    BEGIN
        SET NOCOUNT ON;
        UPDATE Company.Plant WITH(ROWLOCK)
          SET 
              Name = @Name, 
              Address = @Address, 
              City = @City, 
              Phone = @Phone, 
              Email = @Email
        WHERE(PlantId = @PlantId);
    END;