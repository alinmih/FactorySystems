CREATE PROCEDURE Company.InsertCostCenter
	(
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

	INSERT INTO Company.CostCenter WITH (rowlock)
	(
		DepartmentId, Name, Description, Cost, AverageCost, ModifiedDate
	)
	VALUES
	(
		@DepartmentId,
		@Name,
		@Description,
		@Cost,
		@AverageCost,
		@ModifiedDate

	)
	COMMIT