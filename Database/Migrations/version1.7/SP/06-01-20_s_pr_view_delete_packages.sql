USE [DindoriGym]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_view_delete_packages]    Script Date: 07-Jan-20 09:26:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[s_pr_view_delete_packages](
                                           @BRANCHID      varchar(20),
                                           @USER_ID        VARCHAR(50) = 'SYSTEM',
                                           @NUM_ERROR_CODE INT OUTPUT)
AS
BEGIN TRY
        SET @NUM_ERROR_CODE = 1;
           select distinct 
		   --STMT_ADMISSION_NO as AdmissionNo, 
		   STMT_MEMSHIP_NO as ID, 
		   STMT_FNAME+' '+STMT_LNAME as Name,
		   STFL_FACILITY_NAME as Package ,
		   Sum(INSD_CNCLD_AMT) as CancelledFee,
		   convert(Date,STFL_UPDT_AT)  as Date
           from STUDENT_FACILITIES
            inner join STUDENT_MASTER on STMT_ADMISSION_NO = STFL_ADMISSION_NO
            inner join INSTALLMENTS_DETAILS on INSD_FEES_ID = STFL_FEES_ID and INSD_FACILITY_ID = STFL_ID
             where STFL_STATUS = 'D' and STFL_BRANCH_ID = @BRANCHID
             group by INSD_FACILITY_ID,
			 STMT_ADMISSION_NO ,STMT_MEMSHIP_NO,
			 STMT_FNAME+' '+STMT_LNAME,
			 STFL_FACILITY_NAME, convert(Date,STFL_UPDT_AT)
             order by convert(Date,STFL_UPDT_AT) desc
    END TRY
    BEGIN CATCH
        EXECUTE sp_logError;
        SET @NUM_ERROR_CODE = 0;
    END CATCH;
     RETURN;
