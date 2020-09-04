USE [DindoriGym]
GO
/****** Object:  StoredProcedure [dbo].[s_pr_get_attendance]    Script Date: 07-Jan-20 07:18:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Name : [s_pr_get_attendance]
--Developer : Hemlata
--Purpose :This procedure is Used To get the Attendance of (Student and Faculty).
--Tables Used :STUDENT_ADMISSION,STUDENT_FACILITIES, Branch,BATCH,ATTENDANCE_LECTURE,FACULTY (select)
--SP Used : SP_LogError
--Called From : AttendanceHandler.getAttendanceStatus() in FrmAttendence and FrmAttendanceSheet.
--After Marking the attendance Manually , it is called to fetch the marked attendance.
--Change History 
----------------------------------------------------------------------
--Date		Change		Perpose				Developer
ALTER PROCEDURE [dbo].[s_pr_get_attendance]
(@stream         VARCHAR(20),
 @course         VARCHAR(20),
 @batch          VARCHAR(20),
 @fromDate       DATE,
 @toDate         DATE,
 @branchId       VARCHAR(20),
 @absentStatus   VARCHAR(1),
 @userType       VARCHAR(10),
 @LectureID      INT,
 @USER_ID        VARCHAR(50) = 'SYSTEM',
 @NUM_ERROR_CODE INT OUTPUT
)
AS
    BEGIN TRY
        SET @NUM_ERROR_CODE = 1;
		set @fromDate = convert(date,@fromDate);
		set @toDate = convert(date,@toDate);


        IF(@userType = 'S')
            BEGIN
                IF(@LectureID = 0)
                    BEGIN   
						SELECT Distinct 
								 case when ATTENDENCE.ATTD_IN_TIME is null then 1 else 0 end as sort_order,
								   ATTENDENCE.ATTD_ID,
								   ATTENDENCE.Id,
								   ATTENDENCE.ATTD_DATE,
								   ATTENDENCE.ATTD_ADMISSION_NO,
								   ATTENDENCE.Name,
								   ATTENDENCE.ATTD_STATUS,
								   ATTENDENCE.ATTD_IN_TIME,
								   ATTENDENCE.ATTD_OUT_TIME,
								   ATTENDENCE.Total,
								   ATTENDENCE.ATTD_IS_HOLIDAY,
								   ATTENDENCE.STMT_FATHER_CONTACT,
							   --  ATTENDENCE.STRM_NAME,
							   							  ATTD_LECTURE_ID,

							   --   ATTENDENCE.STD_NAME,
							--	  BTCH_NAME,
								--  STRM_ID,
								--  STD_ID,
								--   btch_id,
								   ATTD_REMARK
							FROM
							(
								SELECT DISTINCT
									   ATTENDANCE.ATTD_ID,
									   ATTENDANCE.ATTD_DATE,
									   ATTENDANCE.ATTD_ADMISSION_NO,
									   STUDENT_MASTER.STMT_MEMSHIP_NO as 'Id',
									   STUDENT_MASTER.STMT_FNAME+' '+STUDENT_MASTER.STMT_LNAME AS 'Name',
									   ATTENDANCE.ATTD_STATUS,
									CONVERT(varchar(15),CAST(ATTENDANCE.ATTD_IN_TIME AS TIME),100) as [ATTD_IN_TIME],
									 CONVERT(varchar(15),CAST(ATTENDANCE.ATTD_OUT_TIME AS TIME),100) as [ATTD_OUT_TIME],
								      
								
                                  
								CAST((ATTENDANCE.ATTD_OUT_TIME-ATTD_IN_TIME) as time(0)) as 'Total' ,
									   ATTENDANCE.ATTD_IS_HOLIDAY,
									   STUDENT_MASTER.STMT_FATHER_CONTACT,
									   STREAM.STRM_NAME,
									   [STANDARD].STD_NAME,
									   BATCH.BTCH_NAME,
									  ATTD_LECTURE_ID,
									   STREAM.STRM_ID,
									   [STANDARD].STD_ID,
									   batch.btch_id,
									   ATTD_REMARK
								FROM STUDENT
									 INNER JOIN STUDENT_MASTER ON STUDENT.STUD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
									 INNER JOIN STUDENT_ADMISSION ON STUDENT.STUD_ADMISSION_NO = STUDENT_ADMISSION.STAM_ADMISSION_NO
									 INNER JOIN batch ON batch.btch_id = student_admission.stam_batch_id
									 INNER JOIN STANDARD ON STUDENT_ADMISSION.STAM_STD_ID = STANDARD.STD_ID
									 INNER JOIN STREAM ON STANDARD.STD_STREAM_ID = STREAM.STRM_ID
									 LEFT OUTER JOIN ATTENDANCE ON STUDENT.STUD_ADMISSION_NO = ATTENDANCE.ATTD_ADMISSION_NO
								WHERE(ATTENDANCE.ATTD_BRANCH_ID LIKE @branchId)
									 AND (STUDENT_ADMISSION.STAM_STD_ID LIKE @course)
									 AND (STUDENT_ADMISSION.STAM_BATCH_ID LIKE @batch)
									 AND (ATTENDANCE.ATTD_DATE >= @fromDate
										  AND ATTENDANCE.ATTD_DATE <= @toDate)
									 AND (ATTENDANCE.ATTD_STATUS LIKE @absentStatus)
									 --AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
							) AS ATTENDENCE
							ORDER BY  ATTENDENCE.ATTD_DATE,
									  1,
									  ATTENDENCE.ATTD_IN_TIME;
					end;
                    ELSE
                    BEGIN
                        SELECT DISTINCT ATLC_ID,
                               STUDENT_MASTER.STMT_FNAME+'  '+STUDENT_MASTER.STMT_LNAME AS 'Name',
                               ATLC_ADMISSION_NO AS 'ATTD_ADMISSION_NO',
                               ATLC_DATE AS 'ATTD_DATE',
                               ATLC_STATUS AS 'ATTD_STATUS',
                               STUDENT_MASTER.STMT_FATHER_CONTACT,
                               BATCH.BTCH_Id,
                               [standard].STD_ID,
                               STREAM.STRM_ID,
                               STREAM.STRM_NAME,
                               STANDARD.STD_NAME,
                               BATCH.BTCH_NAME					
                        FROM STUDENT_MASTER
                             INNER JOIN ATTENDANCE_LECTURE ON ATTENDANCE_LECTURE.ATLC_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO
                             INNER JOIN TIME_TABLE ON TIME_TABLE.TMTL_ID = ATTENDANCE_LECTURE.ATLC_LECTURE_ID
                             INNER JOIN BATCH ON BATCH.BTCH_Id = TIME_TABLE.TMTL_BATCH_ID
                             INNER JOIN STANDARD ON STANDARD.STD_ID = BATCH.BTCH_STANDARD_ID
                             INNER JOIN STREAM ON STREAM.STRM_ID = STANDARD.STD_STREAM_ID
					         inner join STUDENT_ADMISSION on STUDENT_MASTER.STMT_ADMISSION_NO = STAM_ADMISSION_NO					 
                        WHERE STAM_STD_ID like @course and STAM_BATCH_ID like @batch 
						and ATLC_DATE = @fromDate and ATLC_DATE = @toDate
                        AND TIME_TABLE.TMTL_BATCH_ID like @batch
                        AND ATLC_LECTURE_ID = @LectureID
						and ATLC_BRANCH_ID like @branchId
						AND (ATLC_STATUS LIKE @absentStatus)
                        --AND STUDENT_ADMISSION.STAM_IS_ACTIVE = 1
						order by 2 asc  
					END;
			END;
        ELSE
        IF(@LectureID = 0)
            BEGIN
              SELECT distinct 
			  case when ATTENDANCE.ATTD_IN_TIME is null then 1 else 0 end as sort_order,
						ATTENDANCE.ATTD_ID,
                       ATTENDANCE.ATTD_DATE,
                       ATTENDANCE.ATTD_ADMISSION_NO,
                       FACULTY.FCLT_NAME AS 'Name',
                       ATTENDANCE.ATTD_STATUS,
                      CONVERT(varchar(15),CAST(ATTENDANCE.ATTD_IN_TIME AS TIME),100) as [ATTD_IN_TIME],
					  CONVERT(varchar(15),CAST(ATTENDANCE.ATTD_OUT_TIME AS TIME),100) as [ATTD_OUT_TIME],
                      CAST((ATTENDANCE.ATTD_OUT_TIME-ATTD_IN_TIME) as time(0)) as 'Total' ,
                       --datediff(MINUTE,  ATTENDANCE.ATTD_IN_TIME,ATTENDANCE.ATTD_OUT_TIME)/60.00 as "Total",
                       ATTENDANCE.ATTD_IS_HOLIDAY,
                       FACULTY.FCLT_CONTACT_NO,
                       ATTD_REMARK
                FROM ATTENDANCE
                     INNER JOIN FACULTY ON ATTENDANCE.ATTD_ADMISSION_NO = FACULTY.FCLT_ID
                   -- INNER JOIN LOGIN ON LOGIN.LGN_REGID = FCLT_LGN_REGD_ID
                WHERE(ATTENDANCE.ATTD_BRANCH_ID LIKE @branchId)
                     AND (ATTENDANCE.ATTD_DATE >= @fromDate
                          AND ATTENDANCE.ATTD_DATE <= @toDate)
                     AND (ATTENDANCE.ATTD_STATUS LIKE @absentStatus)
                   -- AND (LOGIN.LGN_TYPE IN('F', 'A'))
                ORDER BY ATTENDANCE.ATTD_DATE,
                         1,ATTD_IN_TIME;
			END;
        ELSE
            BEGIN
            SELECT distinct ATTENDANCE_LECTURE.ATLC_ID AS 'ATLC_ID',
                       ATTENDANCE_LECTURE.ATLC_DATE AS 'Date',
                       ATTENDANCE_LECTURE.ATLC_ADMISSION_NO as 'ATTD_ADMISSION_NO',
                       FACULTY.FCLT_NAME AS 'Name',
                       ATTENDANCE_LECTURE.ATLC_STATUS AS 'ATTD_STATUS',
                     
                       FACULTY.FCLT_CONTACT_NO AS 'ContactNo',
                       ATLC_REMARK AS 'Remark'
                FROM ATTENDANCE_LECTURE
                     INNEr JOIN FACULTY ON ATTENDANCE_LECTURE.ATLC_ADMISSION_NO = FACULTY.FCLT_ID
                     --INNER JOIN LOGIN ON LOGIN.LGN_REGID = ATTENDANCE_LECTURE.ATLC_ADMISSION_NO
				 --inner join ATTENDANCE_LECTURE on ATTENDANCE_LECTURE.ATLC_ADMISSION_NO=FACULTY.FCLT_ID
                     INNER JOIN TIME_TABLE ON ATTENDANCE_LECTURE.ATLC_LECTURE_ID = TIME_TABLE.TMTL_ID
                WHERE(ATTENDANCE_LECTURE.ATLC_BRANCH_ID LIKE @branchId)
                     AND (ATTENDANCE_LECTURE.ATLC_DATE >= @fromDate
                          AND ATTENDANCE_LECTURE.ATLC_DATE <= @toDate)
                     AND (ATTENDANCE_LECTURE.ATLC_STATUS LIKE @absentStatus)
                    -- AND (LOGIN.LGN_TYPE IN('F', 'A'))
                ORDER BY ATTENDANCE_LECTURE.ATLC_DATE,
                         4;
            END;
    END TRY
    BEGIN CATCH
        EXECUTE sp_logError;
        SET @NUM_ERROR_CODE = 0;
    END CATCH;
