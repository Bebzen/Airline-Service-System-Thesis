CREATE PROCEDURE [dbo].[EditCrew]
	@Id int,
	@CrewName nvarchar(50),
	@CaptainID int,
	@FirstOfficerID int,
	@SecondOfficerID int
AS
BEGIN
	UPDATE Crews
	SET
	[CrewName] = @CrewName,
	[CaptainID] = @CaptainID,
	[FirstOfficerID] = @FirstOfficerID,
	[SecondOfficerID] = @SecondOfficerID
	WHERE [Id] = @Id

END