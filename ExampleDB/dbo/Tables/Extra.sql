CREATE TABLE [dbo].[Extra] (
    [Recordid]  INT IDENTITY (1, 1) NOT NULL,
    [Usersid]   INT NOT NULL,
    [Age]       INT NOT NULL,
    [isDeleted] INT CONSTRAINT [DF_Extra_isDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Extra] PRIMARY KEY CLUSTERED ([Recordid] ASC),
    CONSTRAINT [FK_Extra_Users] FOREIGN KEY ([Usersid]) REFERENCES [dbo].[Users] ([Recordid])
);

