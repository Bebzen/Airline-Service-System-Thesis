CREATE PROCEDURE [dbo].[CreateCrew]
	@CrewName nvarchar(50),
	@CaptainID int,
	@FirstOfficerID int,
	@SecondOfficerID int
AS
BEGIN
	INSERT INTO Crews
	(
	[CrewName],
	[CaptainID],
	[FirstOfficerID],
	[SecondOfficerID]
	)
	VALUES
	(
	@CrewName,
	@CaptainID,
	@FirstOfficerID,
	@SecondOfficerID
	)
END
