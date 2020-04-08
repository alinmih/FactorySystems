-- Alter Procedure OperatorDutyUpdate
-- Alter Procedure DutyUpdate
CREATE PROCEDURE Company.OperatorDutyUpdate
	(
		@DutyId [int],
		@DutyName [nvarchar](200)
	)
AS
BEGIN
	SET NOCOUNT ON

		UPDATE Company.OperatorDuty WITH (ROWLOCK)
		SET  DutyName = @DutyName
		WHERE (DutyId = @DutyId)
END