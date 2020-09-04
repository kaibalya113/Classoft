using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;

namespace ClassManager.BLL
{
    public class AttendanceHandler
    {

        static SqlCommand com;


        public static DataTable getAttendanceStatus(string stream, string course, string batch, DateTime fromDate, DateTime toDate, string branchId, string isPresent, string userType = "S", int LectureID = 0)
        {
            try
            {

                com = new SqlCommand("s_pr_get_attendance");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@stream", SqlDbType.VarChar).Value = (stream == "-1") ? "%" : stream.ToString();
                com.Parameters.Add("@course", SqlDbType.VarChar).Value = (course == "-1") ? "%" : course.ToString();
                com.Parameters.Add("@batch", SqlDbType.VarChar).Value = (batch == "-1") ? "%" : batch.ToString();
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@absentStatus", SqlDbType.VarChar).Value = isPresent;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@userType", SqlDbType.VarChar).Value = userType;
                com.Parameters.Add("@LectureID", SqlDbType.Int).Value = LectureID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtAttendance = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtAttendance;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static int getAttendenceCountToday(int admissionNo, DateTime toDate)
        {
            try
            {

                com = new SqlCommand("s_pr_get_attendence_checkin_status");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@AttdDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = admissionNo;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                object count = Sqlhelper.ExeScaler(com);
                int c = Convert.ToInt32(count);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return c;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static DataTable getAttdCount(string branchId)
        {
            try
            {

                com = new SqlCommand("s_pr_get_attendance_Count");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtAttendance = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtAttendance;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable readLog(String filePath, int branchId)
        {
            try
            {
                //Need to be rewritten, considering WinApp reference
                DataTable logDt = Common.FileHandller.readFromCSV(filePath, Info.SysParam.getValue<char>(Info.SysParam.Parameters.ATTNDCE_LOG_COL_SEPERATOR));

                //Reformat table as per Attendencelog format

                DataTable attendenceLog = new DataTable();
                attendenceLog.Columns.Add(new DataColumn("id", Type.GetType("System.Int32")));
                attendenceLog.Columns.Add("user_id");
                attendenceLog.Columns.Add(new DataColumn("checkin_time", Type.GetType("System.DateTime")));
                attendenceLog.Columns.Add("device_id");
                attendenceLog.Columns.Add("Branch_ID");
                attendenceLog.Columns.Add(new DataColumn("date_imported", Type.GetType("System.DateTime")));



                foreach (DataRow logRow in logDt.Rows)
                {
                    DataRow dr = attendenceLog.NewRow();
                    dr["user_id"] = logRow[ClassManager.Info.SysParam.getValue<Int32>(Info.SysParam.Parameters.ATTNDCE_USERID_COL_INDEX)];
                    dr["checkin_time"] = Convert.ToDateTime((logRow[ClassManager.Info.SysParam.getValue<Int32>(Info.SysParam.Parameters.ATTNDCE_PUNCH_TIME_INDEX)]));
                    dr["device_id"] = Common.Properties.Settings.Default.MACHINE_IP;
                    dr["Branch_ID"] = branchId;
                    dr["date_imported"] = DateTime.Now;
                    attendenceLog.Rows.Add(dr);
                }

                return attendenceLog;


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool uploadAttendenceLog(DataTable attendenceLog)
        {
            try
            {


                using (SqlBulkCopy bc = new SqlBulkCopy(DAL.Sqlhelper.ConString))
                {
                    // Destination table with owner - this example doesn't
                    // check the owner and table names!
                    bc.DestinationTableName = "ATTENDENCE_LOG";


                    // Starts the bulk copy.
                    bc.WriteToServer(attendenceLog);

                    // Closes the SqlBulkCopy instance
                    bc.Close();
                }

                return true;


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static bool prepareAttendeceFromLog(DateTime fromDate, DateTime toDate, string branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_calc_attendence");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool updateAttendaceStatus(bool lateStatus, int admisionNo, string status, int branchId, bool isLectureSelected,DateTime? intime,DateTime? outTime, string remark = "NA")
        {
            try
            {
                com = new SqlCommand("s_pr_update_attendance");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@attendanceId", SqlDbType.Int).Value = admisionNo;
                com.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
                com.Parameters.Add("@lateStatus", SqlDbType.Bit).Value = lateStatus;
                //Added For Faculty.Mohan(27-July-2017).
                com.Parameters.Add("@remarkforFaculty", SqlDbType.VarChar).Value = remark;
                com.Parameters.Add("@BRANHC_ID", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@isLectureSelected", SqlDbType.Bit).Value = isLectureSelected;
                if(intime == null)
                {
                    com.Parameters.Add("@in_time", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@in_time", SqlDbType.DateTime).Value = intime;
                }

                if (outTime == null)
                {
                    com.Parameters.Add("@out_time", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@out_time", SqlDbType.DateTime).Value = outTime;
                }
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        
        public static Int32 logAttendence(int userID, int branchId, DateTime checkInTime, string deviceId,out int sendSMS)
        {
            try
            {
                sendSMS = 0;
                com = new SqlCommand("s_pr_log_attendence");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@biometricId", SqlDbType.Int).Value = userID;
                com.Parameters.Add("@checinTime", SqlDbType.DateTime).Value = checkInTime;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@sendSMS", SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                com.Parameters.Add("@deviceId", SqlDbType.NVarChar).Value = deviceId;
                com.Parameters.Add("@CheckInStatus", SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);
                if (com.Parameters["@NUM_ERROR_CODE"].Value.ToString().Equals("52"))
                {
                    return 52;

                }
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    sendSMS = Convert.ToInt32(com.Parameters["@sendSMS"].Value);
                    return Convert.ToInt32(com.Parameters["@CheckInStatus"].Value);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static Int32 FetchLogAttendance(int userID, int branchId, DateTime checkInTime, string deviceId, DateTime From, DateTime To)
        {
            try
            {
                com = new SqlCommand("s_pr_Bulk_Log_Attendence");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@biometricId", SqlDbType.Int).Value = userID;
                com.Parameters.Add("@checinTime", SqlDbType.DateTime).Value = checkInTime;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@deviceId", SqlDbType.NVarChar).Value = deviceId;
                com.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = From.Date;
                com.Parameters.Add("@toDate", SqlDbType.DateTime).Value = To.Date;
                //  com.Parameters.Add("@CheckInStatus", SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Convert.ToInt32(com.Parameters["@NUM_ERROR_CODE"].Value); ;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static DataTable getLecturewiseAbsentStudent(DateTime Date, string Branch)
        {
            try
            {
                com = new SqlCommand("s_pr_get_lecturewise_absent_students");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = Branch;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                DataTable dtAbStudent = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtAbStudent;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static bool updateAttdLecture(Int64 Id)
        {
            try
            {

                com = new SqlCommand("update ATTENDANCE_LECTURE set atlc_is_SMS_SEND = 1 where atlc_id =" + Id);
                com.CommandType = CommandType.Text;

                return Sqlhelper.ExecuteQuery(com);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static bool markAttendenceManually(string batchid, string stdid, DateTime date, string branchID, int lectureID = 0, bool isFacultyAttendance = false)
        {
            try
            {
                com = new SqlCommand("s_pr_load_student_manual_attendence");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@standardid", SqlDbType.VarChar).Value = (stdid == "-1") ? "%" : stdid.ToString();
                com.Parameters.Add("@batchid", SqlDbType.VarChar).Value = (batchid == "-1") ? "%" : batchid.ToString();
                com.Parameters.Add("@date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@isFacultyAttendance", SqlDbType.Bit).Value = isFacultyAttendance;
                com.Parameters.Add("@lectureID", SqlDbType.VarChar).Value = lectureID;
                //com.Parameters.Add("@Remark", SqlDbType.VarChar).Value = lectureID;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add("@NUM_ERROR_CODE", SqlDbType.Int).Direction = ParameterDirection.Output;
                   Sqlhelper.ExecuteNonQuery(com);
            //    DataTable dtAttendance = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                    //return null;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable getStduentAttendance(DateTime fromDate, DateTime toDate, string branchId, int AdmisionNo)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_disp_student_attendance");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = AdmisionNo;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                DataTable dtStudAttendance = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtStudAttendance;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static bool populateLecturesinAttendanceLog(string lectureDate, int branchid)
        {

            try
            {
                com = new SqlCommand("s_pr_populate_lectures_attendance_log");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@lect_date", SqlDbType.Date).Value = lectureDate;
                com.Parameters.Add("@branchid", SqlDbType.Int).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool markLectureAttendance(int stdID, int batchID, DateTime lectDate, bool isFacultyAttendance, int branchID, int lectureID)
        {
            try
            {
                com = new SqlCommand("s_pr_mark_lecture_attendance");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@standardid", SqlDbType.Int).Value = stdID;
                com.Parameters.Add("@batchid", SqlDbType.Int).Value = batchID;
                com.Parameters.Add("@date", SqlDbType.Date).Value = lectDate;
                com.Parameters.Add("@isFacultyAttendance", SqlDbType.Bit).Value = isFacultyAttendance;

                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchID;
                com.Parameters.Add("@lectureID", SqlDbType.Int).Value = lectureID;
                com.Parameters.Add("@NUM_ERROR_CODE", SqlDbType.Int).Direction = ParameterDirection.Output;
                // DataTable dt=Sqlhelper.GetDatatable(objSqlCmd);
                Sqlhelper.ExecuteNonQuery(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    //throw new Common.Exceptions.InvalidReturnCodeException(com);
                    return false;
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public void logAttendence(int branchId, string ipAddress, string BioId, DateTime punchInTime)
        {
            try
            {

                int enrollmentNo = Convert.ToInt32(BioId);
                int isChekin;

                DateTime timePunchIn = new DateTime();
                try
                {
                    Common.Log.LogError(Common.Log.Level.INFORMATION, "Started AttandanceHandler.Log Attendance");
                    timePunchIn = punchInTime;
                    int sendSMS;
                    isChekin = ClassManager.BLL.AttendanceHandler.logAttendence(enrollmentNo, branchId, timePunchIn, ipAddress,out sendSMS );
                }
                catch (Exception ex)
                {
                    Common.Log.LogError(Common.Log.Level.INFORMATION, "Error checkin. ");
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(Common.Log.Level.ERROR, ex.Message);
            }
        }

        //For School


        public static DataTable getAbsentNo(string streamId, string stdID, string sID, string branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_disp_Absnt_No");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Stream", SqlDbType.VarChar).Value = streamId;
                com.Parameters.Add("@Course", SqlDbType.VarChar).Value = stdID;
                com.Parameters.Add("@Batch", SqlDbType.VarChar).Value = sID;
                com.Parameters.Add("@Branch_id ", SqlDbType.Int).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                DataTable dtStud = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtStud;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        internal static bool updateAbsentSMSStaus(int attdId, int attLectureId)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                if(attLectureId != 0)
                {
                    com.CommandText = "update ATTENDANCE_LECTURE set ATLC_IS_SMS_SEND = 1 where ATLC_ID = " + attLectureId;
                }
                else
                {
                    com.CommandText = "update ATTENDANCE set ATTD_SMS_SENT = 1 where ATTD_ID = " + attdId;
                }
                
                Sqlhelper.ExecuteQuery(com);

                return true;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
    }
}
