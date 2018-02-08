CREATE TABLE [dbo].[Users] (
    [Recordid]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (255) NOT NULL,
    [Surname]   VARCHAR (255) NULL,
    [isDeleted] INT           CONSTRAINT [DF_Users_isDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Recordid] ASC)
);

