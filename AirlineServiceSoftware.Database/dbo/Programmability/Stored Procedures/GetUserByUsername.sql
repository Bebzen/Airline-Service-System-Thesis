CREATE PROCEDURE [dbo].[GetUserByUsername]
	@username varchar(50)
AS
BEGIN
	SELECT 
	[Id],
	[Username],
	[Password],
	[Role],
	[FirstName],
	[LastName],
	[PhoneNumber],
	[Email],
	[PESEL],
	[DocumentID]
	FROM Users
	WHERE [Username] = @username
END
