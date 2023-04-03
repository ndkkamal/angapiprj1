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

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(50) NULL,
    [Email] varchar(50) NULL,
    [Phone] varchar(20) NULL,
    [Salary] int NOT NULL,
    [Department] varchar(20) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

COMMIT;
GO

