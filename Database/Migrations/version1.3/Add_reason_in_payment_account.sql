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




