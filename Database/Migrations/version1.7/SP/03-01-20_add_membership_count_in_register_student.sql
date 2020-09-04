USE [classwise]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_register_student]    Script Date: 03-01-2020 12:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_register_student](@AdmissionDate     DATE,
                                              @Fname             VARCHAR(50),
                                              @Mname             VARCHAR(50),
                                              @Lname             VARCHAR(50),
                                              @Address           VARCHAR(50),
                                              @ContactNo         VARCHAR(50),
                                              @Gender            VARCHAR(50),
                                              @Dob               DATE,
                                              @FatherName        VARCHAR(50),
                                              @FathersOccupation VARCHAR(50)   = '',
                                              @MothersOccupation VARCHAR(50)   = '',
                                              @FatherContactNo   VARCHAR(50),
                                              @MotherContactNo   VARCHAR(50)   = '',
                                              @EnquiryID         INT,
                                              @EmailId           VARCHAR(50),
                                              @AcadmicInfo       VARCHAR(4000),
                                              @BatchID           VARCHAR(100),
                                              @BranchID          VARCHAR(20),
                                              @biometric_id      INT,
                                              @PhotoURL          VARCHAR(MAX) OUTPUT,
                                              @AdmissionNo       INT OUTPUT,
                                              @MemberShipNo      VARCHAR(50),
                                              @ACADEMIC_YEAR     INT OUTPUT,
                                              @RollNo            VARCHAR(100) OUTPUT,
                                              @FeesId            INT OUTPUT,
                                              @Adhar_no          VARCHAR(50),
                                              @Remark            VARCHAR(400),
                                              @BloodGroup        VARCHAR(50),
                                              @Weight            VARCHAR(50),
                                              @BMI               VARCHAR(50),
                                              @Height            VARCHAR(50),
											  @Refer             VARCHAR(50),
											  @category          VARCHAR(50),
											  @GST               VARCHAR(50),
											  @counselor          VARCHAR(50),
											  @Source varchar(50),
											  @HeathIssue varchar(500),
                                              @USER_ID           VARCHAR(50)   = 'SYSTEM',
                                              @NUM_ERROR_CODE    INT OUTPUT)
AS
     BEGIN
         BEGIN TRY
             SET @NUM_ERROR_CODE = 1;
             DECLARE @ID INT;
             DECLARE @Stream VARCHAR(20);
             DECLARE @COUNT INT;
             DECLARE @lgnReg INT;
             DECLARE @loginId INT;
             DECLARE @appendBranch bit;
			 DECLARE @countStudent int;
             /* Check if student already registred */

			   SET @appendBranch =
                     (
                         SELECT PRM_VALUE
                         FROM SYSTEM_PRM
                         WHERE PRM_NAME = 'APPEND_BRANCH_ID'
                     );
             IF NOT EXISTS
             (
                 SELECT '1'
                 FROM STUDENT
                      INNER JOIN STUDENT_MASTER ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                                                   AND STUDENT_MASTER.STMT_CONTACT_NO = @ContactNo
                                                   AND STUDENT_MASTER.STMT_FNAME = @Fname
                                                   AND STUDENT_MASTER.STMT_BRANCH_ID = @BranchID
             )
                 BEGIN
                     IF(@AdmissionDate IS NOT NULL)
                         BEGIN
                             SET @AdmissionDate = @AdmissionDate;
                         END;
                     ELSE
                         BEGIN
                             SET @AdmissionDate = GETDATE();
                         END;
                     SET @COUNT =
                     (
                         SELECT BRANCH_MASTER.ADMISSION_COUNT
                         FROM BRANCH_MASTER
                         WHERE BRANCH_MASTER.BRCH_ID = @BranchID
                     );
                     SET @ID = @COUNT + 1;
					 if(@appendBranch = 1)
					 begin
                     SET @AdmissionNo = CONVERT(INT, CONVERT(VARCHAR, @BranchID) + CONVERT(VARCHAR, @ID));
					 end
					 else
					 begin 
					  SET @AdmissionNo =   @ID;
					 end
                     SET @RollNo = @AdmissionNo;
                   
                     INSERT INTO LOGIN
                     (LGN_TYPE,
                      LGN_BRANCH_ID,
                      LGN_PASSWORD,
                      LGN_USER_ID,
                      LGN_REGID
                     )
                     VALUES
                     ('S',
                      @BranchID,
                      @Fname + CONVERT( NVARCHAR, @AdmissionNo),
                      @Fname + CONVERT( NVARCHAR, @AdmissionNo),
                      @AdmissionNo
                     );
					BEGIN
							--SET @countStudent = (select COUNT(*) from STUDENT_MASTER);
						--	BEGIN
						--	update BRANCH_MASTER set  MEMBERSHIP_COUNT = @countStudent;
						--	END;
						     SET @countStudent=(SELECT BRANCH_MASTER.MEMBERSHIP_COUNT FROM BRANCH_MASTER WHERE BRANCH_MASTER.BRCH_ID = @BranchID);
                             SET @MemberShipNo = @countStudent+1;
							 update branch_master set MEMBERSHIP_COUNT=@MemberShipNo;
                         END;
                     IF(@MemberShipNo IS NULL
                        OR @MemberShipNo = '')
                         
						 
						IF EXISTS (select * from student_master where STMT_MEMSHIP_NO=@MemberShipNo) 
						BEGIN
						 SET @NUM_ERROR_CODE = 54;
						 return;
						 END;

                     INSERT INTO STUDENT_MASTER
                     (STMT_ADMISSION_NO,
                      STMT_FNAME,
                      STMT_MNAME,
                      STMT_LNAME,
                      STMT_ADDRESS,
                      STMT_CONTACT_NO,
                      STMT_GENDER,
                      STMT_DOB,
                      STMT_FATHER_NAME,
                      STMT_FATHER_OCCUPATION,
                      STMT_MOTHER_OCCUPATION,
                      STMT_FATHER_CONTACT,
                      STMT_ADMISSION_DATE,
                      STMT_ENQUIRY_ID,
                      STMT_ACADEMIC_INFO,
                      STMT_CRTD_AT,
                      STMT_CRTD_BY,
                      STMT_MOTHER_CONTACT,
                      STMT_EMAIL_ID,
                      STMT_BRANCH_ID,
                      STMT_DEACTIVATED,
                      STMT_MEMSHIP_NO,
                      STMT_ID,
                      STMT_ADHARCARD_NO,
                      STMT_REMARK,
                      STMT_BLOODGROUP,
                      STMT_BMI,
                      STMT_WEIGHT,
                      STMT_HEIGHT,
                      STMT_LGN_REGD_ID,
					  STMT_COUNSELOR
					  ,STMT_CATEGORY
					  ,STMT_REFERENCE,
					  STMT_HEATH_ISSUE   -------added heath issue in student master by ashvini 19-01-2019
					  ,STMT_SOURCE
					  ,STMT_GST_NO
                     )
                     VALUES
                     (@AdmissionNo,
                      @Fname,
                      @Mname,
                      @Lname,
                      @Address,
                      @ContactNo,
                      @Gender,
                      @Dob,
                      @FatherName,
                      @FathersOccupation,
                      @MothersOccupation,
                      @FatherContactNo,
                      @AdmissionDate,
                      @EnquiryID,
                      @AcadmicInfo,
                      GETDATE(),
                      @USER_ID,
                      @MotherContactNo,
                      @EmailId,
                      @BranchID,
                      'NO',
                      @MemberShipNo,
                      @AdmissionNo,
                      @Adhar_no,
                      @Remark,
                      @BloodGroup,
                      @BMI,
                      @Weight,
                      @Height,
                      @loginId,
					  @counselor,
					  @category,
					  @Refer,
					  @HeathIssue, ------added parameter for  STMT_HEATH_ISSUE 
					  @Source,
					  @GST
                     );
                     IF(@biometric_id != -1)
                         BEGIN
                             INSERT INTO BIOMERIC_MAPPING
                             (BIOM_ADMISSION_NO,
                              BIOM_BIOMETRIC_ID,
                              BIOM_BRANCH_ID,
                              BIOM_CRTD_AT,
                              BIOM_CRTD_BY
                             )
                             VALUES
                             (@AdmissionNo,
                              @biometric_id,
                              @BranchID,
                              GETDATE(),
                              @USER_ID
                             );
                         END;
                     ELSE
                         BEGIN
                             INSERT INTO BIOMERIC_MAPPING
                             (BIOM_ADMISSION_NO,
                              BIOM_BIOMETRIC_ID,
                              BIOM_BRANCH_ID,
                              BIOM_CRTD_AT,
                              BIOM_CRTD_BY
                             )
                             VALUES
                             (@AdmissionNo,
                              @AdmissionNo,
                              @BranchID,
                              GETDATE(),
                              @USER_ID
                             );
                         END;
                   
                     SET @PhotoURL = CONVERT(VARCHAR, @AdmissionNo)+'.jpeg';
                     UPDATE STUDENT_MASTER
                       SET
                           STMT_PHOTO_URL = @PhotoURL,
                           STMT_UPDT_AT = GETDATE(),
                           STMT_UPDAT_BY = @USER_ID
                     WHERE STMT_ADMISSION_NO = @AdmissionNo;
                     SET @ACADEMIC_YEAR =
                     (
                         SELECT PRM_VALUE
                         FROM SYSTEM_PRM
                         WHERE PRM_NAME = 'ACADEMIC_YEAR'
                     );
                     INSERT INTO FEES
                     (FEE_ADMISSION_NO,
                      FEE_ACADEMIC_YEAR,
                      FEE_TOTAL_FEES,
                      FEE_FEES_PAID,
                      FEE_DISCOUNT,
                      FEE_TUTION_AMOUNT,
                      FEE_FINE_AMOUNT,
                      FEE_BOOKING_AMOUNT,
                      FEE_PAYMENT_TYPE,
                      FEE_LAST_INSTALLMENT_PAID_ID,
                      FEE_REG_AMOUNT,
                      FEE_MISC_AMOUNT,
                      FEE_BRANCH_ID,
                      FEE_CANCD_FEES,
                      FEE_PNDG_CHEQUE_AMNT,
                      FEE_CRTD_AT,
                      FEE_CRTD_BY
                     )
                     VALUES
                     (@AdmissionNo,
                      @ACADEMIC_YEAR,
                      0,
                      0,
                      0,
                      0,
                      0,
                      0,
                      0,
                      -1,
                      0,
                      0,
                      @BranchID,
                      0,
                      0,
                      GETDATE(),
                      @USER_ID
                     );
                     SET @FeesId =
                     (
                         SELECT FEE_ID
                         FROM FEES
                         WHERE(ID = SCOPE_IDENTITY())
                              AND (FEE_BRANCH_ID = @BranchID)
                     );
                     INSERT INTO STUDENT
                     (STUD_ADMISSION_NO,
                      STUD_FEES_ID,
                      STUD_ADMTN_DATE,
                      STUD_BRANCH_ID,
                      STUD_CRTD_AT,
                      STUD_CRTD_BY
                     )
                     VALUES
                     (@AdmissionNo,
                      @FeesId,
                      @AdmissionDate,
                      @BranchID,
                      GETDATE(),
                      @USER_ID
                     );
                     UPDATE ENQUIRY
                       SET
                           ENQ_IS_REGISTERED = 1,
                           ENQ_UPDT_AT = GETDATE(),
                           ENQ_UPDAT_BY = @USER_ID
                     WHERE ENQ_ID = @EnquiryID;
                     IF EXISTS
                     (
                         SELECT '1'
                         FROM MARKETING
                         WHERE MKTG_STUDENT_NAME = @Fname
                               AND MKTG_PHONE_NO = @ContactNo
                     )
                         BEGIN
                             UPDATE MARKETING
                               SET
                                   MKTG_BIRTH_DATE = @Dob,
                                   MKTG_ANIVERSRY_DATE = NULL,
                                   MKTG_STUDENT_TYPE = 'REG',
                                   MKTG_UPDAT_BY = @USER_ID,
                                   MKTG_UPDT_AT = GETDATE()
                             WHERE MKTG_STUDENT_NAME = @Fname
                                   AND MKTG_PHONE_NO = @ContactNo;
                         END;
                     ELSE
                     INSERT INTO MARKETING
                     (MKTG_STUDENT_NAME,
                      MKTG_PHONE_NO,
                      MKTG_STREAM,
                      MKTG_BIRTH_DATE,
                      MKTG_ANIVERSRY_DATE,
                      MKTG_STUDENT_TYPE,
                      MKTG_BRANCH_ID,
                      MKTG_CRTD_AT,
                      MKTG_CRTD_BY
                     )
                     VALUES
                     (@Fname,
                      @ContactNo,
                      'STUDENT',
                      @Dob,
                      NULL,
                      'REG',
                      @BranchID,
                      GETDATE(),
                      @USER_ID
                     );
                     UPDATE BRANCH_MASTER
                       SET
                           ADMISSION_COUNT = (ADMISSION_COUNT + 1)
                     WHERE BRANCH_MASTER.BRCH_ID = @BranchID;
                 END;
             ELSE
                 BEGIN
                     SET @NUM_ERROR_CODE = 3;
			      set @AdmissionNo = (SELECT STMT_ADMISSION_NO
                                          FROM STUDENT
                                           INNER JOIN STUDENT_MASTER ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                                           AND STUDENT_MASTER.STMT_CONTACT_NO = @ContactNo
                                           AND STUDENT_MASTER.STMT_FNAME = @Fname
                                           AND STUDENT_MASTER.STMT_BRANCH_ID = @BranchID);
				 set @RollNo = @AdmissionNo;
			
									 
                 END;
				 EXECUTE sp_logError;
         END TRY
         BEGIN CATCH
			select ERROR_MESSAGE() as error
             EXEC SP_LogError;
             SET @NUM_ERROR_CODE = 0;
         END CATCH;
     END;






