-- Alter Procedure OperatorDutyDelete
-- Alter Procedure DutyDelete
CREATE PROCEDURE Company.OperatorDutyDelete
		@DutyId [int]
AS
BEGIN
	SET NOCOUNT ON
		DELETE FROM Company.OperatorDuty WITH(ROWLOCK)
		WHERE (DutyId = @DutyId)
END