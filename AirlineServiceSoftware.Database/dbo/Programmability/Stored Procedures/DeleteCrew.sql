CREATE PROCEDURE [dbo].[DeleteCrew]
	@Id int
AS
BEGIN
DELETE FROM Crews
WHERE
[Id] = @Id
END
