CREATE PROCEDURE [dbo].[GetUserById]
	@Id int
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
	WHERE [Id] = @Id
END