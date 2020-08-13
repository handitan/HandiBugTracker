CREATE PROCEDURE [dbo].[spGetBugStatusSubState_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,[Name]
	FROM dbo.BugStatusSubState
END