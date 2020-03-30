CREATE TABLE [dbo].[ErrorLog] (
    [ErrorLogID]     INT            IDENTITY (1, 1) NOT NULL,
    [UserName]       NVARCHAR (50)  NULL,
    [ErrorNumber]    INT            NULL,
    [ErrorSeverity]  INT            NULL,
    [ErrorState]     INT            NULL,
    [ErrorProcedure] NVARCHAR (100) NULL,
    [ErrorLine]      INT            NULL,
    [ErrorMessage]   NCHAR (200)    NULL,
    CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED ([ErrorLogID] ASC)
);

