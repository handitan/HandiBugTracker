CREATE PROCEDURE [dbo].[spBugSeverity_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,Name FROM dbo.BugSeverity
END

