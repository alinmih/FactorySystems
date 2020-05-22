
/* 
 * FUNCTION: fn_CheckDateIsNull 
 */

CREATE FUNCTION dbo.fn_CheckDateIsNull(
			   @Field datetime2, @Param datetime2)
RETURNS INT
AS
BEGIN
	DECLARE @Result INT;
	SELECT @Result = CASE
					 WHEN @Field <= @Param THEN 1
					 WHEN @Field IS NULL AND @Param IS NULL THEN 1
					 WHEN @Field IS NULL AND @Param = '' THEN 1
					 WHEN @Field IS NOT NULL AND @Param IS NULL THEN 1
					 WHEN @Field IS NOT NULL AND @Param = '' THEN 1
					 ELSE 0
					 END;
	RETURN @Result;
END;