CREATE TABLE [dbo].[TblEmployee]
(
    [Id]  INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeId]  NVARCHAR(100)   NOT NULL,
    [Name]        NVARCHAR (100)  NOT NULL,
    [Address]     NVARCHAR (200)  NOT NULL,
    [Designation] NVARCHAR (100)   NULL,
    [Salary]      DECIMAL (18, 2) NOT NULL,
    [JoiningDate] DATETIME2 (7)   NOT NULL,
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblEmployee_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblEmployee_CreatedBy] DEFAULT (suser_sname()),
    [UpdateDate]  DATETIME2 (7)  NOT NULL,
    [UpdatedBy]  NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
)
GO
CREATE Trigger [dbo].[TR_tbltblEmployee_UpdateDate_UpdatedBy] on [dbo].[TblPayment]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[TblEmployee] SET [UpdateDate] = GETDATE(), [UpdatedBy] = SUSER_SNAME()
	FROM [TblEmployee] AS L
	INNER JOIN Inserted AS i 
	ON L.Id = i.id
END
