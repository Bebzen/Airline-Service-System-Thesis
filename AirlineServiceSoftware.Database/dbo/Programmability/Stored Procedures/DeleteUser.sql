CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
BEGIN
DELETE FROM Users
WHERE
[Id] = @Id
END
