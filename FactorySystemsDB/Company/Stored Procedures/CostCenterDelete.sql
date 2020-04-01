-- Alter Procedure CostCenterDelete
CREATE PROCEDURE [Company].[CostCenterDelete]
		@CostCenterId [int]
AS
begin
	SET NOCOUNT ON

		DELETE FROM Company.CostCenter WITH(ROWLOCK)
		WHERE (CostCenterId = @CostCenterId)
end