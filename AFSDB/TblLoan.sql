CREATE TABLE [dbo].[tblLoan] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [LoanNumber] NVARCHAR (100) NOT NULL,
    [LoanName]    NVARCHAR (100) NOT NULL,
    [LoanType]    NVARCHAR (75)  NOT NULL,
    [LoanAmount]  DECIMAL        NOT NULL,
    [CustId]  NVARCHAR(100)      NOT NULL,
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblLoan_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblLoan_CreatedBy] DEFAULT (suser_sname()),
    [UpdateDate]  DATETIME2 (7)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblLoan] PRIMARY KEY CLUSTERED ([LoanNumber] ASC),
    CONSTRAINT [FK_tblLoan_tblCustomer_CustomerId] FOREIGN KEY ([CustId]) REFERENCES [dbo].[tblCustomer] ([CustId])
);

GO
CREATE Trigger [dbo].[TR_tbloan_UpdateDate_UpdatedBy] on [dbo].[TblLoan]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[TblLoan] SET [UpdateDate] = GETDATE(), [UpdatedBy] = SUSER_SNAME()
	FROM [tblLoan] AS L
	INNER JOIN Inserted AS i 
	ON L.Id = i.id
END

