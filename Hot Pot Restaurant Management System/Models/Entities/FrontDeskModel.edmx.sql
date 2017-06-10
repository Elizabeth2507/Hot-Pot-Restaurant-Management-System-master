
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/10/2017 00:02:02
-- Generated from EDMX file: C:\Users\Elizabeth\Desktop\Hot-Pot-Restaurant-Management-System-master\Hot-Pot-Restaurant-Management-System-master\Hot Pot Restaurant Management System\Models\Entities\FrontDeskModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FrontDeskModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bill];
GO
IF OBJECT_ID(N'[dbo].[BillDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillDetails];
GO
IF OBJECT_ID(N'[dbo].[Discount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Discount];
GO
IF OBJECT_ID(N'[dbo].[Dish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dish];
GO
IF OBJECT_ID(N'[dbo].[Member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Member];
GO
IF OBJECT_ID(N'[dbo].[ServingTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServingTable];
GO
IF OBJECT_ID(N'[FrontDeskModelStoreContainer].[VBill]', 'U') IS NOT NULL
    DROP TABLE [FrontDeskModelStoreContainer].[VBill];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dish'
CREATE TABLE [dbo].[Dish] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ShortID] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [ShortName] varchar(50)  NOT NULL,
    [CategoryID] int  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [Unit] varchar(50)  NOT NULL,
    [Image] varchar(max)  NULL,
    [Description] varchar(max)  NULL,
    [PriceEditable] bit  NOT NULL,
    [InventoryControl] bit  NOT NULL,
    [UnitConversion] float  NULL
);
GO

-- Creating table 'ServingTable'
CREATE TABLE [dbo].[ServingTable] (
    [ID] int  NOT NULL,
    [BillID] varchar(50)  NOT NULL
);
GO

-- Creating table 'BillDetails'
CREATE TABLE [dbo].[BillDetails] (
    [ID] varchar(50)  NOT NULL,
    [DishName] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [OrderID] varchar(50)  NOT NULL,
    [WarehouseID] int  NULL,
    [POID] varchar(50)  NULL
);
GO

-- Creating table 'Discount'
CREATE TABLE [dbo].[Discount] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DiscountPercent] int  NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [IgnoredCategories] varchar(max)  NULL,
    [IsMemberOnly] bit  NOT NULL
);
GO

-- Creating table 'Bill'
CREATE TABLE [dbo].[Bill] (
    [ID] varchar(50)  NOT NULL,
    [TableID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [CustomerCount] int  NOT NULL,
    [TimePeriod] int  NOT NULL,
    [TotalCost] decimal(19,4)  NOT NULL,
    [Discount] int  NULL,
    [DiscountType] varchar(50)  NULL,
    [ExactCost] decimal(19,4)  NOT NULL,
    [Remark] varchar(max)  NULL,
    [UserID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [MemberID] varchar(50)  NULL,
    [ReceivedMoney] decimal(19,4)  NOT NULL,
    [Change] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'VBill'
CREATE TABLE [dbo].[VBill] (
    [BillID] varchar(50)  NOT NULL,
    [TableID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [CustomerCount] int  NOT NULL,
    [TimePeriod] int  NOT NULL,
    [TotalCost] decimal(19,4)  NOT NULL,
    [Discount] int  NULL,
    [DiscountType] varchar(50)  NULL,
    [ExactCost] decimal(19,4)  NOT NULL,
    [Remark] varchar(max)  NULL,
    [UserID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [DetailsID] varchar(50)  NOT NULL,
    [DishName] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [MemberID] varchar(50)  NULL,
    [ReceivedMoney] decimal(19,4)  NOT NULL,
    [Change] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Member'
CREATE TABLE [dbo].[Member] (
    [ID] varchar(50)  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Tele] varchar(25)  NOT NULL,
    [Point] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Dish'
ALTER TABLE [dbo].[Dish]
ADD CONSTRAINT [PK_Dish]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ServingTable'
ALTER TABLE [dbo].[ServingTable]
ADD CONSTRAINT [PK_ServingTable]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BillDetails'
ALTER TABLE [dbo].[BillDetails]
ADD CONSTRAINT [PK_BillDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Discount'
ALTER TABLE [dbo].[Discount]
ADD CONSTRAINT [PK_Discount]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Bill'
ALTER TABLE [dbo].[Bill]
ADD CONSTRAINT [PK_Bill]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [BillID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [ExactCost], [UserID], [UserName], [DetailsID], [DishName], [Amount], [ReceivedMoney], [Change] in table 'VBill'
ALTER TABLE [dbo].[VBill]
ADD CONSTRAINT [PK_VBill]
    PRIMARY KEY CLUSTERED ([BillID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [ExactCost], [UserID], [UserName], [DetailsID], [DishName], [Amount], [ReceivedMoney], [Change] ASC);
GO

-- Creating primary key on [ID] in table 'Member'
ALTER TABLE [dbo].[Member]
ADD CONSTRAINT [PK_Member]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------