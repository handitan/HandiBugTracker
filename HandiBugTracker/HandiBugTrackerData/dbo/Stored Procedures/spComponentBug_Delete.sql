CREATE PROCEDURE [dbo].[spComponentBug_Delete]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.ComponentBug
	WHERE Id = @Id
END
