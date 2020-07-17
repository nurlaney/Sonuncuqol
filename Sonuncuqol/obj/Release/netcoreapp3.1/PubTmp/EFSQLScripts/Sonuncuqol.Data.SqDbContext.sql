IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712213651_InitialCreate')
BEGIN
    CREATE TABLE [Companies] (
        [Id] int NOT NULL IDENTITY,
        [Status] bit NOT NULL,
        [AddedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        [AddedBy] nvarchar(50) NULL,
        [ModifiedBy] nvarchar(50) NULL,
        [Description] nvarchar(350) NOT NULL,
        [Text] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712213651_InitialCreate')
BEGIN
    CREATE TABLE [Labels] (
        [Id] int NOT NULL IDENTITY,
        [Status] bit NOT NULL,
        [AddedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        [AddedBy] nvarchar(50) NULL,
        [ModifiedBy] nvarchar(50) NULL,
        [Text] nvarchar(60) NOT NULL,
        CONSTRAINT [PK_Labels] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712213651_InitialCreate')
BEGIN
    CREATE TABLE [Writers] (
        [Id] int NOT NULL IDENTITY,
        [Status] bit NOT NULL,
        [AddedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        [AddedBy] nvarchar(50) NULL,
        [ModifiedBy] nvarchar(50) NULL,
        [FullName] nvarchar(60) NOT NULL,
        [Image] nvarchar(300) NOT NULL,
        CONSTRAINT [PK_Writers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712213651_InitialCreate')
BEGIN
    CREATE TABLE [Posts] (
        [Id] int NOT NULL IDENTITY,
        [Status] bit NOT NULL,
        [AddedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        [AddedBy] nvarchar(50) NULL,
        [ModifiedBy] nvarchar(50) NULL,
        [Title] nvarchar(155) NOT NULL,
        [Text] nvarchar(max) NOT NULL,
        [Description] nvarchar(800) NOT NULL,
        [Image] nvarchar(300) NOT NULL,
        [IsFeatured] bit NOT NULL,
        [WriterId] int NOT NULL,
        [LabelId] int NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Posts_Labels_LabelId] FOREIGN KEY ([LabelId]) REFERENCES [Labels] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Posts_Writers_WriterId] FOREIGN KEY ([WriterId]) REFERENCES [Writers] ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712213651_InitialCreate')
BEGIN
    CREATE INDEX [IX_Posts_LabelId] ON [Posts] ([LabelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712213651_InitialCreate')
BEGIN
    CREATE INDEX [IX_Posts_WriterId] ON [Posts] ([WriterId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200712213651_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200712213651_InitialCreate', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200713122951_extre')
BEGIN
    CREATE TABLE [Admins] (
        [Id] int NOT NULL IDENTITY,
        [Status] bit NOT NULL,
        [AddedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        [AddedBy] nvarchar(50) NULL,
        [ModifiedBy] nvarchar(50) NULL,
        [Fullname] nvarchar(50) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [Password] nvarchar(100) NOT NULL,
        [Token] nvarchar(50) NULL,
        [ForgetToken] nvarchar(50) NULL,
        CONSTRAINT [PK_Admins] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200713122951_extre')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200713122951_extre', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200713161422_extra1')
BEGIN
    ALTER TABLE [Writers] ADD [Description] nvarchar(300) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200713161422_extra1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200713161422_extra1', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714081337_exxtra')
BEGIN
    CREATE TABLE [SliderItems] (
        [Id] int NOT NULL IDENTITY,
        [Status] bit NOT NULL,
        [AddedDate] datetime2 NOT NULL,
        [ModifiedDate] datetime2 NOT NULL,
        [AddedBy] nvarchar(50) NULL,
        [ModifiedBy] nvarchar(50) NULL,
        [Title] nvarchar(200) NOT NULL,
        [Description] nvarchar(200) NOT NULL,
        [Image] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_SliderItems] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714081337_exxtra')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200714081337_exxtra', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714172346_InitialCreate2')
BEGIN
    ALTER TABLE [Posts] DROP CONSTRAINT [FK_Posts_Labels_LabelId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714172346_InitialCreate2')
BEGIN
    DROP INDEX [IX_Posts_LabelId] ON [Posts];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714172346_InitialCreate2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Posts]') AND [c].[name] = N'LabelId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Posts] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Posts] DROP COLUMN [LabelId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714172346_InitialCreate2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200714172346_InitialCreate2', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714172503_InitialCreate3')
BEGIN
    ALTER TABLE [Posts] ADD [LabelId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714172503_InitialCreate3')
BEGIN
    CREATE INDEX [IX_Posts_LabelId] ON [Posts] ([LabelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714172503_InitialCreate3')
BEGIN
    ALTER TABLE [Posts] ADD CONSTRAINT [FK_Posts_Labels_LabelId] FOREIGN KEY ([LabelId]) REFERENCES [Labels] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714172503_InitialCreate3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200714172503_InitialCreate3', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714231202_edits')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Admins]') AND [c].[name] = N'ForgetToken');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Admins] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Admins] DROP COLUMN [ForgetToken];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714231202_edits')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Writers]') AND [c].[name] = N'Image');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Writers] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Writers] ALTER COLUMN [Image] nvarchar(300) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714231202_edits')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200714231202_edits', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714231237_edits1')
BEGIN
    ALTER TABLE [Admins] ADD [ForgetToken] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200714231237_edits1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200714231237_edits1', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200715051358_edit3')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Posts]') AND [c].[name] = N'Image');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Posts] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Posts] ALTER COLUMN [Image] nvarchar(300) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200715051358_edit3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200715051358_edit3', N'3.1.5');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200716091150_test3')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SliderItems]') AND [c].[name] = N'Image');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [SliderItems] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [SliderItems] ALTER COLUMN [Image] nvarchar(100) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200716091150_test3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200716091150_test3', N'3.1.5');
END;

GO

