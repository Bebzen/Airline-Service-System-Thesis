CREATE PROCEDURE [dbo].[CreateUser]
	@Username varchar(50),
	@Password varchar(250),
	@Role varchar(15),
	@FirstName varchar(50),
	@LastName varchar(50),
	@PhoneNumber int,
	@Email varchar(50),
	@PESEL char(11),
	@DocumentId char(9)
AS
BEGIN
	INSERT INTO Users
	(
	[Username],
	[Password],
	[Role],
	[FirstName],
	[LastName],
	[PhoneNumber],
	[Email],
	[PESEL],
	[DocumentID]
	)
	VALUES
	(
	@Username,
	@Password,
	@Role,
	@FirstName,
	@LastName,
	@PhoneNumber,
	@Email,
	@PESEL,
	@DocumentId
	)
END