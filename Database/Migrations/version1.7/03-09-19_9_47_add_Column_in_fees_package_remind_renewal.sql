ALTER TABLE FEES_PACKAGES ADD
	FPKG_RMIND_RENEWAL bit NULL;

ALTER TABLE FEES_PACKAGES  ADD CONSTRAINT
	DF_STUDENT_FACILITIES_STFL_REMIND_RENEWAL DEFAULT 0 FOR FPKG_RMIND_RENEWAL;

ALTER TABLE dbo.STUDENT_FACILITIES ADD
	STFL_REMIND_RENEWAL bit NULL;

ALTER TABLE dbo.STUDENT_FACILITIES ADD CONSTRAINT
	DF_STUDENT_FACILITIES_STFL_REMIND_RENEWAL DEFAULT 0 FOR STFL_REMIND_RENEWAL;

ALTER TABLE dbo.STUDENT_FACILITIES ADD
	STFL_INSTRUCTIR_ID int NULL;

ALTER TABLE dbo.STUDENT_FACILITIES ADD
	STFL_EXPIRY_SMS_DATE date NULL;