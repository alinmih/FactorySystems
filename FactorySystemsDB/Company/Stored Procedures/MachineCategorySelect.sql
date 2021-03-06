﻿CREATE PROCEDURE [Company].[MachineCategorySelect]
(@MachineCategoryId [INT], 
 @Category          [NVARCHAR](50)
)
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT C.MachineCategoryId, 
               C.Category
        FROM Company.MachineCategory C WITH(NOLOCK)
        WHERE((C.MachineCategoryId = @MachineCategoryId)
              OR (@MachineCategoryId = 0))
			 AND dbo.fn_CheckParamIsNull(C.Category,@Category)=1
    END;