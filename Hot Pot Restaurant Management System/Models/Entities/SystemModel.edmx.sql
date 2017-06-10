
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/09/2017 23:15:15
-- Generated from EDMX file: C:\Users\Elizabeth\Desktop\Hot-Pot-Restaurant-Management-System-master\Hot-Pot-Restaurant-Management-System-master\Hot Pot Restaurant Management System\Models\Entities\SystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SystemModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ShortID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Role] int  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [RealName] varchar(50)  NOT NULL,
    [RealPost] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------