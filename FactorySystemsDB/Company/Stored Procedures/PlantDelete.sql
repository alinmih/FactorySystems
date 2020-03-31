-- Alter Procedure PlantDelete
CREATE PROC Company.PlantDelete @PlantId [INT]
AS
    BEGIN
        SET NOCOUNT ON;
        DELETE FROM Company.Plant
        WHERE(PlantId = @PlantId);
    END;