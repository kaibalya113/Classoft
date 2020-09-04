USE [DindoriGym]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_all_student]    Script Date: 03-Jan-20 05:05:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_disp_all_student](@BranchID       VARCHAR(20),
                                              @from           DATE,

                                              @to             DATE,
                                              @USER_ID        VARCHAR(50) = 'SYSTEM',
                                              @NUM_ERROR_CODE INT OUTPUT)
AS
     BEGIN
         DECLARE @ACADEMIC_YEAR NUMERIC;
         DECLARE @AdmissionNo VARCHAR(100);
         BEGIN TRY
             
		  SET @NUM_ERROR_CODE = 1;
          SELECT  distinct
		  STUDENT_MASTER.STMT_MEMSHIP_NO,
		  student_admission.STAM_ADMISSION_NO,
                    STUDENT_MASTER.STMT_MEMSHIP_NO,
					STUDENT_MASTER.STMT_REMARK,
                    STUDENT_ADMISSION.STAM_ROLL_NO,
          STUDENT_MASTER.STMT_FNAME+' '+ISNULL(STUDENT_MASTER.STMT_LNAME, '') AS Name,
                    STUDENT_MASTER.STMT_ADMISSION_DATE,
                   STANDARD.STD_NAME,
                   STREAM.STRM_NAME,
                    BATCH.BTCH_NAME,
                    STUDENT_MASTER.STMT_CONTACT_NO,
                    STUDENT_MASTER.STMT_ADDRESS,
					STUDENT_MASTER.STMT_EMAIL_ID,
                    STUDENT_MASTER.STMT_FATHER_CONTACT,
					STUDENT_MASTER.STMT_BRANCH_ID,
			STUDENT_MASTER.STMT_GENDER,
			STUDENT_MASTER.STMT_SOURCE as Source,
			STUDENT_ADMISSION.STAM_IS_ACTIVE,
		    (select count(1) from STUDENT_FACILITIES where STFL_STATUS in('A','R') and STFL_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO) as active_packages,
                   FEES_PACKAGES.FPKG_PACKAGE_NAME  as "FPKG_PACKAGE_NAME",
                    CASE
                        WHEN STUDENT_MASTER.STMT_DEACTIVATED = 'NO'
                        THEN 'No'
                        WHEN STUDENT_MASTER.STMT_DEACTIVATED = 'YES'
                        THEN 'Yes'
                    END AS STMT_DEACTIVATED,
                    BRANCH_MASTER.BRCH_NAME,
				STREAM.STRM_ID, 
				BATCH.BTCH_Id,
			[STANDARD].STD_ID,[STANDARD].STD_NAME,
			   FEES_PACKAGES.FPKG_ID  as "FPKG_ID"
             FROM STUDENT_MASTER
			  LEFT OUTER JOIN STUDENT_ADMISSION ON STUDENT_ADMISSION.STAM_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                  LEFT OUTER JOIN FEES_PACKAGES ON FEES_PACKAGES.FPKG_ID = STUDENT_ADMISSION.STAM_PACKAGE_ID
			      LEFT OUTER JOIN STANDARD ON STANDARD.STD_ID = STUDENT_ADMISSION.STAM_STD_ID
                  LEFT OUTER JOIN STREAM ON STREAM.STRM_ID = STANDARD.STD_STREAM_ID
                  INNER JOIN BATCH ON STUDENT_ADMISSION.STAM_BATCH_ID = BATCH.BTCH_Id
                  INNER JOIN BRANCH_MASTER ON STUDENT_MASTER.STMT_BRANCH_ID = BRANCH_MASTER.BRCH_ID
             WHERE STUDENT_MASTER.STMT_BRANCH_ID LIKE @BranchID			        
                   AND STUDENT_MASTER.STMT_ADMISSION_DATE BETWEEN @from AND @to
				   
		
				         END TRY
         BEGIN CATCH
             EXECUTE sp_logError;
             SET @NUM_ERROR_CODE = 0;
         END CATCH;
     END;
