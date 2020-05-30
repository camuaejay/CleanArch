CREATE PROCEDURE [dbo].[GetUserByUserName]
	@Username VARCHAR(MAX)
AS
	SELECT TOP 1 * FROM Users where Username = @Username;
RETURN 0
