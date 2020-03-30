CREATE PROCEDURE Company.SelectCostCenter
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

	SELECT CostCenterId, DepartmentId, Name, Description, Cost, AverageCost, ModifiedDate
	FROM Company.CostCenter (nolock)
	WHERE 
		DepartmentId LIKE @DepartmentId AND
		Name LIKE @Name AND
		Description LIKE @Description AND
		Cost LIKE @Cost AND
		AverageCost LIKE @AverageCost AND
		ModifiedDate LIKE @ModifiedDate



	COMMIT