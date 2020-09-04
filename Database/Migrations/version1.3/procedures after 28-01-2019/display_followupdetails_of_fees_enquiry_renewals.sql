USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_followup_details]    Script Date: 19/01/28 12:58:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_disp_followup_details] (
@identifire int,
	@BranchID VARCHAR(20)
	,@FromDate Date
	,@ToDate Date
	,@USER_ID VARCHAR(50) = 'SYSTEM'
	
	,@NUM_ERROR_CODE INT OUTPUT
	)
AS
BEGIN TRY
	
	
	SET @NUM_ERROR_CODE = 1;
	if(@identifire=1)
	begin
		select STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME+' '+STUDENT_MASTER.STMT_MNAME as 'Name',
		[STANDARD].STD_NAME as 'Course',
		 STUDENT_MASTER.STMT_CONTACT_NO as 'Contact No',
		STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
		FOLLOW_UP.FOLU_FOLLOWUP_TYPE as 'Followup Type',
	    FOLLOW_UP.FOLU_DATE as 'Next Followup',
		CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) as 'Followup On' 
		from STUDENT_MASTER
		INNER JOIN FOLLOW_UP ON follow_up.folu_ref_no = student_master.stmt_admission_no
		inner join [STANDARD] on [STANDARD].STD_BRANCH_ID=FOLLOW_UP.FOLU_BRANCH_ID
		where  (CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) BETWEEN @fromDate AND @toDate) and FOLLOW_UP.FOLU_FOLLOWUP_TYPE='Enquiry' and FOLLOW_UP.FOLU_DESCRIPTION!='';

		end;
	else if(@identifire=3)
		begin 
		select STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME+' '+STUDENT_MASTER.STMT_MNAME as 'Name',
		[STANDARD].STD_NAME as 'Course',
		 STUDENT_MASTER.STMT_CONTACT_NO as 'Contact No',
		STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',
		FOLLOW_UP.FOLU_FOLLOWUP_TYPE as 'Followup Type',
	    FOLLOW_UP.FOLU_DATE as 'Next Followup',
		CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) as 'Followup On' 
		from STUDENT_MASTER
		INNER JOIN FOLLOW_UP ON follow_up.folu_ref_no = student_master.stmt_admission_no
		inner join [STANDARD] on [STANDARD].STD_BRANCH_ID=FOLLOW_UP.FOLU_BRANCH_ID
		where  (CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) BETWEEN @fromDate AND @toDate) and FOLLOW_UP.FOLU_FOLLOWUP_TYPE='Attendance' and FOLLOW_UP.FOLU_DESCRIPTION!='';

				END;
		else if (@identifire=0)
				begin 
					 SELECT
					 STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME+' '+STUDENT_MASTER.STMT_MNAME as 'Name',
					 	[STANDARD].STD_NAME as 'Course',
					
						  STUDENT_MASTER.STMT_CONTACT_NO as 'Contact No',
				    STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',		
				       FOLLOW_UP.FOLU_FOLLOWUP_TYPE as 'Followup Type',	  
					  FOLLOW_UP.FOLU_DATE AS 'Next Followup',        
			        	CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) as 'Followup On'			
             FROM FOLLOW_UP
                  INNER JOIN student_master ON follow_up.folu_ref_no = student_master.stmt_admission_no
				  	inner join [STANDARD] on [STANDARD].STD_BRANCH_ID=FOLLOW_UP.FOLU_BRANCH_ID
            where (CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) BETWEEN @fromDate AND @toDate) and FOLLOW_UP.FOLU_DESCRIPTION!='';
				 end;
				else if(@identifire=2)
				begin 
			 SELECT   STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME+' '+STUDENT_MASTER.STMT_MNAME as 'Name',
					 	[STANDARD].STD_NAME as 'Course',
						  STUDENT_MASTER.STMT_CONTACT_NO as 'Contact No',
				    STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',		
				       FOLLOW_UP.FOLU_FOLLOWUP_TYPE as 'Followup Type',	  
					  FOLLOW_UP.FOLU_DATE AS 'Next Followup',        
			        	CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) as 'Followup On'		
             FROM FOLLOW_UP
                  INNER JOIN student_master ON follow_up.folu_ref_no = student_master.stmt_admission_no
				  	inner join [STANDARD] on [STANDARD].STD_BRANCH_ID=FOLLOW_UP.FOLU_BRANCH_ID
                 where FOLLOW_UP.FOLU_FOLLOWUP_TYPE='Fees' and FOLLOW_UP.FOLU_DESCRIPTION!='' and (CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) BETWEEN @fromDate AND @toDate);
                
                end;
				else if (@identifire=4)
				begin
				select 
					 STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME+' '+STUDENT_MASTER.STMT_MNAME as 'Name',
					 	[STANDARD].STD_NAME as 'Course',
						  STUDENT_MASTER.STMT_CONTACT_NO as 'Contact No',
				    STUDENT_MASTER.STMT_FATHER_CONTACT as 'Father Contact',		
				       FOLLOW_UP.FOLU_FOLLOWUP_TYPE as 'Followup Type',	  
					  FOLLOW_UP.FOLU_DATE AS 'Next Followup',        
			        	CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) as 'Followup On'		
             FROM FOLLOW_UP
                  INNER JOIN student_master ON follow_up.folu_ref_no = student_master.stmt_admission_no
				  	inner join [STANDARD] on [STANDARD].STD_BRANCH_ID=FOLLOW_UP.FOLU_BRANCH_ID
                 where FOLLOW_UP.FOLU_FOLLOWUP_TYPE='Renewals' and FOLLOW_UP.FOLU_DESCRIPTION!='' and(CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT) BETWEEN @fromDate AND @toDate);
				 end;
				   END TRY
         BEGIN CATCH
             EXECUTE sp_logError;
             SET @NUM_ERROR_CODE = 0;
         END CATCH;
     