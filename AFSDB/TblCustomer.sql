CREATE TABLE [dbo].[tblCustomer] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [CustId]           NVARCHAR (100) NOT NULL,
    [FirstName]        NVARCHAR (MAX) NOT NULL,
    [Name]             NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]      NVARCHAR (MAX) NOT NULL,
    [Address]          NVARCHAR (MAX) NOT NULL,
    [NationalIdNumber] NVARCHAR (MAX) NOT NULL,
    [JoinDate]         DATETIME2              NOT NULL, 
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblCustomer_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblCustomer_CreatedBy] DEFAULT (suser_sname()),
    [UpdateDate]       DATETIME2 (7)  NOT NULL,    
    [UpdatedBy]       NVARCHAR (MAX) NOT NULL,   
    CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED ([CustId] ASC)
);


GO
CREATE Trigger [dbo].[TR_tblcustomer_UpdateDate_UpdatedBy] on [dbo].[TblCustomer]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[TblCustomer] SET [UpdateDate] = GETDATE(), [UpdatedBy] = SUSER_SNAME()
	FROM [tblCustomer] AS L
	INNER JOIN Inserted AS i 
	ON L.CustId = i.CustId
END