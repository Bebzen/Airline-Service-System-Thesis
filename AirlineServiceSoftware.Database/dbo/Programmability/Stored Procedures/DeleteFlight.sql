CREATE PROCEDURE [dbo].[DeleteFlight]
	@Id int
AS
BEGIN
DELETE FROM Flights
WHERE
[Id] = @Id
END
