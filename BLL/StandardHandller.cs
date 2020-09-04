using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using ClassManager.Info;

namespace ClassManager.BLL
{
    public class StandardHandller
    {
        public static bool addStandard(Info.Standard objStandard)
        {
            try
            {
                //         ALTER PROCEDURE dbo.s_pr_create_standard
                //(
                //    @SubjectList varchar(max), 
                //    @Stream varchar(20), 
                //    @Standard varchar(20),
                //    @Standard_ID int output ,
                //    @NUM_ERROR_CODE int output 
                //)	


                SqlCommand com = new SqlCommand("s_pr_create_standard");
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@SubjectList", SqlDbType.VarChar).Value = objStandard.SubjectList;
                com.Parameters.Add("@Stream", SqlDbType.VarChar).Value = objStandard.Stream.Name;
                com.Parameters.Add("@Standard", SqlDbType.VarChar).Value = objStandard.StandardName;

                com.Parameters.Add("@Standard_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@Stream_Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@DurationInMonths", SqlDbType.Int).Value = objStandard.DurationInMonths;

                com.Parameters.Add("@BranchID", SqlDbType.Int).Value = objStandard.Branch.BranchId;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    objStandard.Standardid = (int)com.Parameters["@Standard_ID"].Value;
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

        public static bool removeStandard(int StandardID, int branchID)
        {
            //        ALTER PROCEDURE dbo.s_pr_del_standard
            //(   
            //    @Standard_ID int output ,
            //    @NUM_ERROR_CODE int output 
            //)

            try
            {

                SqlCommand com = new SqlCommand("s_pr_del_standard");
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = StandardID;
                com.Parameters.Add("@Standard_ID", SqlDbType.VarChar).Value = StandardID;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchID;
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

        public static DataTable getSchoolName()
        {
            try
            {

                //string query = "select * from school_master";
                string query = "select * from school_master where SCH_NAME != 'null' and SCH_NAME !=' '";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);



                return dtStandards;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static List<Info.Standard> getStandard(string branchId, string stream = "%")
        {
            try
            {


                SqlCommand com = new SqlCommand("s_pr_get_standards");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@StreamId", SqlDbType.VarChar).Value = stream;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;
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


        public static int getStandardID(int fac, int branch)
        {
            try
            {


                SqlCommand com = new SqlCommand("s_pr_get_standard_id");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branch;
                com.Parameters.Add("@stud_faciltyID", SqlDbType.Int).Value = fac;
                com.Parameters.Add("@std_ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);
                int id = (int)(com.Parameters["@std_ID"].Value);
                return id;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }



        public static Info.Standard getStandard(int standardId, int branchId)
        {
            try
            {



                SqlCommand com = new SqlCommand("s_pr_get_standard");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@standard_id", SqlDbType.Int).Value = standardId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStandards = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Standard.getStandard(dtStandards.Rows[0]);
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

        public static DataTable GetCollegeName(string collegeName = "%")
        {

            try
            {


                SqlCommand com = new SqlCommand("s_pr_get_colleges");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@collegeName", SqlDbType.VarChar).Value = collegeName;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtColleges = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtColleges;
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


        public static bool addCollege(string clgName, string clgStandards)
        {
            //s_pr_add_clg

            //@clgName varchar,
            //@clgStandards varchar,
            //@NUM_ERROR_CODE INT OUTput


            try
            {

                SqlCommand com = new SqlCommand("s_pr_add_clg");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@clgName", SqlDbType.VarChar).Value = clgName;
                com.Parameters.Add("@clgStandards", SqlDbType.VarChar).Value = clgStandards;
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

        public static SubjectMaster getSubject(int? subjectId, string branchid)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_subject");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@subjectId", SqlDbType.VarChar).Value = subjectId;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtSubject = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return SubjectMaster.getSubject(dtSubject);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<Info.Batch> GetBatches(int? standardId = null, int? branchId = null)
        {
            try
            {

                SqlCommand com = new SqlCommand("s_pr_get_batches");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@standard_id", SqlDbType.VarChar).Value = standardId;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtBatches = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Batch.GetBatches(dtBatches);
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

        public static int updateSubject(SubjectMaster objSub, int subjId)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_update_subject");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@subName", SqlDbType.VarChar).Value = objSub.SubjName;
                com.Parameters.Add("@stdId", SqlDbType.Int).Value = objSub.Standard.Standardid;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = objSub.BranchID;
                com.Parameters.Add("@subjId", SqlDbType.Int).Value = subjId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                return subjId;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }
        }

        public static bool addBatch(Info.Batch objBatch)
        {
            try
            {

                SqlCommand com = new SqlCommand("s_pr_create_Batch");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Standard_ID", SqlDbType.Int).Value = objBatch.StandardID;
                com.Parameters.Add("@BatchID", SqlDbType.VarChar).Value = objBatch.Name;
                com.Parameters.Add("@location", SqlDbType.VarChar).Value = objBatch.location;
                com.Parameters.Add("@StartDate", SqlDbType.Date).Value = objBatch.StartDate;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = objBatch.Branch.BranchId;
                com.Parameters.Add("@MinPercent", SqlDbType.Int).Value = objBatch.minPercent;
                if (objBatch.FromTime == null)
                {
                    com.Parameters.Add("@fromTime", SqlDbType.Time).Value = null;
                }
                else
                {
                    com.Parameters.Add("@fromTime", SqlDbType.Time).Value = objBatch.FromTime.Value.TimeOfDay;
                }

                if (objBatch.FromTime == null)
                {
                    com.Parameters.Add("@toTime", SqlDbType.Time).Value = null;
                }
                else
                {
                    com.Parameters.Add("@toTime", SqlDbType.Time).Value = objBatch.ToTime.Value.TimeOfDay;
                }

                com.Parameters.Add("@batch_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    objBatch.id = Convert.ToInt32(com.Parameters["@batch_id"].Value);
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


        public static bool removeBatch(Info.Batch objBatch)
        {
            try
            {
                //         ALTER PROCEDURE dbo.s_pr_delete_Batch
                //(		
                //    @BatchID varchar(20),
                //    @NUM_ERROR_CODE int output 
                //)	


                SqlCommand com = new SqlCommand("s_pr_delete_Batch");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = objBatch.Branch.BranchId;
                com.Parameters.Add("@BatchID", SqlDbType.VarChar).Value = objBatch.id;
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


        public static int createSubject(Info.SubjectMaster objSub)
        {
            try
            {


                SqlCommand com = new SqlCommand("s_pr_create_subject");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@subName", SqlDbType.VarChar).Value = objSub.SubjName;
                com.Parameters.Add("@stdId", SqlDbType.Int).Value = objSub.Standard.Standardid;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = objSub.BranchID;
                com.Parameters.Add("@subjId", SqlDbType.Int).Direction = ParameterDirection.Output;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                return objSub.SubjId = (int)com.Parameters["@subjId"].Value;


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static List<Info.TestSubject> getSubjectList(int branchid, int stdID = '%')
        {
            try
            {

                SqlCommand com = new SqlCommand("s_pr_get_subjects");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@stdId", SqlDbType.Int).Value = stdID;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchid;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtSubjects = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.TestSubject.getSubjects(dtSubjects);
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

        public static void DeleteSubject(int subjID, int branchID)
        {
            try
            {
                String query = "delete from SUBJECT_FACULTY where SUBF_SUBJET_ID ='" + subjID + "' and SUBF_BRANCH_ID='" + branchID + "';";
                query += "delete from SUBJECT_MASTER where SUBM_ID ='" + subjID + "' and SUBM_BRANCH_ID='" + branchID + "'";

                SqlCommand com = new SqlCommand(query);
                com.CommandType = CommandType.Text;
                Sqlhelper.ExecuteNonQuery(com);

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static List<Info.Faculty> getFacultiesBySubject(int subjId, string branchID)
        {
            try
            {

                SqlCommand com = new SqlCommand("s_pr_get_faculties_for_subject");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@subjId", SqlDbType.Int).Value = subjId;
                com.Parameters.Add("@branchID", SqlDbType.Int).Value = branchID;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFaculty = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Faculty.getFaculties(dtFaculty);
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
        public static bool addSubjectFaculty(int subjID, int facultyID, int branchId)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_add_subject_faculty");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@subjID", SqlDbType.Int).Value = subjID;
                com.Parameters.Add("@facultyID", SqlDbType.Int).Value = facultyID;
                com.Parameters.Add("@BRANCH_ID", SqlDbType.Int).Value = branchId;
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
    }
}
