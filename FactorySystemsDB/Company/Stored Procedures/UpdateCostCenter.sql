CREATE PROCEDURE Company.UpdateCostCenter
	(
		@CostCenterId [int],
		@DepartmentId [int],
		@Name [nvarchar](200),
		@Description [nvarchar](4000),
		@Cost [money],
		@AverageCost [money],
		@ModifiedDate [datetime2](7)
	)
AS
	SET NOCOUNT ON
	
	BEGIN TRANSACTION
		UPDATE Company.CostCenter WITH (rowlock)
		SET  DepartmentId = @DepartmentId, Name = @Name, Description = @Description, Cost = @Cost, AverageCost = @AverageCost, ModifiedDate = @ModifiedDate
		WHERE (CostCenterId = @CostCenterId OR @CostCenterId IS NULL)
	COMMIT