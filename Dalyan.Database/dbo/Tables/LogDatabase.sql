CREATE TABLE [dbo].[LogDatabase] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [UserId]          INT             NULL,
    [LogDate]         DATETIME        NULL,
    [LogType]         NVARCHAR (50)   NULL,
    [LogLevel]        NVARCHAR (50)   NULL,
    [ExceptionString] NVARCHAR (4000) NULL,
    [Comment]         NVARCHAR (4000) NULL,
    [IsDeleted]       BIT             NULL,
    CONSTRAINT [PK_LogDatabase] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LogDatabase_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

