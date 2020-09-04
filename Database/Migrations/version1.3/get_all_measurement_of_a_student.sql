USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_all_measurements_of_student]    Script Date: 19/01/21 5:03:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[s_pr_get_all_measurements_of_student]
(@admissionNo int,
@BranchId varchar(20),
 
--@sms_sent_date date,
 @NUM_ERROR_CODE INT OUTPUT
)
AS
     BEGIN
         BEGIN TRY

	      
	    SET @NUM_ERROR_CODE = 1
		select * from MEASUREMENTS where mm_admissionno=@admissionNo
		and mm_branchid= @BranchId

         END TRY
         BEGIN CATCH
             SET @NUM_ERROR_CODE = 0;
             EXEC SP_LogError;
         END CATCH;
     END;




