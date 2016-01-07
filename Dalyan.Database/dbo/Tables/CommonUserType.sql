CREATE TABLE [dbo].[CommonUserType] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NULL,
    [IsDeleted] BIT           NULL,
    CONSTRAINT [PK_CommonUserType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

