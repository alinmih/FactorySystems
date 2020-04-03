CREATE PROCEDURE Company.DutySelect
	(
		@DutyId [int],
		@DutyName [nvarchar](200)
	)
AS
BEGIN
	SET NOCOUNT ON

	SELECT DutyId, DutyName
	FROM Company.Duty WITH (NOLOCK)
	WHERE ((DutyId=@DutyId)or(@DutyId=0)) and
		 DutyName like @DutyName
END