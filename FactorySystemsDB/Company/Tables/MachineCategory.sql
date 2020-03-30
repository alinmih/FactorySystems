CREATE TABLE [Company].[MachineCategory] (
    [MachineCategoryId] INT           IDENTITY (1, 1) NOT NULL,
    [Category]          NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MachineCategory] PRIMARY KEY CLUSTERED ([MachineCategoryId] ASC)
);

