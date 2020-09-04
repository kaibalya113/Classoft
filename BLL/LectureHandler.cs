using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.Info;
using ClassManager.DAL;
namespace ClassManager.BLL
{
    public class LectureHandler
    {
        
        
        public static int saveLectures(Info.Lecture objLect)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_add_lecture");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@LectureID", SqlDbType.Int).Value = objLect.LectureID;
                com.Parameters.Add("@streamID", SqlDbType.Int).Value = objLect.Stream.ID;
                com.Parameters.Add("@stadndardID", SqlDbType.Int).Value = objLect.Standard.Standardid;
                com.Parameters.Add("@batchID", SqlDbType.VarChar).Value = objLect.Batch.id;
                com.Parameters.Add("@date", SqlDbType.Date).Value = objLect.Date;
                com.Parameters.Add("@expectedPortion", SqlDbType.VarChar).Value = objLect.ExpectedPortion;
                com.Parameters.Add("@facultyId", SqlDbType.Int).Value = objLect.Faculty.FacultyID;
                com.Parameters.Add("@location", SqlDbType.VarChar).Value = objLect.Batch.location==null?"":objLect.Batch.location;
                com.Parameters.Add("@from_time", SqlDbType.Time).Value = objLect.FromTime.TimeOfDay;
                com.Parameters.Add("@to_time", SqlDbType.Time).Value = objLect.ToTime.TimeOfDay;
                com.Parameters.Add("@subjID", SqlDbType.Int).Value = objLect.Subject.SubjId;
                com.Parameters.Add("@t_ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                com.Parameters.Add("@branch_id", SqlDbType.Int).Value = objLect.BranchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Convert.ToInt32(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value);
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

        public static int updateLectures(Info.Lecture objLect)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_update_lecture");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@LectureID", SqlDbType.Int).Value = objLect.LectureID;
              //  com.Parameters.Add("@streamID", SqlDbType.Int).Value = objLect.Stream.ID;
              //  com.Parameters.Add("@stadndardID", SqlDbType.Int).Value = objLect.Standard.Standardid;
              //  com.Parameters.Add("@batchID", SqlDbType.VarChar).Value = objLect.Batch.id;
              //  com.Parameters.Add("@date", SqlDbType.Date).Value = objLect.Date;
              //  com.Parameters.Add("@facultyId", SqlDbType.Int).Value = objLect.Faculty.FacultyID;
              //  com.Parameters.Add("@from_time", SqlDbType.Time).Value = objLect.FromTime.TimeOfDay;
              //  com.Parameters.Add("@to_time", SqlDbType.Time).Value = objLect.ToTime.TimeOfDay;
              //  com.Parameters.Add("@subjID", SqlDbType.Int).Value = objLect.Subject.SubjId;
                com.Parameters.Add("@expectedPortion", SqlDbType.VarChar).Value = objLect.ExpectedPortion;
                com.Parameters.Add("@actualDone", SqlDbType.VarChar).Value = objLect.ActualDone;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Convert.ToInt32(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value);
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

        public static List<Lecture> getLectures(DateTime date, int batchid)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_Batchwise_Lectures");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@batchid", SqlDbType.Int).Value = batchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtLec = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Lecture.getLecture(dtLec);
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

        public static List<Lecture> GetFacultyLec(int FacultyId, DateTime date, string branchId)
        { 
          try 
           {	  
                SqlCommand com = new SqlCommand("s_pr_get_Facultywise_Lectures");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@FacultyId", SqlDbType.Int).Value = FacultyId;
                com.Parameters.Add("@date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtLec = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Lecture.getLecture(dtLec);
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

        public static bool deleteLecture(int lectureId, int branchId)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_delete_lecture");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@LectId", SqlDbType.Int).Value = lectureId;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
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

        //public static bool isLectureScheduled(string stream, string course, string batch, DateTime fromDate, DateTime toDate, string branchID, string p)
        //{
        //    return false;
        //}

        public static List<Lecture> getLecturesDetails(Info.Lecture objLect, DateTime fromDate, DateTime toDate, string branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_LectureDetails");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@stream", SqlDbType.VarChar).Value = (objLect.Stream.ID == 0) ? "%" : objLect.Stream.ID.ToString();
                com.Parameters.Add("@course", SqlDbType.VarChar).Value = (objLect.Standard.Standardid == 0) ? "%" : objLect.Standard.Standardid.ToString();
                com.Parameters.Add("@batch", SqlDbType.VarChar).Value = (objLect.Batch.id == 0) ? "%" : objLect.Batch.id.ToString();
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtLec = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Lecture.getLectures(dtLec);
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

        public static List<Lecture> getSubjectsForAttendance(int stdID, int btchID, DateTime lectDate, int branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_disp_subject_for_attendance");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@course_id", SqlDbType.VarChar).Value = (stdID == -1) ? "%" : stdID.ToString();
                com.Parameters.Add("@batch_id", SqlDbType.VarChar).Value = (btchID == -1) ? "%" : btchID.ToString(); 
                com.Parameters.Add("@lect_date", SqlDbType.Date).Value = lectDate;                                                                               
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtLec = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Lecture.getLectures(dtLec);
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


        public static bool insertScheduledLect(ScheduledLecture objLect,int branch)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_insert_scheduledLect");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@AdmissionNo", SqlDbType.VarChar).Value = objLect.AdmissionNo;
                com.Parameters.Add("@ToTime", SqlDbType.Time).Value = objLect.ToTime.TimeOfDay;
                com.Parameters.Add("@fromTime", SqlDbType.Time).Value = objLect.FromTime.TimeOfDay;
                com.Parameters.Add("@biometricId", SqlDbType.VarChar).Value =objLect.BiometricId;
                com.Parameters.Add("@standard", SqlDbType.VarChar).Value = objLect.Standard;
                com.Parameters.Add("@Day", SqlDbType.VarChar).Value = objLect.Day;
                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branch;
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

        //public static void repeatLecture( string subName, string lectdate)
        //{
        //    try
        //    {
        //        SqlCommand com = new SqlCommand("s_pr_repeat_lecture");
        //        com.CommandType = CommandType.StoredProcedure;

        //        com.Parameters.Add("@lectDate", SqlDbType.VarChar).Value = lectdate;
        //        com.Parameters.Add("@subName", SqlDbType.VarChar).Value = subName;

        //        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

        //        Sqlhelper.ExecuteNonQuery(com);

        //        if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
        //        {
        //            //return Lecture.getLectures(dtLec);
        //        }
        //        else
        //        {
        //            throw new Common.Exceptions.InvalidReturnCodeException(com);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
        //        throw ex;
        //    }
        //}
    }
}
