CREATE PROCEDURE [dbo].[GetAllPilots]
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
	WHERE [Role] = 'Pilot'
END