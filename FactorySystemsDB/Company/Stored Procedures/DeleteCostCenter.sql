CREATE PROCEDURE Company.DeleteCostCenter
		@CostCenterId [int]
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON
	
	BEGIN TRANSACTION
		DELETE FROM Company.CostCenter
		WHERE (CostCenterId = @CostCenterId OR @CostCenterId IS NULL)
	COMMIT