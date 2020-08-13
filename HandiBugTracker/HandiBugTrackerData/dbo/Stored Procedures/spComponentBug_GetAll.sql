CREATE PROCEDURE [dbo].[spComponentBug_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	CmtBug.Id,CmtBug.[Name],Btp.Name,Prod.Name,
			Cmp.Name,
			(AssigneeUsr.FirstName + ' ' + AssigneeUsr.LastName) AS FullName,
			BStat.Name,BStatSub.Name, CmtBug.LastModifiedDate
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
END