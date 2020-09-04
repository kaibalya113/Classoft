USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_student_by_group]    Script Date: 19/02/08 5:40:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Name : s_pr_get_student_By_GroupBy
--Developer : Hemlata
--Purpose : This procedure is used to Get Students count according to the Standard,Stream and Batch.
--Tables Used : STUDENT_MASTER, FEES_PACKAGES,STREAM,STUDENT_ADMISSION(Select)
--SP Used : SP_LogError
--Called From : StudentHandler.s_pr_get_student_By_GroupBy() in FrmStudents.
--Change History 
----------------------------------------------------------------------
--Date		Change		Perpose				Developer 

ALTER PROCEDURE [dbo].[s_pr_get_student_by_group](@strm_id        VARCHAR(20),
                                                    @std_id         VARCHAR(20),
                                                    @btch_id        VARCHAR(20),
                                                    @package_id     VARCHAR(20),
                                                    @BranchID       VARCHAR(20),
                                                    @identifier     INT,
                                                    @USER_ID        VARCHAR(50) = 'SYSTEM',
                                                    @NUM_ERROR_CODE INT OUTPUT)
AS
     BEGIN
declare	 @gid varchar(20)
declare	 @id varchar(20)
         BEGIN TRY
		 set @gid=@package_id;
		-- if(@gid='0')
		
		-- if(@gid='1')
		-- begin
  --      set @id=(select stmt_gender='1' from STUDENT_MASTER where STMT_GENDER='F')		 

		--end;


             SET @NUM_ERROR_CODE = 1;
             IF(@identifier = 1)
                 BEGIN
                     SELECT *
                     FROM
                     (
                         SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                STUDENT_MASTER.STMT_CONTACT_NO,
								STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                STUDENT_MASTER.STMT_ADDRESS,
                                STREAM.STRM_NAME AS Package,
								STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                STREAM.STRM_ID
                         FROM STUDENT_MASTER
                              INNER JOIN student_Admission ON student_admission.STAM_ADMISSION_NO = student_master.STMT_ADMISSION_NO
                              INNER JOIN FEES_PACKAGES ON FEES_PACKAGES.FPKG_ID = STUDENT_ADMISSION.STAM_PACKAGE_ID
                              INNER JOIN [STANDARD] ON [STANDARD].STD_ID = STUDENT_ADMISSION.STAM_STD_ID
                              INNER JOIN [STREAM] ON STREAM.STRM_ID = [STANDARD].STD_STREAM_ID
                         WHERE STRM_ID = @strm_id
                               AND STRM_BRANCH_ID LIKE @BranchID
                              -- AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                         UNION
                         SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                STUDENT_MASTER.STMT_CONTACT_NO,
									STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                STUDENT_MASTER.STMT_ADDRESS,
                                FEE_STRUCTURE.FSTR_SUBJECT_NAME AS Package,
									STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                STREAM.STRM_ID
                         FROM STUDENT_MASTER
                              INNER JOIN STUDENT_ADMISSION ON STUDENT_ADMISSION.STAM_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                              INNER JOIN FEE_STRUCTURE ON FEE_STRUCTURE.FSTR_ID = STUDENT_ADMISSION.STAM_PACKAGE_ID
                              INNER JOIN [STANDARD] ON STANDARD.STD_ID = STUDENT_ADMISSION.STAM_STD_ID
                              INNER JOIN STREAM ON STREAM.STRM_ID = [STANDARD].STD_STREAM_ID
                         WHERE STRM_ID = @strm_id
                               AND STRM_BRANCH_ID LIKE @BranchID
                             --  AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                     ) AS QueryOutput;
                 END;
             ELSE
                 BEGIN
                     IF(@identifier = 2)
                         BEGIN
                             SELECT *
                             FROM
                             (
                                 SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                        STUDENT_MASTER.STMT_CONTACT_NO,
											STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                        STUDENT_MASTER.STMT_ADDRESS,
                                        [STANDARD].STD_NAME AS Package,
											STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                        [STANDARD].STD_ID
                                 FROM student_master
                                      INNER JOIN STUDENT_ADMISSION ON STUDENT_ADMISSION.STAM_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                                      INNER JOIN [STANDARD] ON [STANDARD].STD_ID = STUDENT_ADMISSION.STAM_STD_ID
                                      INNER JOIN FEES_PACKAGES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = FEES_PACKAGES.FPKG_ID
                                 WHERE [STANDARD].STD_ID = @std_id
                                       AND std_branch_id LIKE @BranchID
                                     -- AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                 UNION
                                 SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                        STUDENT_MASTER.STMT_CONTACT_NO,
											STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                        STUDENT_MASTER.STMT_ADDRESS,
                                        FEE_STRUCTURE.FSTR_SUBJECT_NAME AS Package,
											STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                        [STANDARD].STD_ID
                                 FROM student_master
                                      INNER JOIN STUDENT_ADMISSION ON STUDENT_ADMISSION.STAM_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                                      INNER JOIN [STANDARD] ON [STANDARD].STD_ID = STUDENT_ADMISSION.STAM_STD_ID
                                      INNER JOIN FEE_STRUCTURE ON STUDENT_ADMISSION.STAM_PACKAGE_ID = FEE_STRUCTURE.FSTR_ID
                                 WHERE [STANDARD].STD_ID = @std_id
                                       AND std_branch_id LIKE @BranchID
                                      -- AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                             ) AS QueryOutput;
                         END;
                     ELSE
                         BEGIN
                             IF(@identifier = 3)
                                 BEGIN
                                     SELECT *
                                     FROM
                                     (
                                         SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                                STUDENT_MASTER.STMT_CONTACT_NO,
                                                STUDENT_MASTER.STMT_ADDRESS,
													STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                                BATCH.BTCH_NAME AS Package,
													STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                                BATCH.BTCH_Id
                                         FROM STUDENT_MASTER
                                              INNER JOIN STUDENT_ADMISSION ON STUDENT_ADMISSION.STAM_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                                              INNER JOIN BATCH ON BATCH.BTCH_Id = STUDENT_ADMISSION.STAM_BATCH_ID
                                              INNER JOIN FEES_PACKAGES ON FEES_PACKAGES.FPKG_ID = STUDENT_ADMISSION.STAM_PACKAGE_ID
                                         WHERE BATCH.BTCH_Id = @btch_id
                                               AND BATCH.BTCH_BRANCH_ID LIKE @BranchID
                                              -- AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                         UNION
                                         SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                                STUDENT_MASTER.STMT_CONTACT_NO,
													STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                                STUDENT_MASTER.STMT_ADDRESS,
                                                FEE_STRUCTURE.FSTR_SUBJECT_NAME AS Package,
													STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                                BATCH.BTCH_Id
                                         FROM STUDENT_MASTER
                                              INNER JOIN STUDENT_ADMISSION ON STUDENT_ADMISSION.STAM_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                                              INNER JOIN BATCH ON BATCH.BTCH_Id = STUDENT_ADMISSION.STAM_BATCH_ID
                                              INNER JOIN FEE_STRUCTURE ON FEE_STRUCTURE.FSTR_ID = STUDENT_ADMISSION.STAM_PACKAGE_ID
                                         WHERE BATCH.BTCH_Id = @btch_id
                                               AND BATCH.BTCH_BRANCH_ID LIKE @BranchID
                                           --    AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                     ) AS QueryOutput;
                                 END;
                             ELSE
                                 BEGIN
                                     IF(@identifier = 4)
                                         BEGIN
                                             SELECT *
                                             FROM
                                             (
                                                 SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                                        STUDENT_MASTER.STMT_CONTACT_NO,
															STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                                        STUDENT_MASTER.STMT_ADDRESS,
                                                        FEES_PACKAGES.FPKG_PACKAGE_NAME AS Package,
															STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                                      STUDENT_FACILITIES.STFL_FROM_DATE as 'Start Date'
														,STUDENT_FACILITIES.STFL_TO_DATE as ' To Date'

														    
                                                 FROM STUDENT_MASTER
                                                      INNER JOIN student_Admission ON student_admission.STAM_ADMISSION_NO = student_master.STMT_ADMISSION_NO
                                                      INNER JOIN FEES_PACKAGES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = FEES_PACKAGES.FPKG_ID
													  inner join student_facilities on STUDENT_MASTER.STMT_ADMISSION_NO=STUDENT_FACILITIES.STFL_ADMISSION_NO
                                                 WHERE FEES_PACKAGES.FPKG_ID = @package_id
                                                       AND FEES_PACKAGES.FPKG_BRANCH_ID LIKE @BranchID
                                                      -- AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                                 UNION
                                                SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                                        STUDENT_MASTER.STMT_CONTACT_NO,
															STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                                        STUDENT_MASTER.STMT_ADDRESS,
                                                        FEES_PACKAGES.FPKG_PACKAGE_NAME AS Package,
															STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                                      STUDENT_FACILITIES.STFL_FROM_DATE as 'Start Date'
														,STUDENT_FACILITIES.STFL_TO_DATE as ' To Date'
														    
                                                 FROM STUDENT_MASTER
                                                      INNER JOIN student_Admission ON student_admission.STAM_ADMISSION_NO = student_master.STMT_ADMISSION_NO
                                                      INNER JOIN FEES_PACKAGES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = FEES_PACKAGES.FPKG_ID
													  inner join student_facilities on STUDENT_MASTER.STMT_ADMISSION_NO=STUDENT_FACILITIES.STFL_ADMISSION_NO
                                              WHERE FEES_PACKAGES.FPKG_ID = @package_id
                                                       AND FEES_PACKAGES.FPKG_BRANCH_ID LIKE @BranchID
                                                       --AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                             ) AS QueryOutput;
                                         END;
										  ELSE
                                 BEGIN
                                     IF(@identifier = 6)-----addded by ashvini on 08-02-2019 for displaying group by gender
                                         BEGIN
										 if(@gid='0')
										 begin
                                             SELECT *
                                             FROM
                                             (
                                                 SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                                        STUDENT_MASTER.STMT_CONTACT_NO,
															STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                                        STUDENT_MASTER.STMT_ADDRESS,
                                                        FEES_PACKAGES.FPKG_PACKAGE_NAME AS Package,
															STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                                        FEES_PACKAGES.FPKG_ID
                                                 FROM STUDENT_MASTER
                                                      INNER JOIN student_Admission ON student_admission.STAM_ADMISSION_NO = student_master.STMT_ADMISSION_NO
                                                      INNER JOIN FEES_PACKAGES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = FEES_PACKAGES.FPKG_ID
                                                 WHERE @gid= @package_id and STMT_GENDER='M' 
                                                       AND FEES_PACKAGES.FPKG_BRANCH_ID LIKE @BranchID
                                                       --AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                                 UNION
                                                 SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                                        STUDENT_MASTER.STMT_CONTACT_NO,
															STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                                        STUDENT_MASTER.STMT_ADDRESS,
                                                        FEE_STRUCTURE.FSTR_SUBJECT_NAME AS Package,
															STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                                        FEE_STRUCTURE.FSTR_ID
                                                 FROM STUDENT_MASTER
                                                      INNER JOIN student_Admission ON student_admission.STAM_ADMISSION_NO = student_master.STMT_ADMISSION_NO
                                                      INNER JOIN FEE_STRUCTURE ON FEE_STRUCTURE.FSTR_ID = STUDENT_ADMISSION.STAM_PACKAGE_ID
                                                 WHERE  @gid= @package_id and STMT_GENDER='M' 
                                                       AND FEE_STRUCTURE.FSTR_BRANCH_ID LIKE @BranchID
                                                       --AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                             ) AS QueryOutput;
                                         END;
									else if(@gid='1')
										 begin
                                             SELECT *
                                             FROM
                                             (
                                                 SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                                        STUDENT_MASTER.STMT_CONTACT_NO,
															STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                                        STUDENT_MASTER.STMT_ADDRESS,
                                                        FEES_PACKAGES.FPKG_PACKAGE_NAME AS Package,
															STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                                        FEES_PACKAGES.FPKG_ID
                                                 FROM STUDENT_MASTER
                                                      INNER JOIN student_Admission ON student_admission.STAM_ADMISSION_NO = student_master.STMT_ADMISSION_NO
                                                      INNER JOIN FEES_PACKAGES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = FEES_PACKAGES.FPKG_ID
                                                 WHERE @gid= @package_id and STMT_GENDER='F' 
                                                       AND FEES_PACKAGES.FPKG_BRANCH_ID LIKE @BranchID
                                                     --  AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                                 UNION
                                                 SELECT STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                                                        STUDENT_MASTER.STMT_CONTACT_NO,
															STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
                                                        STUDENT_MASTER.STMT_ADDRESS,
                                                        FEE_STRUCTURE.FSTR_SUBJECT_NAME AS Package,
															STUDENT_ADMISSION.STAM_IS_ACTIVE,
                                                        FEE_STRUCTURE.FSTR_ID
                                                 FROM STUDENT_MASTER
                                                      INNER JOIN student_Admission ON student_admission.STAM_ADMISSION_NO = student_master.STMT_ADMISSION_NO
                                                      INNER JOIN FEE_STRUCTURE ON FEE_STRUCTURE.FSTR_ID = STUDENT_ADMISSION.STAM_PACKAGE_ID
                                                 WHERE  @gid= @package_id and STMT_GENDER='F' 
                                                       AND FEE_STRUCTURE.FSTR_BRANCH_ID LIKE @BranchID
                                                     --  AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
                                             ) AS QueryOutput;
                                         END;
										 end;
                                 END;
                         END;
                    END;
                         END;
         END TRY
         BEGIN CATCH
             SET @NUM_ERROR_CODE = 0;
             EXEC SP_LogError;
         END CATCH;
     END;




