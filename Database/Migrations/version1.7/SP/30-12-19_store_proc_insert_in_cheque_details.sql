
--Name : s_pr_Update_Cheque
--Developer : Hemlata
--Purpose : This procedure is used to update Details of cheques.
--Tables Used : CHEQUE_DETAILS, [TRANSACTION],FEES,GLB_ACCOUNTS,(Update, Select)
--SP Used : SP_LogError
--Called From : chequeHandler.UpdateCheque() in FrmViewcheques and FrmChequePopup
--Change History 
----------------------------------------------------------------------
--Date		Change		Perpose				Developer 
--30-12-19  add user_admissionNo and current date,  when cheque is submitted it insert user id and current date, kaibalya  


ALTER PROCEDURE s_pr_insert_cheque (@status         VARCHAR(20),
                                          
                                           @BankName       VARCHAR(50),
                                           @BankBranch     VARCHAR(30),
                                           @ChequeNo       VARCHAR(30),
                                           @ChequeDate     DATE,
                                           @ChequeAmount   DECIMAL(18, 2),
                                           @branchid       INT,
										   @std_id		   INT,
										   @currentDate    DATE,
                                           @NUM_ERROR_CODE INT OUTPUT,
										   @USER_ID        VARCHAR(50)    = 'SYSTEM')
AS
     BEGIN
         BEGIN TRY
             SET @NUM_ERROR_CODE = 1;
            
			 insert into Cheque_details (CHQ_STATUS, CHQ_BANK_NAME, CHQ_BANK_BRANCH, CHQ_NO, CHQ_DATE, CHQ_AMOUNT, CHQ_BRANCH_ID, CHQ_USR_ID, CHQ_CRRNT_DT) 
								 values (@status,@BankName,@BankBranch,@ChequeNo,@ChequeDate,@ChequeAmount,@branchid,@std_id, @currentDate);

			
         END TRY
         BEGIN CATCH
             EXEC SP_LogError;
             SET @NUM_ERROR_CODE = 0;
         END CATCH;
     END;




