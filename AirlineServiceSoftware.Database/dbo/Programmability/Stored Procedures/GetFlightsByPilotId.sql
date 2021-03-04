CREATE PROCEDURE [dbo].[GetFlightsByPilotId]
	@Id int
AS
BEGIN
	SELECT *
	FROM Crews
	JOIN Flights
	ON Crews.Id=Flights.CrewID
	WHERE [CaptainID] = @Id OR
	[FirstOfficerID] = @Id OR
	[SecondOfficerID] = @Id
END
