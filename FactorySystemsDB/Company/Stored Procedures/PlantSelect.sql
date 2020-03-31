CREATE PROC Company.PlantSelect
(@Name    [NVARCHAR](200), 
 @Address [NVARCHAR](200), 
 @City    [NVARCHAR](200), 
 @Phone   [NVARCHAR](20), 
 @Email   [NVARCHAR](200)
)
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT PlantId, 
               Name, 
               Address, 
               City, 
               Phone, 
               Email
        FROM Company.Plant(NOLOCK)
        WHERE Name LIKE @Name
              AND Address LIKE @Address
              AND City LIKE @City
              AND Phone LIKE @Phone
              AND Email LIKE @Email;
    END;