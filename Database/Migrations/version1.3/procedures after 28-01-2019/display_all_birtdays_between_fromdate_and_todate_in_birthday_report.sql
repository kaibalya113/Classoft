USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_birthdays_report]    Script Date: 19/01/28 12:51:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_get_birthdays_report](@FromDate           date,
                                           @Todate date,
                                           @USER_ID        VARCHAR(50) = 'SYSTEM',
                                           @branchId       VARCHAR(10),
                                           @NUM_ERROR_CODE INT OUTPUT)
AS
     BEGIN
         BEGIN TRY
             SELECT DISTINCT  [MKTG_STUDENT_NAME],[MKTG_PHONE_NO],
		    [MKTG_ID]
      ,[MKTG_STREAM]
      ,[MKTG_BIRTH_DATE]
   
      ,[MKTG_EMAILID]
      ,[MKTG_STUDENT_TYPE]
      ,[MKTG_BRANCH_ID]
      ,[MKTG_CRTD_AT]
      ,[MKTG_UPDT_AT]
      ,[MKTG_DLTD_AT]
      ,[MKTG_CRTD_BY]
      ,[MKTG_UPDAT_BY]
      ,[MKTG_DLTD_BY]
      
             FROM MARKETING
             WHERE (MARKETING.MKTG_BIRTH_DATE between @FromDate and @Todate)
                   AND MARKETING.MKTG_BRANCH_ID LIKE @branchId;


		   --select * from MARKETING where MKTG_BIRTH_DATE=@Date
		   -- and MKTG_BRANCH_ID like @branchId
             SET @NUM_ERROR_CODE = 1;
         END TRY
         BEGIN CATCH
             EXEC SP_LogError;
             SET @NUM_ERROR_CODE = 0;
         END CATCH;
     END;




