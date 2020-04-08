CREATE TABLE [Company].[Operator] (
    [OperatorId]      INT            IDENTITY (1, 1) NOT NULL,
    [DutyId]          INT            NOT NULL,
    [OperatorGroupId] INT            NOT NULL,
    [DepartmentId]    INT            NOT NULL,
    [BadgeNumber]     NVARCHAR (200) NOT NULL,
    [FirstName]       NVARCHAR (200) NOT NULL,
    [LastName]        NVARCHAR (200) NOT NULL,
    [LastActionTime]  DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED ([OperatorId] ASC),
    CONSTRAINT [FK_Operator_Department] FOREIGN KEY ([DepartmentId]) REFERENCES [Company].[Department] ([DepartmentId]),
    CONSTRAINT [FK_Operator_Duty] FOREIGN KEY ([DutyId]) REFERENCES [Company].[OperatorDuty] ([DutyId]),
    CONSTRAINT [FK_Operator_OperatorGroup] FOREIGN KEY ([OperatorGroupId]) REFERENCES [Company].[OperatorGroup] ([OperatorGroupId])
);



