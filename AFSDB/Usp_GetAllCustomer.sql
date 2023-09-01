CREATE PROCEDURE [dbo].[Usp_GetAllCustomer]
	
AS
	SELECT [CustId],[FirstName],[LastName],[Genre],[Email],[PhoneNumber],[Address],[Region],[NationalIdNumber],[JoinDate] from [dbo].[tblCustomer]
