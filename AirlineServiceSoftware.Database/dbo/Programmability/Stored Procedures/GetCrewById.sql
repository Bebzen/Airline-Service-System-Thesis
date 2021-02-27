CREATE PROCEDURE [dbo].[GetCrewById]
	@Id int
AS
BEGIN
	SELECT
	[Id],
	[CrewName],
	[CaptainID],
	[FirstOfficerID],
	[SecondOfficerID]
	FROM Crews
	WHERE [Id] = @Id
END