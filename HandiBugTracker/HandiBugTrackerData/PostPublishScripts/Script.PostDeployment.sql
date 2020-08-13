/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT * FROM dbo.BugType)
BEGIN
    INSERT INTO dbo.BugType (Name)
    VALUES  ('Defect'),
            ('Enhancement'),
            ('Task')
END

IF NOT EXISTS (SELECT * FROM dbo.ProductOS)
BEGIN
    INSERT INTO dbo.ProductOS (Name)
    VALUES  ('Unspecified'),
            ('All'),
            ('Windows'),
            ('Windows 7'),
            ('Windows 8'),
            ('Windows 10'),
            ('MacOS'),
            ('Android'),
            ('iOS'),
            ('Other')
END

IF NOT EXISTS (SELECT * FROM dbo.ProductHardware)
BEGIN
    INSERT INTO dbo.ProductHardware (Name)
    VALUES  ('Unspecified'),
            ('All'),
            ('Desktop'),
            ('ARM'),
            ('ARM_64'),
            ('x86'),
            ('x86_64'),
            ('Other')
END

IF NOT EXISTS (SELECT * FROM dbo.BugSeverity)
BEGIN
    INSERT INTO dbo.BugSeverity (Name)
    VALUES  ('Critical'),
            ('Major'),
            ('Normal'),
            ('Minor'),
            ('Trivial'),
            ('Enhancement'),
            ('N/A')
END

IF NOT EXISTS (SELECT * FROM dbo.BugPriority)
BEGIN
    INSERT INTO dbo.BugPriority (Name)
    VALUES  ('P1'),
            ('P2'),
            ('P3'),
            ('P4'),
            ('P5')
END

IF NOT EXISTS (SELECT * FROM dbo.BugStatus)
BEGIN
    INSERT INTO dbo.BugStatus (Name)
    VALUES  ('NEW'),
            ('ASSIGNED'),
            ('REOPENED'),
            ('RESOLVED'),
            ('VERIFIED'),
            ('CLOSED')
END

IF NOT EXISTS (SELECT * FROM dbo.BugStatusSubState)
BEGIN
    DECLARE @ResolvedId int
    SELECT @ResolvedId = (SELECT Id FROM dbo.BugStatus WHERE Name = 'RESOLVED')
    IF (@ResolvedId > 0)
    BEGIN
        INSERT INTO dbo.BugStatusSubState (Name,BugStatusId)
        VALUES  ('FIXED',@ResolvedId),
                ('INVALID',@ResolvedId),
                ('WONTFIX',@ResolvedId),
                ('NOTABUG',@ResolvedId),
                ('NOTOURBUG',@ResolvedId),
                ('INSUFFICIENTDATA',@ResolvedId)
    END
END