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




