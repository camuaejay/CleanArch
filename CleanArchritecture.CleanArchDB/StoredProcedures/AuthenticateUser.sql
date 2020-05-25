CREATE PROCEDURE [dbo].[AuthenticateUser]
	@Username VARCHAR(MAX),
	@Password VARCHAR(MAX)
AS
	SELECT TOP 1 * FROM Users where Username = @Username AND Password = @Password;
RETURN 0
