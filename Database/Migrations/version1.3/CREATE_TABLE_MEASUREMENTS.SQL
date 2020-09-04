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

		
