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

	    