USE [Gymwise1.3]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_student_by_group_of_Enquiry]    Script Date: 19/01/31 3:56:21 PM ******/
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

ALTER PROCEDURE [dbo].[s_pr_get_student_by_group_of_Enquiry](
                                                     @counceller varchar(20),
													 @status varchar(20),
                                                    @BranchID       VARCHAR(20),
                                                    @identifier     INT,
                                                    @USER_ID        VARCHAR(50) = 'SYSTEM',
                                                    @NUM_ERROR_CODE INT OUTPUT)
AS
     BEGIN
         BEGIN TRY
             SET @NUM_ERROR_CODE = 1;
             IF(@identifier = 0)
             
                  
                          
                                         BEGIN
                                             SELECT *
                                             FROM
                                             (
                                                 SELECT ENQUIRY.ENQ_FNAME + ' ' + ENQUIRY.ENQ_MNAME + ' ' + ENQUIRY.ENQ_LNAME AS Name
                                                       	,ENQUIRY.ENQ_CONTACT_NO as 'Contact No',
														  STANDARD.STD_NAME AS Package,
                                                      	ENQ_COUNSELOR as 'Counselor'
														
														
                                                        
                                                 FROM ENQUIRY  
                           INNER JOIN [STANDARD] ON STANDARD.STD_ID =ENQUIRY.ENQ_STANDARD_ID
												      where ENQ_COUNSELOR!='' 
													 and ENQ_COUNSELOR=@counceller
													 and ENQ_STATUS=@status
												 	
                                                    
                                               
                                                 UNION
                                                   SELECT ENQUIRY.ENQ_FNAME + ' ' + ENQUIRY.ENQ_MNAME + ' ' + ENQUIRY.ENQ_LNAME AS Name
                                                       	,ENQUIRY.ENQ_CONTACT_NO as 'Contact No',
														  STANDARD.STD_NAME AS Package,
                                                      	ENQ_COUNSELOR as 'Counselor'
														
														
                                                        
                                                 FROM ENQUIRY  
                           INNER JOIN [STANDARD] ON STANDARD.STD_ID =ENQUIRY.ENQ_STANDARD_ID
												      where ENQ_COUNSELOR!='' 
													 and ENQ_COUNSELOR=@counceller
													 and ENQ_STATUS=@status
													 
                                             ) AS QueryOutput;
											  end;

											

											 
	   IF(@identifier = 1)
             
              
             
                  begin
                          
                                       
                                             SELECT *
                                             FROM
                                             (
                                                 SELECT ENQUIRY.ENQ_FNAME + ' ' + ENQUIRY.ENQ_MNAME + ' ' + ENQUIRY.ENQ_LNAME AS Name
                                                       	,ENQUIRY.ENQ_CONTACT_NO as 'Contact No',
														  STANDARD.STD_NAME AS Package,
                                                      	ENQ_COUNSELOR as 'Counselor'
														
														
                                                        
                                                 FROM ENQUIRY  
                           INNER JOIN [STANDARD] ON STANDARD.STD_ID =ENQUIRY.ENQ_STANDARD_ID
												      where ENQ_COUNSELOR!='' 
													 and STD_NAME=@counceller
													 and ENQ_STATUS=@status
												 	
                                                    
                                               
                                                 UNION
                                                   SELECT ENQUIRY.ENQ_FNAME + ' ' + ENQUIRY.ENQ_MNAME + ' ' + ENQUIRY.ENQ_LNAME AS Name
                                                       	,ENQUIRY.ENQ_CONTACT_NO as 'Contact No',
														  STANDARD.STD_NAME AS Package,
                                                      	ENQ_COUNSELOR as 'Counselor'
														
														
                                                        
                                                 FROM ENQUIRY  
                           INNER JOIN [STANDARD] ON STANDARD.STD_ID =ENQUIRY.ENQ_STANDARD_ID
												      where ENQ_COUNSELOR!='' 
													 and STD_NAME=@counceller
													 and ENQ_STATUS=@status
													 
                                             ) AS QueryOutput;
                          
                                  
											 end
											
											
			 begin  IF(@identifier = 2)
             
                  
                          
                                         BEGIN
                                             SELECT *
                                             FROM
                                             (
                                                 SELECT ENQUIRY.ENQ_FNAME + ' ' + ENQUIRY.ENQ_MNAME + ' ' + ENQUIRY.ENQ_LNAME AS Name
                                                       	,ENQUIRY.ENQ_CONTACT_NO as 'Contact No',
														  STANDARD.STD_NAME AS Package,
                                                        	ENQ_REFERER as 'Referred By'
														
														
                                                        
                                                 FROM ENQUIRY  
                           INNER JOIN [STANDARD] ON STANDARD.STD_ID =ENQUIRY.ENQ_STANDARD_ID
												      where ENQ_COUNSELOR!='' 
													 and ENQ_REFERER=@counceller
													 and ENQ_STATUS=@status
												 	
                                                    
                                               
                                                 UNION
                                                   SELECT ENQUIRY.ENQ_FNAME + ' ' + ENQUIRY.ENQ_MNAME + ' ' + ENQUIRY.ENQ_LNAME AS Name
                                                       	,ENQUIRY.ENQ_CONTACT_NO as 'Contact No',
														  STANDARD.STD_NAME AS Package,
                                                      	ENQ_REFERER as 'Referred By'
														
														
                                                        
                                                 FROM ENQUIRY  
                           INNER JOIN [STANDARD] ON STANDARD.STD_ID =ENQUIRY.ENQ_STANDARD_ID
												      where ENQ_COUNSELOR!='' 
													 and ENQ_REFERER=@counceller
													 and ENQ_STATUS=@status
													 
                                             ) AS QueryOutput;
											  end

                                         END;
										 
                                 
         END TRY
         BEGIN CATCH
             SET @NUM_ERROR_CODE = 0;
             EXEC SP_LogError;
         END CATCH;
     END;




