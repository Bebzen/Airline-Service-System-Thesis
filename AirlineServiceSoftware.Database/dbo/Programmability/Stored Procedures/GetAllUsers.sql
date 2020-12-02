CREATE PROCEDURE [dbo].[GetAllUsers]
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
END
