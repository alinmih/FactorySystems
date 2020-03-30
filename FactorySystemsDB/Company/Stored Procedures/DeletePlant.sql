﻿CREATE PROCEDURE Company.DeletePlant
		@PlantId [int]
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
	
	BEGIN TRANSACTION
		DELETE FROM Company.Plant
		WHERE (PlantId = @PlantId OR @PlantId IS NULL)
	COMMIT