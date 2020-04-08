-- Alter Procedure OperatorDutyInsert
-- Alter Procedure DutyInsert
CREATE PROCEDURE Company.OperatorDutyInsert
	(
		@DutyName [nvarchar](200),
		@DutyId [int] = 0 output
	)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO Company.OperatorDuty WITH (ROWLOCK)
	(
		DutyName
	)
	VALUES
	(
		@DutyName

	)

	SELECT @DutyId=SCOPE_IDENTITY()
END