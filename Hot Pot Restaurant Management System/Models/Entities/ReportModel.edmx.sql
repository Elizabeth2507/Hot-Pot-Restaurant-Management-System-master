
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/09/2017 23:25:06
-- Generated from EDMX file: C:\Users\Elizabeth\Desktop\Hot-Pot-Restaurant-Management-System-master\Hot-Pot-Restaurant-Management-System-master\Hot Pot Restaurant Management System\Models\Entities\ReportModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ReportModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MonthlyReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MonthlyReport];
GO
IF OBJECT_ID(N'[dbo].[MReportDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MReportDetails];
GO
IF OBJECT_ID(N'[dbo].[StartOfTerm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StartOfTerm];
GO
IF OBJECT_ID(N'[ReportModelStoreContainer].[VCreditOrder]', 'U') IS NOT NULL
    DROP TABLE [ReportModelStoreContainer].[VCreditOrder];
GO
IF OBJECT_ID(N'[ReportModelStoreContainer].[VMaterialsRequisition]', 'U') IS NOT NULL
    DROP TABLE [ReportModelStoreContainer].[VMaterialsRequisition];
GO
IF OBJECT_ID(N'[ReportModelStoreContainer].[VMaterialsReturnOrder]', 'U') IS NOT NULL
    DROP TABLE [ReportModelStoreContainer].[VMaterialsReturnOrder];
GO
IF OBJECT_ID(N'[ReportModelStoreContainer].[VPurchaseOrder]', 'U') IS NOT NULL
    DROP TABLE [ReportModelStoreContainer].[VPurchaseOrder];
GO
IF OBJECT_ID(N'[ReportModelStoreContainer].[VStockingList]', 'U') IS NOT NULL
    DROP TABLE [ReportModelStoreContainer].[VStockingList];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MonthlyReport'
CREATE TABLE [dbo].[MonthlyReport] (
    [ID] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL
);
GO

-- Creating table 'MReportDetails'
CREATE TABLE [dbo].[MReportDetails] (
    [ID] varchar(50)  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [OrderID] varchar(50)  NOT NULL,
    [PurchasePrice] decimal(19,4)  NOT NULL,
    [PurchaseAmount] float  NOT NULL,
    [PurchaseTotalPrice] decimal(19,4)  NOT NULL,
    [MRequisitionAmount] float  NOT NULL,
    [MReturnAmount] float  NOT NULL,
    [CreditPrice] decimal(19,4)  NOT NULL,
    [CreditAmount] float  NOT NULL,
    [CreditTotalPrice] decimal(19,4)  NOT NULL,
    [SListPrice] decimal(19,4)  NOT NULL,
    [SListAmount] float  NOT NULL,
    [SListTotalPrice] decimal(19,4)  NOT NULL,
    [MRequisitionPrice] decimal(19,4)  NOT NULL,
    [MRequisitionTotalPrice] decimal(19,4)  NOT NULL,
    [MReturnPrice] decimal(19,4)  NOT NULL,
    [MReturnTotalPrice] decimal(19,4)  NOT NULL,
    [BillPrice] decimal(19,4)  NOT NULL,
    [BillAmount] float  NOT NULL,
    [BillTotalPrice] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'StartOfTerm'
CREATE TABLE [dbo].[StartOfTerm] (
    [ID] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [Amount] float  NOT NULL,
    [TotalPrice] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'VCreditOrder'
CREATE TABLE [dbo].[VCreditOrder] (
    [ID] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [TotalPrice] float  NULL
);
GO

-- Creating table 'VMaterialsRequisition'
CREATE TABLE [dbo].[VMaterialsRequisition] (
    [ID] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [TotalPrice] float  NULL
);
GO

-- Creating table 'VMaterialsReturnOrder'
CREATE TABLE [dbo].[VMaterialsReturnOrder] (
    [ID] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [TotalPrice] float  NULL
);
GO

-- Creating table 'VPurchaseOrder'
CREATE TABLE [dbo].[VPurchaseOrder] (
    [ID] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [TotalPrice] float  NULL
);
GO

-- Creating table 'VStockingList'
CREATE TABLE [dbo].[VStockingList] (
    [ID] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [TotalPrice] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'MonthlyReport'
ALTER TABLE [dbo].[MonthlyReport]
ADD CONSTRAINT [PK_MonthlyReport]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'MReportDetails'
ALTER TABLE [dbo].[MReportDetails]
ADD CONSTRAINT [PK_MReportDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StartOfTerm'
ALTER TABLE [dbo].[StartOfTerm]
ADD CONSTRAINT [PK_StartOfTerm]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] in table 'VCreditOrder'
ALTER TABLE [dbo].[VCreditOrder]
ADD CONSTRAINT [PK_VCreditOrder]
    PRIMARY KEY CLUSTERED ([ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] ASC);
GO

-- Creating primary key on [ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] in table 'VMaterialsRequisition'
ALTER TABLE [dbo].[VMaterialsRequisition]
ADD CONSTRAINT [PK_VMaterialsRequisition]
    PRIMARY KEY CLUSTERED ([ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] ASC);
GO

-- Creating primary key on [ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] in table 'VMaterialsReturnOrder'
ALTER TABLE [dbo].[VMaterialsReturnOrder]
ADD CONSTRAINT [PK_VMaterialsReturnOrder]
    PRIMARY KEY CLUSTERED ([ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] ASC);
GO

-- Creating primary key on [ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] in table 'VPurchaseOrder'
ALTER TABLE [dbo].[VPurchaseOrder]
ADD CONSTRAINT [PK_VPurchaseOrder]
    PRIMARY KEY CLUSTERED ([ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] ASC);
GO

-- Creating primary key on [ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] in table 'VStockingList'
ALTER TABLE [dbo].[VStockingList]
ADD CONSTRAINT [PK_VStockingList]
    PRIMARY KEY CLUSTERED ([ID], [WarehouseName], [Date], [ProductName], [Amount], [Price] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------