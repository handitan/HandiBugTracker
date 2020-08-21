CREATE PROCEDURE [dbo].[spBugComment_Delete]
	@BugId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE dbo.BugComment
	WHERE ComponentBugId = @BugId
END