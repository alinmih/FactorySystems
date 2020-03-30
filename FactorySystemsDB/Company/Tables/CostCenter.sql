CREATE TABLE [Company].[CostCenter] (
    [CostCenterId] INT             IDENTITY (1, 1) NOT NULL,
    [DepartmentId] INT             NOT NULL,
    [Name]         NVARCHAR (200)  NOT NULL,
    [Description]  NVARCHAR (4000) NULL,
    [Cost]         MONEY           NULL,
    [AverageCost]  MONEY           NULL,
    [ModifiedDate] DATETIME2 (7)   NULL,
    CONSTRAINT [PK_CostCenter] PRIMARY KEY CLUSTERED ([CostCenterId] ASC)
);

