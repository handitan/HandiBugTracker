CREATE PROCEDURE [dbo].[spComponentBug_GetFilterBy]
	@AssigneeId nvarchar(128) = NULL,
	@Id int = -1
AS
	SET NOCOUNT ON;

	SELECT	CmtBug.Id,CmtBug.[Name],Btp.Id AS TypeId,Btp.Name AS TypeName,
			Prod.Id AS ProductId,Prod.Name AS ProductName,
			Cmp.Id AS CompId, Cmp.Name AS CompName,
			(AssigneeUsr.FirstName + ' ' + AssigneeUsr.LastName) AS AssigneeName,
			BStat.Id AS StatusId, BStat.Name AS StatusName,
			BStatSub.Id AS SubStateId, BStatSub.Name AS SubStateName,
			CmtBug.LastModifiedDate
	FROM dbo.ComponentBug AS CmtBug LEFT JOIN dbo.[User] AS ReporterUsr
		 ON CmtBug.ReporterId = ReporterUsr.Id
		 LEFT JOIN dbo.[User] AS AssigneeUsr
		 ON CmtBug.AssigneeId = AssigneeUsr.Id
		 LEFT JOIN dbo.[User] AS QAUsr
		 ON CmtBug.QAContactId = QAUsr.Id
		 LEFT JOIN dbo.[Product] AS Prod
		 ON CmtBug.ProductId = Prod.Id
		 LEFT JOIN dbo.[ProductVersion] AS ProdVer
		 ON CmtBug.ProductVersionId = ProdVer.Id
		 LEFT JOIN dbo.[BugStatus] AS BStat
		 ON CmtBug.BugStatusId = BStat.Id
		 LEFT JOIN dbo.BugStatusSubState AS BStatSub
		 ON CmtBug.BugStatusSubStateId = BStatSub.Id
		 LEFT JOIN dbo.BugPriority AS BPty
		 ON CmtBug.BugPriorityId = BPty.Id
		 LEFT JOIN dbo.BugSeverity AS BSty
		 ON CmtBug.BugSeverityId = BSty.Id
		 LEFT JOIN dbo.BugType AS Btp
		 ON CmtBug.BugTypeId = Btp.Id
		 LEFT JOIN dbo.ProductHardware AS ProdHw
		 ON CmtBug.ProductHardwareId = ProdHw.Id
		 LEFT JOIN dbo.ProductOS AS ProdOS
		 ON CmtBug.ProductOSId = ProdOS.Id
		 LEFT JOIN dbo.Component AS Cmp
		 ON CmtBug.ComponentId = Cmp.Id
	WHERE (@AssigneeId IS NULL OR CmtBug.AssigneeId = @AssigneeId)
	  AND (@Id = -1 OR CmtBug.Id = @Id)
	ORDER BY CmtBug.LastModifiedDate DESC
RETURN 0
