CREATE PROCEDURE [dbo].[Usp_AddOrEditCustomer]
	 @CustId Varchar(100)
      ,@FirstName Varchar(100)
      ,@LastName Varchar(100)
      ,@Genre Varchar(100)
      ,@Email Varchar(100)
      ,@PhoneNumber Varchar(100)
      ,@Address Varchar(100)
      ,@Region Varchar(100)
      ,@NationalIdNumber Varchar(100)
      ,@JoinDate DateTime
AS
	BEGIN
    SET NOCOUNT ON
	DECLARE @DateTimeUTC datetime = GETUTCDATE(),
				@ErrorMessage varchar(2000),
				@CurrentSourceDateTime datetime = '1/1/1900'
	BEGIN TRY
		BEGIN TRANSACTION

		MERGE [dbo].[tblCustomer] as TARGET

		USING (SELECT @CustId  as CustId) as SOURCE 
		ON TARGET.CustId = @CustId
		


		--WHEN MATCHED UPDATE RECORD
		WHEN MATCHED
		THEN UPDATE SET			
			TARGET.CustId = @CustId,
			TARGET.FirstName = @FirstName,
			TARGET.LastName = @Lastname,
			TARGET.Genre = @Genre,
			TARGET.Email = @Email,
			TARGET.PhoneNumber = @PhoneNumber,
			TARGET.Address = @Address,
			TARGET.Region = @Region,
			TARGET.NationalIdNumber = @NationalIdNumber,
			TARGET.JoinDate = @JoinDate
			
		--WHEN NOT MATCHED INSERT
		WHEN NOT MATCHED BY TARGET
		THEN INSERT
			([CustId]
           ,[FirstName]
           ,[LastName]
           ,[Genre]
           ,[Email]
           ,[PhoneNumber]
           ,[Address]
           ,[Region]
           ,[NationalIdNumber]
           ,[JoinDate]
          )	
			
		VALUES
			( @CustId 
			  ,@FirstName 
			  ,@LastName 
			  ,@Genre
			  ,@Email
			  ,@PhoneNumber
			  ,@Address
			  ,@Region
			  ,@NationalIdNumber 
			  ,@JoinDate
			);

	--COMPLETE
		

	END TRY
	BEGIN CATCH
		--ERROR
		IF @@TRANCOUNT > 0 ROLLBACK
		SELECT @ErrorMessage = ERROR_MESSAGE()
	
	END CATCH

	
	
END

