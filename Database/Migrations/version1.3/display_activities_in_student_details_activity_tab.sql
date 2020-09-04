USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_activities]    Script Date: 19/01/09 4:11:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_get_activities]
(@admissionNo int,
@BranchId varchar(20),
 
--@sms_sent_date date,
 @NUM_ERROR_CODE INT OUTPUT
)
AS
     BEGIN
         BEGIN TRY

	      
	    SET @NUM_ERROR_CODE = 1
		select * from ACTIVITY_LOG where ACT_ADMISSIONNO =@admissionNo
		and ACT_BRANCH_ID= @BranchId

         END TRY
         BEGIN CATCH
             SET @NUM_ERROR_CODE = 0;
             EXEC SP_LogError;
         END CATCH;
     END;




