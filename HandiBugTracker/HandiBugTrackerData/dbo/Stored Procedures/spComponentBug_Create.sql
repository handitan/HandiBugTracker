CREATE PROCEDURE [dbo].[spComponentBug_Create]
	@Name NVARCHAR (256),
	@ReporterId NVARCHAR (128),
	@AssigneeId NVARCHAR (128),
	@QAContactId NVARCHAR (128),
	@ProductId int,
	@ProductVersionId int,
	@BugStatusId int,
	@BugStatusSubStateId int,
	@BugPriorityId int,
	@BugSeverityId int,
	@BugTypeId int,
	@ProductHardwareId int,
	@ProductOSId int,
	@ComponentId int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.ComponentBug 
	([Name],ReporterId,AssigneeId,QAContactId,
	 ProductId,ProductVersionId,BugStatusId,
	 BugStatusSubStateId,BugPriorityId,BugSeverityId,BugTypeId,
	 ProductHardwareId,ProductOSId,ComponentId)
	 VALUES
	 (@Name,@ReporterId,@AssigneeId,@QAContactId,
	  @ProductId,@ProductVersionId,@BugStatusId,
	  @BugStatusSubStateId,@BugPriorityId,@BugSeverityId,@BugTypeId,
	  @ProductHardwareId,@ProductOSId,@ComponentId)
END
