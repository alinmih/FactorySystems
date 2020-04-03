CREATE TABLE [Company].[Machine] (
    [MachineId]         INT             IDENTITY (1, 1) NOT NULL,
    [CostCenterId]      INT             NOT NULL,
    [MachineCategoryId] INT             NOT NULL,
    [MachineStatusId]   INT             NOT NULL,
    [Name]              NVARCHAR (200)  NOT NULL,
    [Description]       NVARCHAR (4000) NULL,
    [RatePerHour]       MONEY           NULL,
    [SetupTime]         NUMERIC (18, 3) NULL,
    [ProcessTime]       NUMERIC (18, 3) NULL,
    [PartsPerCycle]     NUMERIC (18, 1) NULL,
    [AlarmOnOff]        INT             NULL,
    [AlarmDate]         DATETIME2 (7)   NULL,
    [ActivityDate]      DATETIME2 (7)   NULL,
    [LastActivityDate]  DATETIME2 (7)   NULL,
    [ModifiedDate]      DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Machine] PRIMARY KEY CLUSTERED ([MachineId] ASC),
    CONSTRAINT [FK_Machine_CostCenter] FOREIGN KEY ([CostCenterId]) REFERENCES [Company].[CostCenter] ([CostCenterId]),
    CONSTRAINT [FK_Machine_MachineCategory] FOREIGN KEY ([MachineCategoryId]) REFERENCES [Company].[MachineCategory] ([MachineCategoryId]),
    CONSTRAINT [FK_Machine_MachineStatus] FOREIGN KEY ([MachineStatusId]) REFERENCES [Company].[MachineStatus] ([MachineStatusId])
);



