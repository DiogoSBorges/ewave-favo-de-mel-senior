IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'FavoDeMel')
BEGIN
	USE [master];
	CREATE DATABASE [FavoDeMel];
END
GO

USE [FavoDeMel];
GO

CREATE TABLE [dbo].[Teste] 
(
	[Id] INT NOT NULL,
	[Nome] VARCHAR(180) NOT NULL,
	CONSTRAINT [PK_Teste] PRIMARY KEY ([Id]) ON [PRIMARY]
)
GO