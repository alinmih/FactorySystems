CREATE PROCEDURE Company.DutyInsert
	(
		@DutyName [nvarchar](200),
		@DutyId [int] = 0 output
	)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO Company.Duty WITH (ROWLOCK)
	(
		DutyName
	)
	VALUES
	(
		@DutyName

	)

	SELECT @DutyId=SCOPE_IDENTITY()
END