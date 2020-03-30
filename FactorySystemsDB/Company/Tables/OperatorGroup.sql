CREATE TABLE [Company].[OperatorGroup] (
    [OperatorGroupId] INT            IDENTITY (1, 1) NOT NULL,
    [GroupName]       NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_OperatorGroup] PRIMARY KEY CLUSTERED ([OperatorGroupId] ASC)
);

