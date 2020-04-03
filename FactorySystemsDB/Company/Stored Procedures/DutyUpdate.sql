CREATE PROCEDURE Company.DutyUpdate
	(
		@DutyId [int],
		@DutyName [nvarchar](200)
	)
AS
BEGIN
	SET NOCOUNT ON

		UPDATE Company.Duty WITH (ROWLOCK)
		SET  DutyName = @DutyName
		WHERE (DutyId = @DutyId)
END