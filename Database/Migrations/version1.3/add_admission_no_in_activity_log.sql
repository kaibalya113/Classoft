USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_insert_activityLog]    Script Date: 19/01/05 5:08:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_insert_activityLog]
(@AdmissionNo Int,
@date                 date,
 @activity             varchar(5000),
 @user                 varchar(500),
 @oldValue             varchar(500),
 @newValue             varchar(500),
 @branch               varchar(50),
 @USER_ID              VARCHAR(50)    = 'SYSTEM',
 @NUM_ERROR_CODE       INT OUTPUT
)
AS
begin try
     BEGIN
  INSERT INTO  [ACTIVITY_LOG]
					(
					ACT_DATE,
					ACT_DESC,
					ACT_USER,
						ACT_ADMISSIONNO,
					ACT_OLD_VALUE,
					ACT_NEW_VALUE,
					ACT_BRANCH_ID,
					ACT_CRTD_AT,
					ACT_CRTD_BY
			
					)

					values
					(
					@date,
					@activity,
				    @user,
				@AdmissionNo,
					@oldValue,
					@newValue,
					@branch,
					GETDATE(),
			
					@USER_ID
					);
								
				END;
			 SET @NUM_ERROR_CODE =1;
         END TRY
         BEGIN CATCH
             EXECUTE sp_logError;
             SET @NUM_ERROR_CODE = 0;
             SELECT ERROR_MESSAGE() AS ErrorMessage;
         END CATCH;




