CREATE PROCEDURE [dbo].[spComponentBug_GetAllOptionsList]
AS
BEGIN
	SET NOCOUNT ON;

	exec dbo.spBugPriority_GetAll;
	exec dbo.spBugSeverity_GetAll;
	exec dbo.spBugStatus_GetAll;
END