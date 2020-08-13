CREATE PROCEDURE [dbo].[spBugStatusSubState_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,[Name]
	FROM dbo.BugStatusSubState
END