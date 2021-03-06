﻿CREATE PROCEDURE [Company].[MachineStatusSelect]
(@MachineStatusId [INT], 
 @Status          [NVARCHAR](50)
)
AS
    BEGIN
        SET NOCOUNT ON;
        SELECT S.MachineStatusId, 
               S.STATUS
        FROM Company.MachineStatus S WITH(NOLOCK)
        WHERE((S.MachineStatusId = @MachineStatusId)
              OR (@MachineStatusId = 0))
             AND dbo.fn_CheckParamIsNull(Status,@Status)=1;
    END;