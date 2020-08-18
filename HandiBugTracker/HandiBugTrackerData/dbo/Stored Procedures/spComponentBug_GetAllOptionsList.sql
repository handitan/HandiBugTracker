CREATE PROCEDURE [dbo].[spComponentBug_GetAllOptionsList]
AS
BEGIN
	SET NOCOUNT ON;

	exec dbo.spBugPriority_GetAll;
	exec dbo.spBugSeverity_GetAll;
	exec dbo.spBugStatus_GetAll;
	exec dbo.spBugStatusSubState_GetAll;
	exec dbo.spBugType_GetAll;
	exec dbo.spProduct_GetAll;
	exec dbo.spProductHardware_GetAll;
	exec dbo.spProductOS_GetAll;
	exec dbo.spComponent_GetAll;
	exec dbo.spProductVersion_GetAll
END