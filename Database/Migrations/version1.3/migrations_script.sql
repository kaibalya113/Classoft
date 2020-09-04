alter table ACTIVITY_LOG
add ACT_LOGIN_USER varchar(100)


alter table ACTIVITY_LOG
ADD ACT_ADMISSIONNO INT;











ALTER TABLE dbo.STUDENT_FACILITIES ADD
	STFL_DISCOUNT_REASON varchar(400) NULL;


ALTER TABLE STUDENT_MASTER
 ADD STMT_HEATH_ISSUE VARCHAR(500)



alter table branch_master add NOTIFICATION_SENT_DATE varchar(50);




        create table MEASUREMENTS
		( MM_MID int,
            MM_ADMISSION_NO int,          
            MM_WEIGHT decimal(18,2),
            MM_BMI decimal(18,2),
            MM_HEIGHT decimal(18,2),
            MM_FAT decimal(18,2),
            MM_NECK decimal(18,2),
            MM_SHOULDER decimal(18,2),
            MM_CHEST decimal(18,2),
            MM_ARMS decimal(18,2),
            MM_HIPS decimal(18,2),
            MM_THIGH decimal(18,2),
            MM_CALVES decimal(18,2),
            MM_FOREARMS decimal(18,2),
            MM_UPPER_ABD decimal(18,2),
            MM_LOWER_ABD decimal(18,2),
            MM_WAIST decimal(18,2),
			MM_ID int identity,
			MM_DATE datetime,
			MM_BRANCHID varchar(50)
			)



USE [Gymwise1.3]
GO
/****** Object:  Trigger [dbo].[TRG_student_measurement_AFTER_INSERT]    Script Date: 19/01/21 3:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TRG_STUD_MEASUREMENT_AFTR_INSRT] ON [dbo].[MEASUREMENTS]
AFTER INSERT
AS
BEGIN
	DECLARE @newid INT
	DECLARE @id INT
	DECLARE @branchid INT

	SET @id = (
			SELECT MM_ID
			FROM inserted
			);
	SET @branchid = (
			SELECT MM_BRANCHID
			FROM inserted
			);
	SET @newid = CONVERT(INT, CONVERT(NVARCHAR, @branchid) + CONVERT(NVARCHAR, @id));

	IF (@newid IS NOT NULL)
		UPDATE MEASUREMENTS
		SET MM_MID = @newid
		WHERE MM_ID = @id
			AND MM_BRANCHID= @branchid
END



drop foreign key from facility_update table.FK_FACILITY_UPDATE_STUDENT_FACILITIES