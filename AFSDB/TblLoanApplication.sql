CREATE TABLE [dbo].[TblLoanApplication]
(
	[Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [CustId] NVARCHAR (100) NOT NULL,
	[PrimaryOfficer] NVARCHAR(100) NOT NULL,
	[PreparedBy] NVARCHAR(100) NOT NULL,
	[BusinessPurpose] NVARCHAR(MAX) NULL,
	[PreviousBusiness] NVARCHAR(100) NULL,
	[Amount] NVARCHAR(100) NULL,
	[Term] NVARCHAR(100) NULL,
	[ApplicationStatus] NVARCHAR(100) NULL,
	[CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblLoanapp_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblLoanapp_CreatedBy] DEFAULT (suser_sname()),   
    CONSTRAINT [PK_tblLoanApp] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_tblLoanApp_tblCustomer_CustomerId] FOREIGN KEY ([CustId]) REFERENCES [dbo].[tblCustomer] ([CustId])
);

GO

