CREATE PROCEDURE [dbo].[spBugPriority_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,Name FROM dbo.BugPriority
END
