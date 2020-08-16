CREATE PROCEDURE [dbo].[spBugComment_Create]
	@BugId int,
	@Description NVARCHAR(MAX),
	@ReporterId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.BugComment ([Description],ComponentBugId,ReporterId)
	VALUES(@Description,@BugId,@ReporterId)
END