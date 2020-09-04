USE [DindoriGym]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_Active_Absent_Members]    Script Date: 06-Jan-20 00:10:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Name : s_pr_disp_Active_Absent_Members
--Developer : Hemlata
--Purpose : This Procedure is used to display the Members whose Package is Expired and Coming and ALso the Members which are Active and Absent For Many Days.
--Tables Used :  STUDENT_FACILITIES, STUDENT_MASTER,STUDENT_ADMISSION, ATTENDANCE (Select)
--SP Used : Sp_logerror
--Called From : 
--Change History 
----------------------------------------------------------------------
--Date		Change		Perpose				Developer


ALTER PROCEDURE [dbo].[s_pr_disp_Active_Absent_Members]       (@branchID       VARCHAR(20),
                                                @identifire     INT,
												@fromDate       date,
												@toDate         date,
                                                @NUM_ERROR_CODE INT OUTPUT)
AS
     BEGIN
	  BEGIN TRY
             SET @NUM_ERROR_CODE = 1;

		
                     --Indicates Members which are Active but Not Coming 
					  IF(@identifire = 0)
					--  set @fromDate=DATEADD(day,-15,@toDate)
					  
                 BEGIN
					 select ATTD_ADMISSION_NO AS AdmissionNo,
					 STMT_MEMSHIP_NO as Admission,
					  STMT_ADMISSION_DATE as Date,
					STMT_FNAME+' '+STMT_LNAME as Name,
					STMT_CONTACT_NO  as ContactNo,
					STFL_FACILITY_NAME as Package,
				     STFL_ID as ID,
					STFL_PACKAGE_ID as packageId,count(attd_status) as AbsentDays
					 from ATTENDANCE
					inner join STUDENT_FACILITIES on STFL_ADMISSION_NO = ATTD_ADMISSION_NO
					inner join STUDENT_MASTER on ATTD_ADMISSION_NO = STMT_ADMISSION_NO	
					inner join STUDENT_ADMISSION on STAM_ADMISSION_NO = STMT_ADMISSION_NO
					where stfl_sTATUS = 'A' or STFL_STATUS='R'
				and	ATTD_STATUS ='P'
					AND STFL_IS_AUTO_RENEW = 0
					AND STFL_BRANCH_ID like @branchID
					AND STAM_IS_ACTIVE = 1
				   AND STFL_TO_DATE between @fromDate and @toDate  --chnaged by ashwini  STFL_FROM_DATE to STFL_TO_DATE
			
				 group by ATTD_ADMISSION_NO, STMT_MEMSHIP_NO,
				  STMT_ADMISSION_DATE,
				  STMT_FNAME+' '+STMT_LNAME ,
				  STMT_CONTACT_NO,
				  STFL_FACILITY_NAME,
				   STFL_ID,STFL_PACKAGE_ID
				   Having count(attd_status)<10
				   order by STMT_ADMISSION_DATE desc;
				   END


				    --Indicates Members which are InActive and Coming
			   IF(@identifire = 1)
			   	  set @fromDate=DATEADD(day,-10,@toDate)
                 BEGIN
                    select ATTD_ADMISSION_NO AS AdmissionNo,
					STMT_FNAME+' '+STMT_LNAME as Name,
					STMT_CONTACT_NO  as ContactNo,
					STFL_FACILITY_NAME as Package,
					STFL_TO_DATE as RenewalDate,STFL_ID as ID,
					STFL_PACKAGE_ID as packageId,
					count(attd_status) as Count
					 from ATTENDANCE
					inner join STUDENT_FACILITIES on STFL_ADMISSION_NO = ATTD_ADMISSION_NO
					inner join STUDENT_MASTER on ATTD_ADMISSION_NO = STMT_ADMISSION_NO	
					inner join STUDENT_ADMISSION on STAM_ADMISSION_NO = STMT_ADMISSION_NO
					where
					ATTD_STATUS = 'P' and 
					STFL_TO_DATE< ATTD_DATE and 
					STFL_TO_DATE < CONVERT(DATE, GETDATE())
					AND STFL_STATUS = 'E'
					AND STFL_IS_AUTO_RENEW = 0
					AND STFL_BRANCH_ID like @branchID
					AND STAM_IS_ACTIVE = 0
					and STFL_TO_DATE between @fromDate and @toDate
			    	group by ATTD_ADMISSION_NO
					,STMT_FNAME+' '+STMT_LNAME,STMT_CONTACT_NO,
					STFL_FACILITY_NAME,STFL_TO_DATE,STFL_ID,STFL_PACKAGE_ID
					  Having count(attd_status)>2
					END;
         END TRY
         BEGIN CATCH
             SET @NUM_ERROR_CODE = 0;
             EXEC SP_LogError;
         END CATCH;
     END;
