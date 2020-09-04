using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;

namespace ClassManager.BLL
{
    public class StreamHandller
    {

       public static SqlCommand com;
        public static List<Info.Stream> getStreams(string branchID)
        {
            try
            {
                           
                SqlCommand com = new SqlCommand("s_pr_get_stream");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStream = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Stream.getStreams(dtStream);
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

        public static DataTable getCourses(string branchID)
        {
            try
            {

                SqlCommand com = new SqlCommand("s_pr_disp_all_courses");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtCourse = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtCourse;
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



        public static DataTable getStandardCount(string branchID, string Identifire)
        {
            try
            {

                SqlCommand com = new SqlCommand("s_pr_get_studentCount_by_course");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Identifire", SqlDbType.VarChar).Value = Identifire;
                com.Parameters.Add("@Branch_ID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtCourse = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtCourse;
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
        public static List<Info.Faculty> getFaculty(int branchId)
        {
            try
            {


               
                string query = "select FCLT_ID, FCLT_NAME from FACULTY";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);



                return Info.Faculty.getFaculties(dtStandards);
              

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static List<Info.Faculty> getFacultyByID(int id)
        {
            try
            {

                string query = "select FCLT_ID, FCLT_NAME from FACULTY where FCLT_ID= "+id+"";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);
                
                return Info.Faculty.getFaculties(dtStandards);


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable getSeesions(int branchId)
        {
            try
            {



                string query = "select * from SESSION";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);



                return dtStandards;


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable getSeesionsById(int instructureID)
        {
            try
            {



                string query = "select * from SESSION where INSTRUCTOR_ID="+instructureID+"";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);



                return dtStandards;


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable getSeesionslist(string branchId, DateTime fromDate, DateTime toDate, int? selectedmembers= 0, int? selectedFaculty= 0)
        {
            try
            {
                com = new SqlCommand("s_pr_get_session_student_list");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate.ToString("yyyy-MM-dd");
                com.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate.ToString("yyyy-MM-dd");
                //  com.Parameters.Add("@student", SqlDbType.Bit).Value = student;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@selectedmembers", SqlDbType.VarChar).Value = selectedmembers;
                com.Parameters.Add("@selectedFaculty", SqlDbType.VarChar).Value = selectedFaculty;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFees = Sqlhelper.GetDatatable(com);

                //DataView dv = new DataView(dtFees);

                //DataTable distinct = dv.ToTable(true, "TRNC_RECEIPT_NO", "FeesPaid", "StudentName",  "FEE_LAST_PAYMENT_DATE");

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    // return Info.FeesCollRpt.getFCollRpt(dtFees);
                    return dtFees;
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
        public static List<Info.Standard> getStandards(int branchId, int streamId)
        {
            try
            {
                

                SqlCommand com = new SqlCommand("s_pr_get_standards");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@StreamId", SqlDbType.VarChar).Value = streamId;
                com.Parameters.Add("@BranchID", SqlDbType.Int).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStandards = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Standard.getStandards(dtStandards);
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
    }
}
