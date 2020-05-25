CREATE PROCEDURE [dbo].[SaveUser]
    @Id UNIQUEIDENTIFIER,
    @Username NVARCHAR(50),
    @Password NVARCHAR(MAX), 
    @FirstName NVARCHAR(250), 
    @MiddleName NVARCHAR(250), 
    @LastName NVARCHAR(250), 
    @BirthDate DATETIME, 
    @EmailAddress NVARCHAR(MAX)
AS
    INSERT INTO Users (
        Id, Username, Password, FirstName, MiddleName, LastName, BirthDate, EmailAddress )
    VALUES (
        @Id,
        @Username,
        @Password,
        @FirstName,
        @MiddleName,
        @LastName,
        @BirthDate,
        @EmailAddress
    )
RETURN 0
