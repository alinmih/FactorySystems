
/* 
 * FUNCTION: fn_CheckParIsNull 
 */

CREATE FUNCTION dbo.fn_CheckParamIsNull(
			   @Field NVARCHAR(255), @Param NVARCHAR(255))
RETURNS INT
AS
BEGIN
	DECLARE @Result INT;
	SELECT @Result = CASE
					 WHEN @Field LIKE @Param THEN 1
					 WHEN @Field IS NULL AND @Param IS NULL THEN 1
					 WHEN @Field IS NULL AND @Param = '%' THEN 1
					 WHEN @Field IS NULL AND @Param LIKE '' THEN 1
					 WHEN @Field IS NOT NULL AND @Param IS NULL THEN 1
					 WHEN @Field IS NOT NULL AND @Param LIKE '' THEN 1
					 WHEN @Field IS NOT NULL AND @Param = '%' THEN 1
					 ELSE 0
					 END;
	RETURN @Result;
END;