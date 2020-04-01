-- Alter Procedure PlantDelete
CREATE PROC [Company].[PlantDelete] @PlantId [INT]
AS
    BEGIN
        SET NOCOUNT ON;
        DELETE FROM Company.Plant with (rowlock)
        WHERE(PlantId = @PlantId);
    END;