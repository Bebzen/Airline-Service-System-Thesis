﻿CREATE PROCEDURE [dbo].[GetAllCrews]
AS
BEGIN
	SELECT 
	[Id],
	[CrewName],
	[CaptainID],
	[FirstOfficerID],
	[SecondOfficerID]
	FROM Crews
END
