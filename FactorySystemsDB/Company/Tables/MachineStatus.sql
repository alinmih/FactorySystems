CREATE TABLE [Company].[MachineStatus] (
    [MachineStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Status]          NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MachineStatus] PRIMARY KEY CLUSTERED ([MachineStatusId] ASC)
);

