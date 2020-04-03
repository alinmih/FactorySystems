CREATE PROCEDURE Company.DutyDelete
		@DutyId [int]
AS
BEGIN
	SET NOCOUNT ON
		DELETE FROM Company.Duty WITH(ROWLOCK)
		WHERE (DutyId = @DutyId)
END