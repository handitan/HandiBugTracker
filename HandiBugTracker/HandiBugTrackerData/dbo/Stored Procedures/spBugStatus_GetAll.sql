﻿CREATE PROCEDURE [dbo].[spBugStatus_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,Name FROM dbo.BugStatus
END