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



