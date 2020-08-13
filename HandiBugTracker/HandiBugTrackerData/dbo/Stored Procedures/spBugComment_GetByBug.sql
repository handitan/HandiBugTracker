CREATE PROCEDURE [dbo].[spBugComment_GetByBug]
	@BugId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT BugCmt.Id, BugCmt.[Description], BugCmt.CreatedDate, 
		   Usr.FirstName, Usr.LastName
	FROM dbo.BugComment AS BugCmt 
		 INNER JOIN dbo.[User] AS Usr ON 
		 BugCmt.ReporterId = Usr.Id
	WHERE BugCmt.ComponentBugId = @BugId
END