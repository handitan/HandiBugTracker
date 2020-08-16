CREATE PROCEDURE [dbo].[spBugComment_Edit]
	@BugId int,
	@Description NVARCHAR(MAX),
	@ReporterId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.BugComment
	SET [Description] = @Description,
		ReporterId = @ReporterId,
		LastModifiedDate = GETUTCDATE()
	WHERE Id = @BugId
END