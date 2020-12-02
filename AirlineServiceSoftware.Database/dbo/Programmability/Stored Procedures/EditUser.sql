CREATE PROCEDURE [dbo].[EditUser]
	@Id int,
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
	UPDATE Users 
	SET 
	[Username] = @Username,
	[Password] = @Password,
	[Role] = @Role,
	[FirstName] = @FirstName,
	[LastName] = @LastName,
	[PhoneNumber] = @PhoneNumber,
	[Email] = @Email,
	[PESEL] = @PESEL,
	[DocumentID] = @DocumentId
	WHERE [Id] = @Id

END