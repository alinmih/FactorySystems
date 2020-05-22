-- Alter Procedure OperatorDutySelect
CREATE PROCEDURE [Company].[OperatorDutySelect]
	(
		@DutyId [int],
		@DutyName [nvarchar](200)
	)
AS
BEGIN
	SET NOCOUNT ON

	SELECT DutyId, DutyName
	FROM Company.OperatorDuty WITH (NOLOCK)
	WHERE ((DutyId=@DutyId)or(@DutyId=0))
		 AND dbo.fn_CheckParamIsNull(DutyName,@DutyName)=1;
END