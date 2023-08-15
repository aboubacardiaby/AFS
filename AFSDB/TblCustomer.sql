﻿CREATE TABLE [dbo].[tblCustomer] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [CustId]           NVARCHAR (100) NOT NULL,
    [FirstName]        NVARCHAR (100) NOT NULL,
    [LastName]         NVARCHAR (100) NOT NULL,
    [Genre]            NVARCHAR (100) NOT NULL,
    [Email]            NVARCHAR (100)     NULL,
    [PhoneNumber]      NVARCHAR (100) NOT NULL,
    [Address]          NVARCHAR (100) NOT NULL, 
    [Region]           NVARCHAR (100) NOT NULL,
    [NationalIdNumber] NVARCHAR (100) NOT NULL,
    [JoinDate]         DATETIME      NOT NULL, 
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblCustomer_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblCustomer_CreatedBy] DEFAULT (suser_sname()),
    [UpdateDate]       DATETIME   NULL,    
    [UpdatedBy]       NVARCHAR (100)  NULL,   
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
	ON L.id = i.Id
END