alter table ACTIVITY_LOG
add ACT_LOGIN_USER varchar(100)


alter table ACTIVITY_LOG
ADD ACT_ADMISSIONNO INT;

alter table student_master 
add STMT_SOURCE varchar(50);

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



USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_student_facilities]    Script Date: 19/01/02 6:18:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_get_student_facilities] (
	@AdmissionNo INT
	,@USER_ID VARCHAR(50) = 'SYSTEM'
	,@NUM_ERROR_CODE INT OUTPUT
	)
AS

begin 
begin try

SET @NUM_ERROR_CODE = 1;




SELECT *,(select sum(INSD_INSTMNT_AMT - (INSD_AMOUNT_PAID + INSD_CNCLD_AMT + INSD_DISCOUNT))  from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Pending ,(select SUM(INSD_AMOUNT_PAID )from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Amount_Paid
FROM STUDENT_FACILITIES
INNER JOIN FEES ON STUDENT_FACILITIES.STFL_FEES_ID = FEES.FEE_ID
INNER JOIN BRANCH_MASTER ON STUDENT_FACILITIES.STFL_BRANCH_ID = BRANCH_MASTER.BRCH_ID
	AND FEES.FEE_BRANCH_ID = BRANCH_MASTER.BRCH_ID
INNER JOIN FEES_PACKAGES ON STUDENT_FACILITIES.STFL_PACKAGE_ID = FEES_PACKAGES.FPKG_ID
WHERE (STUDENT_FACILITIES.STFL_ADMISSION_NO = @AdmissionNo)
	AND (STUDENT_FACILITIES.STFL_IS_MAIN_PACKAGE = 1) and(STFL_STATUS != 'R')

SELECT *,(select sum(INSD_INSTMNT_AMT - (INSD_AMOUNT_PAID + INSD_CNCLD_AMT + INSD_DISCOUNT))  from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Pending ,(select SUM(INSD_AMOUNT_PAID )from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Amount_Paid

FROM STUDENT_FACILITIES
INNER JOIN FEES ON STUDENT_FACILITIES.STFL_FEES_ID = FEES.FEE_ID
INNER JOIN BRANCH_MASTER ON STUDENT_FACILITIES.STFL_BRANCH_ID = BRANCH_MASTER.BRCH_ID
	AND FEES.FEE_BRANCH_ID = BRANCH_MASTER.BRCH_ID
INNER JOIN FEE_STRUCTURE ON STUDENT_FACILITIES.STFL_PACKAGE_ID = FEE_STRUCTURE.FSTR_ID
WHERE (STUDENT_FACILITIES.STFL_ADMISSION_NO = @AdmissionNo) 
	AND (STUDENT_FACILITIES.STFL_IS_MAIN_PACKAGE = 0) and(STFL_STATUS != 'R')


end try
begin catch
exec SP_LogError;
set @NUM_ERROR_CODE=0;

end catch
end




USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_student_facilities]    Script Date: 19/01/07 6:35:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_get_student_facilities] (
	@AdmissionNo INT
	,@USER_ID VARCHAR(50) = 'SYSTEM'
	,@NUM_ERROR_CODE INT OUTPUT
	)
AS

begin 
begin try

SET @NUM_ERROR_CODE = 1;




SELECT *,(select sum(INSD_INSTMNT_AMT - (INSD_AMOUNT_PAID + INSD_CNCLD_AMT + INSD_DISCOUNT))  from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Pending ,(select SUM(INSD_AMOUNT_PAID )from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Amount_Paid,(select SUM(INSD_CNCLD_AMT)from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Canc_Amt
FROM STUDENT_FACILITIES
INNER JOIN FEES ON STUDENT_FACILITIES.STFL_FEES_ID = FEES.FEE_ID
INNER JOIN BRANCH_MASTER ON STUDENT_FACILITIES.STFL_BRANCH_ID = BRANCH_MASTER.BRCH_ID
	AND FEES.FEE_BRANCH_ID = BRANCH_MASTER.BRCH_ID
INNER JOIN FEES_PACKAGES ON STUDENT_FACILITIES.STFL_PACKAGE_ID = FEES_PACKAGES.FPKG_ID
WHERE (STUDENT_FACILITIES.STFL_ADMISSION_NO = @AdmissionNo)
	AND (STUDENT_FACILITIES.STFL_IS_MAIN_PACKAGE = 1) and(STFL_STATUS != 'R')

SELECT *,(select sum(INSD_INSTMNT_AMT - (INSD_AMOUNT_PAID + INSD_CNCLD_AMT + INSD_DISCOUNT))  from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Pending ,(select SUM(INSD_AMOUNT_PAID )from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Amount_Paid,(select SUM(INSD_CNCLD_AMT)from INSTALLMENTS_DETAILS where 
INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) as Canc_Amt

FROM STUDENT_FACILITIES
INNER JOIN FEES ON STUDENT_FACILITIES.STFL_FEES_ID = FEES.FEE_ID
INNER JOIN BRANCH_MASTER ON STUDENT_FACILITIES.STFL_BRANCH_ID = BRANCH_MASTER.BRCH_ID
	AND FEES.FEE_BRANCH_ID = BRANCH_MASTER.BRCH_ID
INNER JOIN FEE_STRUCTURE ON STUDENT_FACILITIES.STFL_PACKAGE_ID = FEE_STRUCTURE.FSTR_ID
WHERE (STUDENT_FACILITIES.STFL_ADMISSION_NO = @AdmissionNo) 
	AND (STUDENT_FACILITIES.STFL_IS_MAIN_PACKAGE = 0) and(STFL_STATUS != 'R')


end try
begin catch
exec SP_LogError;
set @NUM_ERROR_CODE=0;

end catch
end




ALTER TABLE dbo.STUDENT_FACILITIES ADD
	STFL_DISCOUNT_REASON varchar(400) NULL;


ALTER TABLE STUDENT_MASTER
 ADD STMT_HEATH_ISSUE VARCHAR(500)



alter table branch_master add NOTIFICATION_SENT_DATE varchar(50);




USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_transfer_amount]    Script Date: 19/01/03 6:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_disp_transfer_amount](
                                           @BranchID       VARCHAR(50),
                                           @USER_ID        VARCHAR(50) = 'SYSTEM',
                                           @NUM_ERROR_CODE INT OUTPUT)
AS
BEGIN
     BEGIN TRY
	
 SELECT PAID_EXPENSES.PDEX_DATE As 'Date',
                            PAID_EXPENSES.PDEX_AMOUNT AS 'Amount',
                            paid_expenses.PDEX_PAID_TO AS 'From Account',
                            GLB_ACCOUNTS.ACT_NAME As 'To Account',
							PDEX_TRANSACTION_ID ,PDEX_ACCNT_ID,
							[TRANSACTION].TRNC_REMARK
                     FROM EXPENSE_MASTER
                          INNER JOIN PAID_EXPENSES ON EXPENSE_MASTER.EXPM_ID = PAID_EXPENSES.PDEX_EXPNSE_ID
                          INNER JOIN GLB_ACCOUNTS ON PDEX_ACCNT_ID = GLB_ACCOUNTS.ACT_ID
                          INNER JOIN BRANCH_MASTER ON BRANCH_MASTER.BRCH_ID = PAID_EXPENSES.PDEX_BRANCH_ID
						  inner join [TRANSACTION] on TRNC_ID=PAID_EXPENSES.PDEX_ID
                     WHERE(PAID_EXPENSES.PDEX_BRANCH_ID LIKE @BranchID)
                          AND PDEX_DESC = 'TRANSFER'
                     ORDER BY PDEX_DATE DESC;
					  SET @NUM_ERROR_CODE = 1;
					  END TRY
         BEGIN CATCH
             EXECUTE sp_logError;
             SET @NUM_ERROR_CODE = 0; 
         END CATCH;
     END;







USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_transfer_amount]    Script Date: 19/01/03 6:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_disp_transfer_amount](
                                           @BranchID       VARCHAR(50),
                                           @USER_ID        VARCHAR(50) = 'SYSTEM',
                                           @NUM_ERROR_CODE INT OUTPUT)
AS
BEGIN
     BEGIN TRY
	
 SELECT PAID_EXPENSES.PDEX_DATE As 'Date',
                            PAID_EXPENSES.PDEX_AMOUNT AS 'Amount',
                            paid_expenses.PDEX_PAID_TO AS 'From Account',
                            GLB_ACCOUNTS.ACT_NAME As 'To Account',
							PDEX_TRANSACTION_ID ,PDEX_ACCNT_ID,
							[TRANSACTION].TRNC_REMARK
                     FROM EXPENSE_MASTER
                          INNER JOIN PAID_EXPENSES ON EXPENSE_MASTER.EXPM_ID = PAID_EXPENSES.PDEX_EXPNSE_ID
                          INNER JOIN GLB_ACCOUNTS ON PDEX_ACCNT_ID = GLB_ACCOUNTS.ACT_ID
                          INNER JOIN BRANCH_MASTER ON BRANCH_MASTER.BRCH_ID = PAID_EXPENSES.PDEX_BRANCH_ID
						  inner join [TRANSACTION] on TRNC_ID=PAID_EXPENSES.PDEX_ID
                     WHERE(PAID_EXPENSES.PDEX_BRANCH_ID LIKE @BranchID)
                          AND PDEX_DESC = 'TRANSFER'
                     ORDER BY PDEX_DATE DESC;
					  SET @NUM_ERROR_CODE = 1;
					  END TRY
         BEGIN CATCH
             EXECUTE sp_logError;
             SET @NUM_ERROR_CODE = 0; 
         END CATCH;
     END;




USE [Gymwise1.3]
GO
/****** Object:  Trigger [dbo].[TRG_student_measurement_AFTER_INSERT]    Script Date: 19/01/21 3:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TRG_STUD_MEASUREMENT_AFTR_INSRT] ON [dbo].[MEASUREMENTS]
AFTER INSERT
AS
BEGIN
	DECLARE @newid INT
	DECLARE @id INT
	DECLARE @branchid INT

	SET @id = (
			SELECT MM_ID
			FROM inserted
			);
	SET @branchid = (
			SELECT MM_BRANCHID
			FROM inserted
			);
	SET @newid = CONVERT(INT, CONVERT(NVARCHAR, @branchid) + CONVERT(NVARCHAR, @id));

	IF (@newid IS NOT NULL)
		UPDATE MEASUREMENTS
		SET MM_MID = @newid
		WHERE MM_ID = @id
			AND MM_BRANCHID= @branchid
END



create table FEES_AUD
(   AUD_Operation varchar(50)    ,
    AUD_Date date,
        FEE_ID int
      ,[FEE_ADMISSION_NO] int not null
      ,[FEE_ACADEMIC_YEAR] int not null
      ,[FEE_TOTAL_FEES]int
      ,[FEE_FEES_PAID]decimal(18,2)
      ,[FEE_DISCOUNT]decimal(18,2)
      ,[FEE_CANCD_FEES]decimal(18,2)
      ,[FEE_BOOKING_AMOUNT]decimal(18,2)
      ,[FEE_REG_AMOUNT]decimal(18,2)
      ,[FEE_MISC_AMOUNT]decimal(18,2)
      ,[FEE_BRANCH_ID]int
      ,[FEE_TUTION_AMOUNT]decimal(18,2)
      ,[FEE_FINE_AMOUNT]decimal(18,2)
      ,[FEE_PAYMENT_TYPE]varchar(1)
      ,[FEE_LAST_INSTALLMENT_MONTH]int
      ,[FEE_LAST_PAYMENT_DATE]date
      ,[FEE_LAST_INSTALLMENT_PAID_ID]int
      ,[FEE_DISCOUND_REASON]nvarchar(500)
      ,[FEE_LAST_PAYMENT_STATUS]varchar(100)
      ,[FEE_PAID_INSTALLMENT_ID]int
      ,[FEE_PAYMENT_START_DATE]date
      ,[FEE_CRTD_AT]datetime
      ,[FEE_UPDT_AT]datetime
      ,[FEE_DLTD_AT]datetime
      ,[FEE_CRTD_BY]varchar(50)
      ,[FEE_UPDAT_BY]varchar(50)
      ,[FEE_DLTD_BY]varchar(50)
      ,[ID]int
      ,[FEE_PNDG_CHEQUE_AMNT]decimal(18,2)
      ,[FEE_REASON]varchar(500)
	  )




        create table MEASUREMENTS
		( MM_MID int,
            MM_ADMISSION_NO int,          
            MM_WEIGHT decimal(18,2),
            MM_BMI decimal(18,2),
            MM_HEIGHT decimal(18,2),
            MM_FAT decimal(18,2),
            MM_NECK decimal(18,2),
            MM_SHOULDER decimal(18,2),
            MM_CHEST decimal(18,2),
            MM_ARMS decimal(18,2),
            MM_HIPS decimal(18,2),
            MM_THIGH decimal(18,2),
            MM_CALVES decimal(18,2),
            MM_FOREARMS decimal(18,2),
            MM_UPPER_ABD decimal(18,2),
            MM_LOWER_ABD decimal(18,2),
            MM_WAIST decimal(18,2),
			MM_ID int identity,
			MM_DATE datetime,
			MM_BRANCHID varchar(50)
			)

		
----procedure is changed to hide "TRANSFER" text when creating new expense



USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_expense_master]    Script Date: 19/01/11 4:01:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_get_expense_master] (
	@isExpense BIT
	,@BranchID varchar(50)
	,@USER_ID VARCHAR(50) = 'SYSTEM'
	,@NUM_ERROR_CODE INT OUTPUT
	)
AS
BEGIN
	BEGIN TRY
		SELECT *, BRANCH_MASTER.BRCH_NAME
		FROM EXPENSE_MASTER inner join BRANCH_MASTER on 
		EXPENSE_MASTER.EXPM_BRANCH_ID=BRANCH_MASTER.BRCH_ID 
		WHERE EXPM_BRANCH_ID like @BranchID
			AND EXPM_IS_EXPENSE = @isExpense and EXPENSE_MASTER.EXPM_DESCRIPTION!='FEES' and EXPENSE_MASTER.EXPM_DESCRIPTION!='TRANSFER'

		SET @NUM_ERROR_CODE = 1
	END TRY

	BEGIN CATCH
		EXEC SP_LogError

		SET @NUM_ERROR_CODE = - 1
	END CATCH
END




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




drop foreign key from facility_update table.FK_FACILITY_UPDATE_STUDENT_FACILITIES





USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_activities]    Script Date: 19/01/21 5:03:41 PM ******/
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






USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_measurements_of_Student]    Script Date: 19/01/21 3:56:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_get_measurements_of_Student]
                                             (
											 @Date     DATE,                                                                                                                
                                                 @AdmissionNo int,                                                                             
                                              @Weight         DECIMAL(18,2),
                                              @BMI                DECIMAL(18,2),
                                              @Height             DECIMAL(18,2),
											  @fat    DECIMAL(18,2),
											  @neck    DECIMAL(18,2),
											  @shoulder    DECIMAL(18,2),
											  @chest    DECIMAL(18,2),
											  @arms DECIMAL(18,2),
											  @hips DECIMAL(18,2),
											  @thigh DECIMAL(18,2),
											  @calves  DECIMAL(18,2),
											  @forearms  DECIMAL(18,2),
											  @upperabd DECIMAL(18,2),
											  @lowerabd DECIMAL(18,2),
											  @waist  DECIMAL(18,2),	
											  @BranchID varchar(50),									
                                              @USER_ID           VARCHAR(50)   = 'SYSTEM',
                                              @NUM_ERROR_CODE    INT OUTPUT)
AS
     BEGIN
         BEGIN TRY
             SET @NUM_ERROR_CODE = 1;
         
            
			   DECLARE @ID INT;

               
                
                   
                     INSERT INTO MEASUREMENTS
                     (
      
            MM_ADMISSIONNO,
            MM_WEIGHT,
            MM_BMI,
            MM_HEIGHT,
            MM_FAT,
            MM_NECK,
            MM_SHOULDER,
            MM_CHEST,
            MM_ARMS,
            MM_HIPS,
            MM_THIGH,
            MM_CALVES,
            MM_FOREARMS,
            MM_UPPER_ABD,
            MM_LOWER_ABD,
            MM_WAIST,
			  MM_DATE,
			MM_BRANCHID
	

                     )
                     VALUES
                     (
				        @AdmissionNo,        					   
					   @Weight,                                                                    
                      @BMI,                    
                      @Height,
                     @fat,
					@neck,
					  @shoulder,
					 @chest,
					  @arms, 
					 @hips,
					 @thigh,
					 @calves,
					 @forearms,
					 @upperabd,
					 @lowerabd,
					 @waist,
					 @Date,
					@BranchID
                     );
                   
               
                
			 EXECUTE sp_logError;
         END TRY
         BEGIN CATCH
			select ERROR_MESSAGE() as error
             EXEC SP_LogError;
             SET @NUM_ERROR_CODE = 0;
         END CATCH;
     END;

	    


USE [gym24-12]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_all_student]    Script Date: 18/12/27 5:11:04 PM ******/
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
          SELECT  
		  STUDENT_MASTER.STMT_ADMISSION_NO,
		 STUDENT_ADMISSION.STAM_ADMISSION_NO,
                    STUDENT_MASTER.STMT_MEMSHIP_NO,
                    STUDENT_ADMISSION.STAM_ROLL_NO,
          STUDENT_MASTER.STMT_FNAME+' '+ISNULL(STUDENT_MASTER.STMT_LNAME, '') AS Name,
                    STUDENT_MASTER.STMT_ADMISSION_DATE,
                    STANDARD.STD_NAME,
                   STREAM.STRM_NAME,
                    BATCH.BTCH_NAME,
                    STUDENT_MASTER.STMT_CONTACT_NO,
                    STUDENT_MASTER.STMT_ADDRESS,
                    STUDENT_MASTER.STMT_FATHER_CONTACT,
					STUDENT_MASTER.STMT_BRANCH_ID,
					STUDENT_MASTER.STMT_EMAIL_ID,
			
					STUDENT_FACILITIES.STFL_FROM_DATE as Start,
	                STUDENT_FACILITIES.STFL_TO_DATE As end_date,				
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
				  --INNER JOIN  STUDENT_FACILITIES ON 
				  inner  join STUDENT_FACILITIES on (STUDENT_FACILITIES.STFL_PACKAGE_ID=STUDENT_ADMISSION.STAM_PACKAGE_ID and STUDENT_FACILITIES.STFL_ADMISSION_NO=STUDENT_ADMISSION.STAM_ADMISSION_NO)
             WHERE STUDENT_MASTER.STMT_BRANCH_ID LIKE 101
			   AND STUDENT_ADMISSION.STAM_IS_ACTIVE=1           
                   AND STUDENT_MASTER.STMT_ADMISSION_DATE BETWEEN @from AND @to
			 	  

         END TRY
         BEGIN CATCH
             EXECUTE sp_logError;
             SET @NUM_ERROR_CODE = 0;
         END CATCH;
     END;






USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_outstng_fees]    Script Date: 19/01/17 6:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Name : s_pr_disp_outstng_fees
--Developer : Hemlata
--Purpose : This Procedure is used to display the Students whose Fees Outstanding.
--Tables Used : STUDENT_MASTER,STUDENT_ADMISSION, INSTALLMENTS_DETAILS,STANDARD,STREAM,STUDENT_FACILITIES,BATCH ,BRANCH_MASTER(Select)
--SP Used : Sp_logerror
--Called From : FeesHandler.getOutstandingFees() in FrmOutstandingFees.
--Change History 
--removed todays due by ashvini on 17-01-2019
--rename admission no as ID by ashvini 17-01-2019
----------------------------------------------------------------------
--Date		Change		Perpose				Developer


ALTER PROCEDURE [dbo].[s_pr_disp_outstng_fees] (
	@Branch_Id VARCHAR(10)
	,@Date DATE
	,@stream varchar(50)
	,@course varchar (50)
	,@batch varchar(50)
	,@studentwise bit = false
	,@USER_ID VARCHAR(50) = 'SYSTEM'
	,@NUM_ERROR_CODE INT OUTPUT
	)
AS
BEGIN
	BEGIN TRY
	declare @appname varchar(50);
set @appname = (Select PRM_VALUE from SYSTEM_PRM where PRM_NAME = 'APPLICATION_NAME')

if(@studentwise = 1)
begin

		SELECT STUDENT_MASTER.STMT_ADMISSION_NO AS [ID]
				,STUDENT_MASTER.STMT_FNAME + ' ' + STUDENT_MASTER.STMT_LNAME AS NAME
				,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT) - SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) - SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT)-sum(ISNULL(INSD_CNCLD_AMT,0)), 0) AS [Total Outstanding]
				,STUDENT_MASTER.STMT_CONTACT_NO AS [Contact No]
				,STUDENT_MASTER.STMT_FATHER_CONTACT as [Parent's No]
				,STUDENT_MASTER.STMT_EMAIL_ID AS [Email ID]
			FROM STUDENT
			INNER JOIN STUDENT_MASTER ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
			INNER JOIN FEES ON STUDENT.STUD_FEES_ID = FEES.FEE_ID
			INNER JOIN INSTALLMENTS_DETAILS ON INSTALLMENTS_DETAILS.INSD_FEES_ID = FEES.FEE_ID
			WHERE (STUDENT_MASTER.STMT_BRANCH_ID LIKE @Branch_Id)
			GROUP BY STUDENT_MASTER.STMT_ADMISSION_NO
				,STUDENT_MASTER.STMT_FNAME + ' ' + STUDENT_MASTER.STMT_LNAME
				,STUDENT_MASTER.STMT_FATHER_CONTACT
				,STUDENT_MASTER.STMT_CONTACT_NO
				,STUDENT_MASTER.STMT_EMAIL_ID
			order by [Total Outstanding] desc
end;

else
begin

if @appname like ''
begin
		SELECT [ID]
			--,[Roll No]
			,Name
			,SUM([Fees Paid]) AS [Fees Paid]
			
			,SUM([Total Outstanding]) AS [Total Outstanding]
			,SUM([Total Fees]) AS [Total Fees]
			,SUM(Discount) AS Discount
			,sum([Cancelled Amount]) as CancelledAmount
			,STRM_NAME
			,STD_NAME 
			,[Package Name]
			,[Contact No]
			,[Parent No]
			,[Email ID]
			,Batch
			,Branch
			,STD_ID
			,STD_STREAM_ID
		FROM (
			SELECT STUDENT_MASTER.STMT_ADMISSION_NO AS [ID]
				--,STUDENT_ADMISSION.STAM_ROLL_NO AS [Roll No]
				,STUDENT_MASTER.STMT_FNAME + ' ' + STUDENT_MASTER.STMT_LNAME AS NAME
				,0 AS [Fees Paid]
				--,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT) - SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) - SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT)-sum(ISNULL(INSD_CNCLD_AMT,0)), 0) AS [Today Due]
				,0 AS [Total Outstanding]
				,0 AS [Total Fees]
				,0 AS Discount
				,0 as "Cancelled Amount"
				,STANDARD.STD_NAME 
				,STREAM.STRM_NAME 
				,STUDENT_FACILITIES.STFL_FACILITY_NAME AS [Package Name]
				,STUDENT_MASTER.STMT_CONTACT_NO as[Contact No]
				,STUDENT_MASTER.STMT_FATHER_CONTACT AS [Parent No]
				,STUDENT_MASTER.STMT_EMAIL_ID AS [Email ID]
				,BATCH.BTCH_NAME AS Batch
				,BRANCH_MASTER.BRCH_NAME AS Branch
				,STANDARD.STD_ID
				,STANDARD.STD_STREAM_ID
			FROM STUDENT
			INNER JOIN STUDENT_MASTER ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
			INNER JOIN BRANCH_MASTER ON STUDENT_MASTER.STMT_BRANCH_ID = BRANCH_MASTER.BRCH_ID
			INNER JOIN FEES ON STUDENT.STUD_FEES_ID = FEES.FEE_ID
			INNER JOIN STUDENT_ADMISSION ON STUDENT.STUD_ADMISSION_NO = STUDENT_ADMISSION.STAM_ADMISSION_NO
			INNER JOIN BATCH ON BATCH.BTCH_Id = STUDENT_ADMISSION.STAM_BATCH_ID
			INNER JOIN STANDARD ON STANDARD.STD_ID = STUDENT_ADMISSION.STAM_STD_ID
			INNER JOIN STREAM ON Standard.STD_STREAM_ID = STREAM.STRM_ID
			INNER JOIN STUDENT_FACILITIES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = STUDENT_FACILITIES.STFL_PACKAGE_ID
				AND STUDENT_FACILITIES.STFL_ADMISSION_NO = STUDENT.STUD_ADMISSION_NO
			INNER JOIN INSTALLMENTS_DETAILS ON INSTALLMENTS_DETAILS.INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID
			WHERE (STUDENT_MASTER.STMT_BRANCH_ID LIKE @Branch_Id)
			AND STREAM.STRM_ID like @stream 
			and STANDARD.STD_ID like @course
			and BATCH.BTCH_Id like @batch
		    AND INSTALLMENTS_DETAILS.INSD_DATE <= @Date
		  
			GROUP BY STUDENT_MASTER.STMT_ADMISSION_NO
				,BRANCH_MASTER.BRCH_NAME
				--,STUDENT_ADMISSION.STAM_ROLL_NO
				,STUDENT_MASTER.STMT_FNAME
				,STUDENT_MASTER.STMT_MNAME
				,STUDENT_MASTER.STMT_LNAME
				,STANDARD.STD_NAME
				,STREAM.STRM_NAME
				,STUDENT_MASTER.STMT_CONTACT_NO
				,STUDENT_MASTER.STMT_FATHER_CONTACT
				,STUDENT_MASTER.STMT_EMAIL_ID
				,BATCH.BTCH_NAME
				,STANDARD.STD_ID
				,STANDARD.STD_STREAM_ID
				,STUDENT_FACILITIES.STFL_FACILITY_NAME
			
			UNION
			
			SELECT STUDENT_MASTER.STMT_ADMISSION_NO AS [ID]
				--,STUDENT_ADMISSION.STAM_ROLL_NO
				,STUDENT_MASTER.STMT_FNAME + ' ' + STUDENT_MASTER.STMT_LNAME AS NAME
				,SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) AS [Fees Paid]
			--	,0 AS [Today Due]
				,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT) - SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) - SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT)-sum(ISNULL(INSD_CNCLD_AMT,0)), 0) AS [Total Outstanding]
				,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT), 0) AS [Total Fees]
				,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT), 0) AS Discount
				,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_CNCLD_AMT),0) as "Cancelled Amount"
				,STANDARD.STD_NAME 
				,STREAM.STRM_NAME 
				,STUDENT_FACILITIES.STFL_FACILITY_NAME AS [Package Name]
				,STUDENT_MASTER.STMT_CONTACT_NO AS [Contact No]
				,STUDENT_MASTER.STMT_FATHER_CONTACT as[Parent No] 
				
				,STUDENT_MASTER.STMT_EMAIL_ID AS [Email ID]
				,BATCH.BTCH_NAME AS Batch
				,BRANCH_MASTER.BRCH_NAME AS Branch
				,STANDARD.STD_ID
				,STANDARD.STD_STREAM_ID
			FROM STUDENT
			INNER JOIN STUDENT_MASTER ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
			INNER JOIN BRANCH_MASTER ON STUDENT_MASTER.STMT_BRANCH_ID = BRANCH_MASTER.BRCH_ID
			INNER JOIN FEES ON STUDENT.STUD_FEES_ID = FEES.FEE_ID
			INNER JOIN STUDENT_ADMISSION ON STUDENT.STUD_ADMISSION_NO = STUDENT_ADMISSION.STAM_ADMISSION_NO
			INNER JOIN BATCH ON BATCH.BTCH_Id = STUDENT_ADMISSION.STAM_BATCH_ID
			INNER JOIN STANDARD ON STANDARD.STD_ID = STUDENT_ADMISSION.STAM_STD_ID
			INNER JOIN STREAM ON Standard.STD_STREAM_ID = STREAM.STRM_ID
			INNER JOIN STUDENT_FACILITIES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = STUDENT_FACILITIES.STFL_PACKAGE_ID
				AND STUDENT_FACILITIES.STFL_ADMISSION_NO = STUDENT.STUD_ADMISSION_NO
			INNER JOIN INSTALLMENTS_DETAILS ON INSTALLMENTS_DETAILS.INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID
			WHERE (STUDENT_MASTER.STMT_BRANCH_ID LIKE @Branch_Id)
			AND STREAM.STRM_ID like @stream 
			and STANDARD.STD_ID like @course 
			and BATCH.BTCH_Id like @batch
			
			GROUP BY STUDENT_MASTER.STMT_ADMISSION_NO
				,BRANCH_MASTER.BRCH_NAME
				--,STUDENT_ADMISSION.STAM_ROLL_NO
				,STUDENT_MASTER.STMT_FNAME
				,STUDENT_MASTER.STMT_MNAME
				,STUDENT_MASTER.STMT_LNAME
				,STANDARD.STD_NAME
				,STREAM.STRM_NAME
				,STUDENT_MASTER.STMT_CONTACT_NO 
				,STUDENT_MASTER.STMT_FATHER_CONTACT
				,STUDENT_MASTER.STMT_EMAIL_ID
				,BATCH.BTCH_NAME
				,STANDARD.STD_ID
				,STANDARD.STD_STREAM_ID
				,STUDENT_FACILITIES.STFL_FACILITY_NAME
			) AS OUTSTANDING_RESULT
			--where [Total Outstanding] <> 0.00
		GROUP BY [ID]
			--,[Roll No]
			,Name
			,STD_NAME 
			,[Package Name]
			,[Contact No]
			,[Parent No]
			,[Email ID]
			,Batch
			,Branch
			,STD_ID
			,STD_STREAM_ID
			,STRM_NAME
end
else
SELECT [ID]
			--,[Roll No]
			,Name
			,SUM([Fees Paid]) AS [Fees Paid]
			--,SUM([Today Due]) AS [Today Due]
			,SUM([Total Outstanding]) AS [Total Outstanding]
			,SUM([Total Fees]) AS [Total Fees]
			,SUM(Discount) AS Discount
			,sum([Cancelled Amount]) as CancelledAmount
			,STRM_NAME
			,STD_NAME 
			,[Package Name]
			,[Contact No]
			,[Email ID]
			,Batch
			,Branch
			,STD_ID
			,STD_STREAM_ID
		FROM (
			SELECT STUDENT_MASTER.STMT_ADMISSION_NO AS [ID]
				--,STUDENT_ADMISSION.STAM_ROLL_NO AS [Roll No]
				,STUDENT_MASTER.STMT_FNAME + ' ' + STUDENT_MASTER.STMT_LNAME AS NAME
				,0 AS [Fees Paid]
			--	,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT) - SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) - SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT)-sum(ISNULL(INSD_CNCLD_AMT,0)), 0) AS [Today Due]
				,0 AS [Total Outstanding]
				,0 AS [Total Fees]
				,0 AS Discount
				,0 as "Cancelled Amount"
				,STANDARD.STD_NAME 
				,STREAM.STRM_NAME 
				,STUDENT_FACILITIES.STFL_FACILITY_NAME AS [Package Name],
		
				STUDENT_MASTER.STMT_CONTACT_NO AS [Contact No]
				,STUDENT_MASTER.STMT_FATHER_CONTACT as[Parent No]
				,STUDENT_MASTER.STMT_EMAIL_ID AS [Email ID]
				,BATCH.BTCH_NAME AS Batch
				,BRANCH_MASTER.BRCH_NAME AS Branch
				,STANDARD.STD_ID
				,STANDARD.STD_STREAM_ID
			FROM STUDENT
			INNER JOIN STUDENT_MASTER ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
			INNER JOIN BRANCH_MASTER ON STUDENT_MASTER.STMT_BRANCH_ID = BRANCH_MASTER.BRCH_ID
			INNER JOIN FEES ON STUDENT.STUD_FEES_ID = FEES.FEE_ID
			INNER JOIN STUDENT_ADMISSION ON STUDENT.STUD_ADMISSION_NO = STUDENT_ADMISSION.STAM_ADMISSION_NO
			INNER JOIN BATCH ON BATCH.BTCH_Id = STUDENT_ADMISSION.STAM_BATCH_ID
			INNER JOIN STANDARD ON STANDARD.STD_ID = STUDENT_ADMISSION.STAM_STD_ID
			INNER JOIN STREAM ON Standard.STD_STREAM_ID = STREAM.STRM_ID
			INNER JOIN STUDENT_FACILITIES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = STUDENT_FACILITIES.STFL_PACKAGE_ID
				AND STUDENT_FACILITIES.STFL_ADMISSION_NO = STUDENT.STUD_ADMISSION_NO
			INNER JOIN INSTALLMENTS_DETAILS ON INSTALLMENTS_DETAILS.INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID
			WHERE (STUDENT_MASTER.STMT_BRANCH_ID LIKE @Branch_Id)
			AND STREAM.STRM_ID like @stream 
			and STANDARD.STD_ID like @course
			and BATCH.BTCH_Id like @batch
		    AND INSTALLMENTS_DETAILS.INSD_DATE <= @Date
		  
			GROUP BY STUDENT_MASTER.STMT_ADMISSION_NO
				,BRANCH_MASTER.BRCH_NAME
				--,STUDENT_ADMISSION.STAM_ROLL_NO
				,STUDENT_MASTER.STMT_FNAME
				,STUDENT_MASTER.STMT_MNAME
				,STUDENT_MASTER.STMT_LNAME
				,STANDARD.STD_NAME
				,STREAM.STRM_NAME
				,STUDENT_MASTER.STMT_CONTACT_NO
				,STUDENT_MASTER.STMT_FATHER_CONTACT
				,STUDENT_MASTER.STMT_EMAIL_ID
				,BATCH.BTCH_NAME
				,STANDARD.STD_ID
				,STANDARD.STD_STREAM_ID
				,STUDENT_FACILITIES.STFL_FACILITY_NAME
			
			UNION
			
			SELECT STUDENT_MASTER.STMT_ADMISSION_NO AS [ID]
				--,STUDENT_ADMISSION.STAM_ROLL_NO
				,STUDENT_MASTER.STMT_FNAME + ' ' + STUDENT_MASTER.STMT_LNAME AS NAME
				,SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) AS [Fees Paid]
				,0 AS [Today Due]
				--,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT) - SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) - SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT)-sum(ISNULL(INSD_CNCLD_AMT,0)), 0) AS [Total Outstanding]
				,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT), 0) AS [Total Fees]
				,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT), 0) AS Discount
				,ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_CNCLD_AMT),0) as "Cancelled Amount"
				,STANDARD.STD_NAME 
				,STREAM.STRM_NAME 
				,STUDENT_FACILITIES.STFL_FACILITY_NAME AS [Package Name]

				,STUDENT_MASTER.STMT_CONTACT_NO AS [Contact No]
				,STUDENT_MASTER.STMT_FATHER_CONTACT as[Parent No]
				,STUDENT_MASTER.STMT_EMAIL_ID AS [Email ID]
				,BATCH.BTCH_NAME AS Batch
				,BRANCH_MASTER.BRCH_NAME AS Branch
				,STANDARD.STD_ID
				,STANDARD.STD_STREAM_ID
			FROM STUDENT
			INNER JOIN STUDENT_MASTER ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
			INNER JOIN BRANCH_MASTER ON STUDENT_MASTER.STMT_BRANCH_ID = BRANCH_MASTER.BRCH_ID
			INNER JOIN FEES ON STUDENT.STUD_FEES_ID = FEES.FEE_ID
			INNER JOIN STUDENT_ADMISSION ON STUDENT.STUD_ADMISSION_NO = STUDENT_ADMISSION.STAM_ADMISSION_NO
			INNER JOIN BATCH ON BATCH.BTCH_Id = STUDENT_ADMISSION.STAM_BATCH_ID
			INNER JOIN STANDARD ON STANDARD.STD_ID = STUDENT_ADMISSION.STAM_STD_ID
			INNER JOIN STREAM ON Standard.STD_STREAM_ID = STREAM.STRM_ID
			INNER JOIN STUDENT_FACILITIES ON STUDENT_ADMISSION.STAM_PACKAGE_ID = STUDENT_FACILITIES.STFL_PACKAGE_ID
				AND STUDENT_FACILITIES.STFL_ADMISSION_NO = STUDENT.STUD_ADMISSION_NO
			INNER JOIN INSTALLMENTS_DETAILS ON INSTALLMENTS_DETAILS.INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID
			WHERE (STUDENT_MASTER.STMT_BRANCH_ID LIKE @Branch_Id)
			AND STREAM.STRM_ID like @stream 
			and STANDARD.STD_ID like @course 
			and BATCH.BTCH_Id like @batch
			
			GROUP BY STUDENT_MASTER.STMT_ADMISSION_NO
				,BRANCH_MASTER.BRCH_NAME
				--,STUDENT_ADMISSION.STAM_ROLL_NO
				,STUDENT_MASTER.STMT_FNAME
				,STUDENT_MASTER.STMT_MNAME
				,STUDENT_MASTER.STMT_LNAME
				,STANDARD.STD_NAME
				,STREAM.STRM_NAME
				,STUDENT_MASTER.STMT_FATHER_CONTACT
				,STUDENT_MASTER.STMT_CONTACT_NO
				,STUDENT_MASTER.STMT_EMAIL_ID
				,BATCH.BTCH_NAME
				,STANDARD.STD_ID
				,STANDARD.STD_STREAM_ID
				,STUDENT_FACILITIES.STFL_FACILITY_NAME
			) AS OUTSTANDING_RESULT
			where [Total Outstanding] <> 0.00
		GROUP BY [ID]
			--,[Roll No]
			,Name
			,STD_NAME 
			,[Package Name]
			,[Contact No]
			,[Email ID]
			,Batch
			,Branch
			,STD_ID
			,STD_STREAM_ID
			,STRM_NAME
end
		SET @NUM_ERROR_CODE = 1;
	END TRY

	BEGIN CATCH
		EXECUTE sp_logError

		SET @NUM_ERROR_CODE = - 1
	END CATCH
END







update FUNCTION_MASTER set FM_FORM_ASSEMBLY='ClassesManager.WinApp' WHERE FM_NAME='&Outstanding Payment'


update FUNCTION_MASTER set FM_FORM_ASSEMBLY='ClassesManager.WinApp' WHERE FM_NAME='&Members Report'




