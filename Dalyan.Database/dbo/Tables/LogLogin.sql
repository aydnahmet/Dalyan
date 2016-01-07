CREATE TABLE [dbo].[LogLogin] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [UserId]          INT             NULL,
    [LogDate]         DATETIME        NULL,
    [LoginLogType]    NVARCHAR (50)   NULL,
    [ExceptionString] NVARCHAR (4000) NULL,
    [Comment]         NVARCHAR (4000) NULL,
    [IsDeleted]       BIT             NULL,
    CONSTRAINT [PK_LogLogin] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LogLogin_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

