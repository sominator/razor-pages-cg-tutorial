IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512180517_InitialCreate')
BEGIN
    CREATE TABLE [Character] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [Profession] nvarchar(max) NULL,
        [Level] int NOT NULL,
        CONSTRAINT [PK_Character] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512180517_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210512180517_InitialCreate', N'5.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512192506_TimesPlayed')
BEGIN
    ALTER TABLE [Character] ADD [TimesPlayed] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512192506_TimesPlayed')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210512192506_TimesPlayed', N'5.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512194332_New_DataAnnotations')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Character]') AND [c].[name] = N'Profession');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Character] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Character] ALTER COLUMN [Profession] nvarchar(60) NOT NULL;
    ALTER TABLE [Character] ADD DEFAULT N'' FOR [Profession];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512194332_New_DataAnnotations')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Character]') AND [c].[name] = N'Name');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Character] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Character] ALTER COLUMN [Name] nvarchar(60) NOT NULL;
    ALTER TABLE [Character] ADD DEFAULT N'' FOR [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210512194332_New_DataAnnotations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210512194332_New_DataAnnotations', N'5.0.4');
END;
GO

COMMIT;
GO

