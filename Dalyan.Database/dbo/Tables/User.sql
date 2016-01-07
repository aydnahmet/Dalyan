CREATE TABLE [dbo].[User] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]        INT            NULL,
    [Name]             NVARCHAR (50)  NULL,
    [Email]            NVARCHAR (50)  NULL,
    [Password]         NVARCHAR (150) NULL,
    [UserType]         INT            NULL,
    [CreatedDate]      DATETIME       NULL,
    [CreatedIpAddress] NVARCHAR (50)  NULL,
    [CreatedUserId]    INT            NULL,
    [UpdatedDate]      DATETIME       NULL,
    [UpdatedIpAddress] NVARCHAR (50)  NULL,
    [UpdatedUserId]    INT            NULL,
    [IsDeleted]        BIT            NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_CommonUserType] FOREIGN KEY ([UserType]) REFERENCES [dbo].[CommonUserType] ([Id]),
    CONSTRAINT [FK_User_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]),
    CONSTRAINT [FK_User_User] FOREIGN KEY ([UpdatedUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_User_User1] FOREIGN KEY ([CreatedUserId]) REFERENCES [dbo].[User] ([Id])
);

