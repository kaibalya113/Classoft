USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_disp_followups_report]    Script Date: 19/01/28 1:00:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Name : s_pr_disp_followups
--Developer : Hemlata
--Purpose : This Procedure is used to display the FollowUp Of Enquired Students only Of Particular Branch.
--Tables Used : ENQUIRY,BRANCH,FOLLOW_UP (Select)
--SP Used : Sp_logerror
--Called From : FollowUpHandler.getFolloups() in FrmFollowUpView
--Change History 
----------------------------------------------------------------------
--Date		Change		Perpose				Developer


ALTER PROCEDURE [dbo].[s_pr_disp_followups_report](@fromDate       DATE,
                                            @toDate         DATE,
                                            @BranchID       VARCHAR(20),
                                            @NUM_ERROR_CODE INT OUTPUT)
AS
     BEGIN
         BEGIN TRY
             SELECT ENQUIRY.ENQ_ID,
                    ENQUIRY.ENQ_FNAME+' '+ENQUIRY.ENQ_LNAME+' '+ENQUIRY.ENQ_MNAME AS Name,
                    ENQUIRY.ENQ_CONTACT_NO,
                    STANDARD.STD_NAME,
                   CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT)  as 'FollowupDate',
                   --FOLLOW_UP.FOLU_DESCRIPTION,
                    BRANCH_MASTER.BRCH_NAME,
                    ENQ_BRANCH_ID,
                    ENQ_IS_REGISTERED,
				    ENQ_STATUS,
				    Prev_FollowUp=STUFF  
(  
    (  
	SELECT DISTINCT  CHAR(10) + CAST(FOLU_DATE as varchar(50)) +' : '+ 
 CAST(FOLU_DESCRIPTION  AS VARCHAR(MAX)) 
      FOR XMl PATH('')  
    ),1,1,'' 
	) 
             FROM ENQUIRY
                  INNER JOIN FOLLOW_UP ON ENQUIRY.ENQ_ID = FOLLOW_UP.FOLU_REF_NO
                     and ENQUIRY.ENQ_ID= FOLLOW_UP.FOLU_REF_NO                    
                  INNER JOIN STANDARD ON ENQUIRY.ENQ_STANDARD_ID = STANDARD.STD_ID
                  INNER JOIN BRANCH_MASTER ON ENQUIRY.ENQ_BRANCH_ID = BRANCH_MASTER.BRCH_ID
             WHERE( CONVERT(date, FOLLOW_UP.FOLU_CRTD_AT)   BETWEEN @fromDate AND @toDate)
                  AND (ENQUIRY.ENQ_BRANCH_ID LIKE @BranchID)
                  AND (ENQUIRY.ENQ_IS_REGISTERED = 0);
             SET @NUM_ERROR_CODE = 1;
         END TRY
         BEGIN CATCH
             EXEC SP_LogError;
             SET @NUM_ERROR_CODE = 0;
         END CATCH;
     END;




