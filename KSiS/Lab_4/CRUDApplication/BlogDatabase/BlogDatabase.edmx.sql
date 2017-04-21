
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/21/2017 12:00:51
-- Generated from EDMX file: D:\Crypto\GitHub\bsuir-labs\KSiS\Lab_4\CRUDApplication\BlogDatabase\BlogDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BlogDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CategoryPost_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryPost] DROP CONSTRAINT [FK_CategoryPost_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryPost_Post]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryPost] DROP CONSTRAINT [FK_CategoryPost_Post];
GO
IF OBJECT_ID(N'[dbo].[FK_ReviewPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewSet] DROP CONSTRAINT [FK_ReviewPost];
GO
IF OBJECT_ID(N'[dbo].[FK_UserReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewSet] DROP CONSTRAINT [FK_UserReview];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[PostSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostSet];
GO
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[ReviewSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReviewSet];
GO
IF OBJECT_ID(N'[dbo].[CategoryPost]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryPost];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'IElementSet'
CREATE TABLE [dbo].[IElementSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'IElementSet_Category'
CREATE TABLE [dbo].[IElementSet_Category] (
    [Title] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'IElementSet_Post'
CREATE TABLE [dbo].[IElementSet_Post] (
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'IElementSet_Review'
CREATE TABLE [dbo].[IElementSet_Review] (
    [Content] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Post_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'IElementSet_User'
CREATE TABLE [dbo].[IElementSet_User] (
    [Name] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'CategoryPost'
CREATE TABLE [dbo].[CategoryPost] (
    [Category_Id] int  NOT NULL,
    [Post_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'IElementSet'
ALTER TABLE [dbo].[IElementSet]
ADD CONSTRAINT [PK_IElementSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IElementSet_Category'
ALTER TABLE [dbo].[IElementSet_Category]
ADD CONSTRAINT [PK_IElementSet_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IElementSet_Post'
ALTER TABLE [dbo].[IElementSet_Post]
ADD CONSTRAINT [PK_IElementSet_Post]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IElementSet_Review'
ALTER TABLE [dbo].[IElementSet_Review]
ADD CONSTRAINT [PK_IElementSet_Review]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IElementSet_User'
ALTER TABLE [dbo].[IElementSet_User]
ADD CONSTRAINT [PK_IElementSet_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Category_Id], [Post_Id] in table 'CategoryPost'
ALTER TABLE [dbo].[CategoryPost]
ADD CONSTRAINT [PK_CategoryPost]
    PRIMARY KEY CLUSTERED ([Category_Id], [Post_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Category_Id] in table 'CategoryPost'
ALTER TABLE [dbo].[CategoryPost]
ADD CONSTRAINT [FK_CategoryPost_Category]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[IElementSet_Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Post_Id] in table 'CategoryPost'
ALTER TABLE [dbo].[CategoryPost]
ADD CONSTRAINT [FK_CategoryPost_Post]
    FOREIGN KEY ([Post_Id])
    REFERENCES [dbo].[IElementSet_Post]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryPost_Post'
CREATE INDEX [IX_FK_CategoryPost_Post]
ON [dbo].[CategoryPost]
    ([Post_Id]);
GO

-- Creating foreign key on [Post_Id] in table 'IElementSet_Review'
ALTER TABLE [dbo].[IElementSet_Review]
ADD CONSTRAINT [FK_ReviewPost]
    FOREIGN KEY ([Post_Id])
    REFERENCES [dbo].[IElementSet_Post]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReviewPost'
CREATE INDEX [IX_FK_ReviewPost]
ON [dbo].[IElementSet_Review]
    ([Post_Id]);
GO

-- Creating foreign key on [User_Id] in table 'IElementSet_Review'
ALTER TABLE [dbo].[IElementSet_Review]
ADD CONSTRAINT [FK_UserReview]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[IElementSet_User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserReview'
CREATE INDEX [IX_FK_UserReview]
ON [dbo].[IElementSet_Review]
    ([User_Id]);
GO

-- Creating foreign key on [Id] in table 'IElementSet_Category'
ALTER TABLE [dbo].[IElementSet_Category]
ADD CONSTRAINT [FK_Category_inherits_IElement]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[IElementSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'IElementSet_Post'
ALTER TABLE [dbo].[IElementSet_Post]
ADD CONSTRAINT [FK_Post_inherits_IElement]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[IElementSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'IElementSet_Review'
ALTER TABLE [dbo].[IElementSet_Review]
ADD CONSTRAINT [FK_Review_inherits_IElement]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[IElementSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'IElementSet_User'
ALTER TABLE [dbo].[IElementSet_User]
ADD CONSTRAINT [FK_User_inherits_IElement]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[IElementSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------