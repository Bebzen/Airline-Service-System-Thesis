CREATE PROCEDURE [dbo].[EditUserNoPasswordChange]
	@Id int,
	@Username varchar(50),
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
	[Role] = @Role,
	[FirstName] = @FirstName,
	[LastName] = @LastName,
	[PhoneNumber] = @PhoneNumber,
	[Email] = @Email,
	[PESEL] = @PESEL,
	[DocumentID] = @DocumentId
	WHERE [Id] = @Id

END