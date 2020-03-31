-- Alter Procedure PlantInsert
CREATE PROCEDURE [Company].[PlantInsert]
(@Name    [NVARCHAR](200), 
 @Address [NVARCHAR](200), 
 @City    [NVARCHAR](200), 
 @Phone   [NVARCHAR](20), 
 @Email   [NVARCHAR](200), 
 @PlantId INT             = 0 OUTPUT
)
AS
    BEGIN
        SET NOCOUNT ON;
        INSERT INTO Company.Plant WITH(ROWLOCK)
        (Name, 
         Address, 
         City, 
         Phone, 
         Email
        )
        VALUES
        (@Name, 
         @Address, 
         @City, 
         @Phone, 
         @Email
        );
        SELECT @PlantId = SCOPE_IDENTITY();
    END;