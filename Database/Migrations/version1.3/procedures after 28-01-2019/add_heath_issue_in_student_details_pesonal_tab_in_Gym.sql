USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_update_student_details]    Script Date: 19/01/28 12:07:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Name : s_pr_update_student_details
--Developer : Hemlata
--Purpose : This Procedure is used to Update the Details of the Students.
--Tables Used : STUDENT_MASTER, MARKETING,SYSTEM_PRM, STUDENT_ADMISSION,BIOMERIC_MAPPING (Select, Update)
--SP Used : SP_LogError
--Called From : StudentHandler.updateStudPersnlDtl() in FrmStudentDetails.
--Change History 
----------------------------------------------------------------------
--Date		Change		Perpose				Developer



ALTER PROCEDURE [dbo].[s_pr_update_student_details](@AdmisionNo     INT,
                                                    @FName          VARCHAR(20),
                                                    @MName          VARCHAR(20),
                                                    @LName          VARCHAR(20),
                                                    @Address        VARCHAR(200),
                                                    @ContactNo      VARCHAR(20),
                                                    @Gender         VARCHAR(20),
                                                    @DOB            DATE,
                                                    @biometricId    INT,
                                                    @MembershipNo   VARCHAR(20),
                                                    @FatherName     VARCHAR(20),
                                                    @FContactNo     VARCHAR(20),
                                                    @EmailID        VARCHAR(50),
                                                    @BatchId        INT,
                                                    @Bloodgroup     VARCHAR(50),
                                                    @BMI            VARCHAR(50),
													@HealthIssue Varchar(500),
                                                    @Weight         VARCHAR(50),
                                                    @Height         VARCHAR(50),
                                                    @remark         VARCHAR(500),
													@category       varchar(50),
													@counselor      varchar(50),
													@school         varchar(50),
                                                    @PhotoURL       VARCHAR(MAX) OUTPUT,
                                                    @USER_ID        VARCHAR(50)  = 'SYSTEM',
                                                    @NUM_ERROR_CODE INT OUTPUT)
AS
     DECLARE @Name VARCHAR(100);
     DECLARE @phone VARCHAR(50);
    BEGIN TRY
      
        SELECT @Name = STMT_FNAME,
               @phone = STMT_CONTACT_NO
        FROM STUDENT_MASTER
        WHERE STMT_ADMISSION_NO = @AdmisionNo;

        UPDATE MARKETING
          SET
              MKTG_EMAILID = @EmailID,
              MKTG_BIRTH_DATE = @DOB,
              MKTG_PHONE_NO = @ContactNo,
              MKTG_UPDT_AT = GETDATE(),
              MKTG_UPDAT_BY = @USER_ID
        WHERE MKTG_STUDENT_NAME = @Name
              AND MKTG_PHONE_NO = @phone
              AND MKTG_STUDENT_TYPE = 'REG';

     

        SET @PhotoURL = CONVERT(VARCHAR, @AdmisionNo)+'.jpeg';

        UPDATE STUDENT_MASTER
          SET
              STUDENT_MASTER.STMT_FNAME = @FName,
              STUDENT_MASTER.STMT_MNAME = @MName,
              STUDENT_MASTER.STMT_LNAME = @LName,
              STUDENT_MASTER.STMT_ADDRESS = @Address,
              STUDENT_MASTER.STMT_CONTACT_NO = @ContactNo,
              STUDENT_MASTER.STMT_GENDER = @Gender,
              STUDENT_MASTER.STMT_DOB = @DOB,
              STUDENT_MASTER.STMT_FATHER_NAME = @FatherName,
              STUDENT_MASTER.STMT_FATHER_CONTACT = @FContactNo,
              STUDENT_MASTER.STMT_EMAIL_ID = @EmailID,
              STUDENT_MASTER.STMT_MEMSHIP_NO = @MembershipNo,
              STMT_BLOODGROUP = @Bloodgroup,
              STMT_WEIGHT = @Weight,
              STMT_BMI = @BMI,
			  STMT_HEATH_ISSUE=@HealthIssue,
              STMT_HEIGHT = @Height,
              STMT_REMARK = @remark,
			  STMT_CATEGORY =@category,
			  STMT_COUNSELOR = @counselor,
			  STMT_ADHARCARD_NO = @school,
              STMT_UPDT_AT = GETDATE(),
              STMT_UPDAT_BY = @USER_ID,
              student_master.stmt_photo_url = @PhotoURL
        WHERE STUDENT_MASTER.STMT_ADMISSION_NO = @AdmisionNo;
     
        --BatchID is 0 when no batch is there so it should not get update.
        IF(@BatchId != 0)
            BEGIN
                UPDATE STUDENT_ADMISSION
                  SET
                      STAM_BATCH_ID = @BatchId,
                      STAM_UPDT_AT = GETDATE(),
                      STAM_UPDAT_BY = @USER_ID
                WHERE STAM_ADMISSION_NO = @AdmisionNo;
            END;
        UPDATE BIOMERIC_MAPPING
          SET
              BIOMERIC_MAPPING.BIOM_BIOMETRIC_ID = @biometricId,
              BIOM_UPDT_AT = GETDATE(),
              BIOM_UPDAT_BY = @USER_ID
        WHERE BIOMERIC_MAPPING.BIOM_ADMISSION_NO = @AdmisionNo;
        SET @NUM_ERROR_CODE = 1;
    END TRY
    BEGIN CATCH
        EXECUTE sp_logError;
        SET @NUM_ERROR_CODE = 0;
    END CATCH;




