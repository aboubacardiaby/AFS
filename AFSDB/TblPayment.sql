CREATE TABLE [dbo].[tblPayment] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [LoanNumber]    NVARCHAR (100) NOT NULL,
    [DueDate]       DATETIME2 (7)  NOT NULL,
    [PaymentAmount] decimal(18,0)  NOT NULL,
    [PaymentType]   NVARCHAR (100) NOT NULL,
    [Comment]       NVARCHAR (MAX) NOT NULL,
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblPayment_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblPayment_CreatedBy] DEFAULT (suser_sname()),
    [UpdateDate]    DATETIME2 (7)  NOT NULL,    
    [UpdatedBy]    NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblPayment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_tblLoan_tblPayment_Loanumber] FOREIGN KEY ([LoanNumber]) REFERENCES [dbo].[tblLoan] ([LoanNumber])
);

GO
CREATE Trigger [dbo].[TR_tblPayment_UpdateDate_UpdatedBy] on [dbo].[TblPayment]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[tblPayment] SET [UpdateDate] = GETDATE(), [UpdatedBy] = SUSER_SNAME()
	FROM [tblPayment] AS L
	INNER JOIN Inserted AS i 
	ON L.Id = i.id
END


