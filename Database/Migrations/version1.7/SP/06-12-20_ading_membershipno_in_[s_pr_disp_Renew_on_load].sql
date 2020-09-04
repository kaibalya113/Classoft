USE [DindoriGym]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_Renew_on_load]    Script Date: 05-Jan-20 23:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Name : s_pr_disp_Renew_on_load
--Developer : Hemlata
--Purpose : This Procedure is used to display the Students Whose Packages are going Tobe Expied, Expired, and those with no Packages on Load of the MainForm.
--Tables Used :  STUDENT_FACILITIES, STUDENT_MASTER,STUDENT_ADMISSION,STUDENT, INSTALLMENTS_DETAILS (Select)
--SP Used : Sp_logerror
--Called From : FeesHandler.getRenewalOnLoad() in FrmExpiredRenewal.
--Change History 
----------------------------------------------------------------------
--Date		Change		Perpose				Developer


ALTER PROCEDURE [dbo].[s_pr_disp_Renew_on_load](@branchID       VARCHAR(20),
                                                @identifire     INT,
												@fromDate       date,
												@toDate         date,
                                                @NUM_ERROR_CODE INT OUTPUT)
AS
     BEGIN
         DECLARE @Days INT;
		 Declare @expiryFrequency int;
		  
         BEGIN TRY
             SET @NUM_ERROR_CODE = 1;
             SET @Days =
             (
                 SELECT PRM_VALUE
                 FROM SYSTEM_PRM
                 WHERE PRM_NAME = 'ADD_FOLLWP_DATE'
             );

			 SET @expiryFrequency =
             (
                 SELECT PRM_VALUE
                 FROM SYSTEM_PRM
                 WHERE PRM_NAME = 'FREQUENCY_TO_SEND_MSG'
             );

			 if(@expiryFrequency is null)
			 begin
				set @expiryFrequency = 3;
			 end


			 --Indicates Expiring to whome ssms is to be sent.
             IF(@identifire = 5)
                 BEGIN
					 SELECT DISTINCT
						STUDENT_FACILITIES.STFL_ADMISSION_NO AS AdmissionNo,
						STMT_FNAME+' '+STMT_LNAME AS Name,
						STMT_CONTACT_NO ContactNo,
						STUDENT_FACILITIES.STFL_FACILITY_NAME AS Package,
						STUDENT_FACILITIES.STFL_FROM_DATE as Start,
						STFL_TO_DATE AS ExpiredOn,
						STUDENT_FACILITIES.STFL_ID AS Id,
						STFL_PACKAGE_ID AS packageId
						FROM STUDENT_MASTER
							INNER JOIN STUDENT_FACILITIES ON STUDENT_MASTER.STMT_ADMISSION_NO = STFL_ADMISSION_NO
							INNER JOIN STUDENT_ADMISSION ON STFL_ADMISSION_NO = STAM_ADMISSION_NO
							INNER JOIN STUDENT ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
						WHERE
							STFL_STATUS = 'A' 
							and STFL_TO_DATE >= convert(date,@fromDate)
							and STFL_TO_DATE <= convert(date,@toDate)
							AND STFL_BRANCH_ID like @branchID
							and (STFL_EXPIRY_SMS_DATE is null  or DATEADD(day,@expiryFrequency,STFL_EXPIRY_SMS_DATE) = GETDATE() or  STFL_EXPIRY_SMS_DATE < DATEADD(day,-1 * @expiryFrequency,getdate()))
						 GROUP BY
									STUDENT_FACILITIES.STFL_ADMISSION_NO,
									STMT_FNAME,
									STMT_LNAME,
									STMT_CONTACT_NO,
									STFL_FACILITY_NAME,
									STFL_FROM_DATE,
									STFL_To_DATE,
									STUDENT_FACILITIES.STFL_ID,
									STFL_PACKAGE_ID;
					   end;


             --Indicates Expired.
             else IF(@identifire = 0)
                 BEGIN
					  SELECT distinct
						STUDENT_FACILITIES.STFL_ADMISSION_NO AS AdmissionNo,
						STMT_FNAME+' '+STMT_LNAME AS Name,
						STMT_CONTACT_NO ContactNo,
						STUDENT_FACILITIES.STFL_FACILITY_NAME AS Package,
						STUDENT_FACILITIES.STFL_FROM_DATE as Start,
						STFL_TO_DATE AS ExpiredOn,
						STUDENT_FACILITIES.STFL_ID AS Id,
						(select ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT) - SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) - SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT) - SUM(ISNULL(INSTALLMENTS_DETAILS.INSD_CNCLD_AMT, 0)), 0) from INSTALLMENTS_DETAILS where INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) AS [Outstanding Fees],
						STFL_PACKAGE_ID AS packageId
						FROM STUDENT_MASTER
							INNER JOIN STUDENT_FACILITIES ON STUDENT_MASTER.STMT_ADMISSION_NO = STFL_ADMISSION_NO 
							INNER JOIN STUDENT_ADMISSION ON STFL_ADMISSION_NO = STAM_ADMISSION_NO and STUDENT_ADMISSION.STAM_PACKAGE_ID = STUDENT_FACILITIES.STFL_PACKAGE_ID
							INNER JOIN STUDENT ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
							inner join (
								select sf.STFL_ADMISSION_NO,sf.STFL_ID from(
									select STFL_ADMISSION_NO,max(STFL_ID) as latest_facility 
									from STUDENT_FACILITIES sfo
									where sfo.STFL_STATUS = 'E' 
									and sfo.sTFL_TO_DATE between @fromDate and @toDate
									group by sfo.STFL_ADMISSION_NO
									union
									select stflp.STFL_ADMISSION_NO,stflp.STFL_ID as latest_facility 
									from STUDENT_FACILITIES stflp inner join INSTALLMENTS_DETAILS insdp on stflp.STFL_ID = insdp.INSD_FACILITY_ID
									where stflp.STFL_STATUS = 'E' 
									and stflp.sTFL_TO_DATE between @fromDate and @toDate
									group by  stflp.STFL_ADMISSION_NO,stflp.STFL_ID
									having ISNULL(SUM(insdp.INSD_INSTMNT_AMT) - SUM(insdp.INSD_AMOUNT_PAID) - SUM(insdp.INSD_DISCOUNT) - SUM(ISNULL(insdp.INSD_CNCLD_AMT, 0)), 0) > 0
									) dates inner join STUDENT_FACILITIES sf on
							 sf.STFL_ADMISSION_NO = dates.STFL_ADMISSION_NO
							and sf.STFL_ID =  dates.latest_facility
							group by sf.STFL_ADMISSION_NO,sf.STFL_ID) latest_expired on (latest_expired.STFL_ID = STUDENT_FACILITIES.STFL_ID or STUDENT_FACILITIES.stfl_remind_renewal = 1)
						WHERE
							STFL_STATUS = 'E' 
							and STFL_TO_DATE between @fromDate and @toDate
							AND STFL_BRANCH_ID like @branchID
						 GROUP BY  
									STUDENT_FACILITIES.STFL_ADMISSION_NO,
									STMT_FNAME,
									STMT_LNAME,
									STMT_CONTACT_NO,
									STFL_FACILITY_NAME,
									STFL_FROM_DATE,
									STFL_To_DATE,
									STUDENT_FACILITIES.STFL_ID,
									STFL_PACKAGE_ID;
					   end;

			 else IF(@identifire = 1)
				   BEGIN
                     --               
                     SELECT distinct
						STUDENT_FACILITIES.STFL_ADMISSION_NO AS AdmissionNo,
						STMT_MEMSHIP_NO as AdmissionNo,
						STMT_FNAME+' '+STMT_LNAME AS Name,
						STMT_CONTACT_NO ContactNo,
						STUDENT_FACILITIES.STFL_FACILITY_NAME AS Package,
						STUDENT_FACILITIES.STFL_FROM_DATE as Start,
						STFL_TO_DATE AS ExpiredOn,
						STUDENT_FACILITIES.STFL_ID AS Id,
						(select ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT) - SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) - SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT) - SUM(ISNULL(INSTALLMENTS_DETAILS.INSD_CNCLD_AMT, 0)), 0) from INSTALLMENTS_DETAILS where INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID) AS [Outstanding Fees],
						STFL_PACKAGE_ID AS packageId
						FROM STUDENT_MASTER
							INNER JOIN STUDENT_FACILITIES ON STUDENT_MASTER.STMT_ADMISSION_NO = STFL_ADMISSION_NO 
							INNER JOIN STUDENT_ADMISSION ON STFL_ADMISSION_NO = STAM_ADMISSION_NO and STUDENT_ADMISSION.STAM_PACKAGE_ID = STUDENT_FACILITIES.STFL_PACKAGE_ID
							INNER JOIN STUDENT ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
							inner join (
								select sf.STFL_ADMISSION_NO,sf.STFL_ID from(
									select STFL_ADMISSION_NO,max(STFL_ID) as latest_facility 
									from STUDENT_FACILITIES sfo
									where sfo.STFL_STATUS = 'E' 
									and sfo.sTFL_TO_DATE between @fromDate and @toDate
									group by sfo.STFL_ADMISSION_NO
									union
									select stflp.STFL_ADMISSION_NO,stflp.STFL_ID as latest_facility 
									from STUDENT_FACILITIES stflp inner join INSTALLMENTS_DETAILS insdp on stflp.STFL_ID = insdp.INSD_FACILITY_ID
									where stflp.STFL_STATUS = 'E' 
									and stflp.sTFL_TO_DATE between @fromDate and @toDate
									group by  stflp.STFL_ADMISSION_NO,stflp.STFL_ID
									having ISNULL(SUM(insdp.INSD_INSTMNT_AMT) - SUM(insdp.INSD_AMOUNT_PAID) - SUM(insdp.INSD_DISCOUNT) - SUM(ISNULL(insdp.INSD_CNCLD_AMT, 0)), 0) > 0
									) dates inner join STUDENT_FACILITIES sf on
							 sf.STFL_ADMISSION_NO = dates.STFL_ADMISSION_NO
							and sf.STFL_ID =  dates.latest_facility
							group by sf.STFL_ADMISSION_NO,sf.STFL_ID) latest_expired on (latest_expired.STFL_ID = STUDENT_FACILITIES.STFL_ID or STUDENT_FACILITIES.stfl_remind_renewal = 1)
                     WHERE(STFL_TO_DATE < CONVERT(DATE, GETDATE())
                           AND STFL_STATUS = 'E')
                           AND STFL_BRANCH_ID like @branchID
  						  and STFL_TO_DATE between @fromDate and @toDate
                     GROUP BY 
                              STUDENT_FACILITIES.STFL_ADMISSION_NO,
                              STMT_FNAME,
                              STMT_LNAME,
							  STMT_MEMSHIP_NO,
                              STMT_CONTACT_NO,
                              STFL_FACILITY_NAME,
							  STFL_FROM_DATE,
                              STFL_To_DATE,
                              STUDENT_FACILITIES.STFL_ID,
                              STFL_PACKAGE_ID;
                 END;

             --Indicates ToBeExpired.
             else IF(@identifire = 2)
                 BEGIN
                     --            
                     SELECT DISTINCT
                            STUDENT_FACILITIES.STFL_ADMISSION_NO AS AdmissionNo,
                            STMT_FNAME+'  '+STMT_LNAME AS Name,
                            STMT_CONTACT_NO as ContactNo,
                            STUDENT_FACILITIES.STFL_FACILITY_NAME AS Package,
							STUDENT_FACILITIES.STFL_FROM_DATE as Start,
                            STFL_TO_DATE AS RenewalDate,
                            STFL_ID AS Id,
                            ISNULL(SUM(INSTALLMENTS_DETAILS.INSD_INSTMNT_AMT) - SUM(INSTALLMENTS_DETAILS.INSD_AMOUNT_PAID) - SUM(INSTALLMENTS_DETAILS.INSD_DISCOUNT) - SUM(ISNULL(INSD_CNCLD_AMT, 0)), 0) AS [Outstanding Fees],
                            STFL_PACKAGE_ID AS packageId,
							STFL_TO_DATE AS ExpiredOn
                     FROM STUDENT_MASTER
                          INNER JOIN STUDENT_FACILITIES ON STUDENT_MASTER.STMT_ADMISSION_NO = STFL_ADMISSION_NO
                          INNER JOIN STUDENT_ADMISSION ON STFL_ADMISSION_NO = STAM_ADMISSION_NO
                          INNER JOIN INSTALLMENTS_DETAILS ON INSTALLMENTS_DETAILS.INSD_FACILITY_ID = STUDENT_FACILITIES.STFL_ID
                     WHERE STFL_TO_DATE BETWEEN CONVERT( DATE, GETDATE()) AND CONVERT(DATE, GETDATE() + @Days)
                           AND STFL_IS_AUTO_RENEW = 0
                           AND STFL_BRANCH_ID like @branchID
                           AND STFL_STATUS = 'A'
                           AND STAM_IS_ACTIVE = 1
						   AND STMT_DEACTIVATED = 'NO'
						   and STFL_TO_DATE between @fromDate and @toDate
                     GROUP BY INSD_FACILITY_ID,
                              STFL_ADMISSION_NO,
                              STMT_FNAME,
                              STMT_LNAME,
                              STMT_CONTACT_NO,
                              STFL_FACILITY_NAME,
							  STFL_FROM_DATE,
                              STFL_To_DATE,
                              STFL_ID,
                              STFL_PACKAGE_ID
                     ORDER BY STFL_TO_DATE ASC;
                 END;

             --Indicates Student with 0 Package/Facility.
             else IF(@identifire = 3)
                 BEGIN
                     SELECT STUDENT_MASTER.STMT_ADMISSION_NO as AdmissionNo,
					 STUDENT_MASTER.STMT_FNAME+'  '+isnull(' ', STUDENT_MASTER.STMT_LNAME) AS Name,
                            STMT_CONTACT_NO ContactNo,
                            STMT_ADMISSION_DATE AS AdmissionDate
                     FROM STUDENT_MASTER
                     WHERE STMT_ADMISSION_NO NOT IN
                     (
                         SELECT STMT_ADMISSION_NO
                         FROM STUDENT_ADMISSION
                              INNER JOIN STUDENT_MASTER ON STUDENT_ADMISSION.STAM_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                         WHERE STAM_BRANCH_ID like @branchID
                               AND STMT_BRANCH_ID like @branchID
                         GROUP BY STAM_ADMISSION_NO,
                                  STMT_ADMISSION_NO
                     )
                         AND STMT_BRANCH_ID like @branchID
                         AND STMT_DEACTIVATED = 'NO';
                 END;

			 else IF(@identifire = 4)
				 BEGIN
				    select ATTD_ADMISSION_NO AS AdmissionNo,
					STMT_FNAME+' '+STMT_LNAME as Name,
					STMT_CONTACT_NO  as ContactNo,
					STFL_FACILITY_NAME as Package,
				     STFL_FROM_DATE AS startdate,
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
					STFL_FACILITY_NAME,STFL_TO_DATE,STFL_ID,STFL_PACKAGE_ID,STFL_FROM_DATE
				 END;


         END TRY
         BEGIN CATCH
             SET @NUM_ERROR_CODE = 0;
             EXEC SP_LogError;
         END CATCH;
     END;
