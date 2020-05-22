CREATE PROC [Company].[PlantSelect]
(@PlantId INT, 
 @Name    [NVARCHAR](200), 
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
        FROM Company.Plant (NOLOCK)
        WHERE((PlantId = @PlantId) OR (@PlantId = 0))
			  AND dbo.fn_CheckParamIsNull(Name,@Name)=1
			  AND dbo.fn_CheckParamIsNull(Address,@Address)=1
			  AND dbo.fn_CheckParamIsNull(City,@City)=1
			  AND dbo.fn_CheckParamIsNull(Phone,@Phone)=1
			  AND dbo.fn_CheckParamIsNull(Email,@Email)=1
    END;