CREATE PROCEDURE [dbo].[spComponentBug_Edit]
	@Id int,
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

	UPDATE dbo.ComponentBug
	SET [Name] = @Name,
		ReporterId = @ReporterId,
		AssigneeId = @AssigneeId,
		QAContactId = @QAContactId,
		ProductId = @ProductId,
		ProductVersionId = @ProductVersionId,
		BugStatusId = @BugStatusId,
		BugStatusSubStateId = @BugStatusSubStateId,
		BugPriorityId = @BugPriorityId,
		BugSeverityId = @BugSeverityId,
		BugTypeId = @BugTypeId,
		ProductHardwareId = @ProductHardwareId,
		ProductOSId = @ProductOSId,
		ComponentId = @ComponentId,
		LastModifiedDate = GETUTCDATE()
	WHERE Id = @Id
END
