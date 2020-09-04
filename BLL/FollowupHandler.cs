using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClassManager.DAL;

namespace ClassManager.BLL
{
    public class FollowupHandler
    {
        static SqlCommand com;

        public static bool SaveFollowup(Info.Followup objFollowp,string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_create_followup");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branch_id", SqlDbType.VarChar).Value = UserHandler.loggedInUser.BranchId;
                com.Parameters.Add("@ReferenceId", SqlDbType.VarChar).Value = objFollowp.ReferenceID;
                com.Parameters.Add("@FollowupType", SqlDbType.VarChar).Value = objFollowp.FollowupType;
                com.Parameters.Add("@FollowupDate", SqlDbType.Date).Value = objFollowp.FollowupDate;
                com.Parameters.Add("@FollowupDesc", SqlDbType.VarChar).Value = objFollowp.FollowupDesc;
                com.Parameters.Add("@FollowupMediam", SqlDbType.VarChar).Value = objFollowp.FollowupMediam;
                com.Parameters.Add("@FollowupBy", SqlDbType.VarChar).Value = objFollowp.FollowupBy;
                // com.Parameters.Add("@FollowupBranchId", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@FollowupID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                    //objFollowp.FollowupID = (int)com.Parameters["@FollowupID"].Value;
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

        public static bool saveAnyFollowup(Info.Followup objFollowp, int branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_create_followup");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branch_id", SqlDbType.Int).Value = UserHandler.loggedInUser.BranchId;
                com.Parameters.Add("@ReferenceId", SqlDbType.VarChar).Value = objFollowp.ReferenceID;
                com.Parameters.Add("@FollowupType", SqlDbType.VarChar).Value = objFollowp.FollowupType;
                com.Parameters.Add("@FollowupDate", SqlDbType.Date).Value = objFollowp.FollowupDate;
                com.Parameters.Add("@FollowupDesc", SqlDbType.VarChar).Value = objFollowp.FollowupDesc;
                com.Parameters.Add("@isFollowofAnybit", SqlDbType.Bit).Value = true;
                com.Parameters.Add("@FollowupMediam", SqlDbType.VarChar).Value = objFollowp.FollowupMediam;
                com.Parameters.Add("@FollowupBy", SqlDbType.VarChar).Value = objFollowp.FollowupBy;
                com.Parameters.Add("@FollowupID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                    //objFollowp.FollowupID = (int)com.Parameters["@FollowupID"].Value;
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


        public static DataTable getFollowUpsOnLoad(string branchID)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_follow_up_on_load");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable result= Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return result;
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




        public static List<Info.Followup> getFollowup(string branchId, string refID)
        {
            try
            {
                List<Info.Followup> followups = new List<Info.Followup>();

                com = new SqlCommand("s_pr_get_enquiry_followUp");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@ReferenceID", SqlDbType.VarChar).Value = refID;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtFollwp = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    followups = Info.Followup.getFollowups(dtFollwp);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
                return followups;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable getFollowUpDetails(string branchID,DateTime FromDate,DateTime Todate,int identifire)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_followup_details");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add("@FromDate", SqlDbType.DateTime).Value =FromDate;
                com.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Todate;
                com.Parameters.Add("@identifire", SqlDbType.Int).Value =identifire;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable result = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return result;
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




        public static List<Info.Enquiry> getFollowups(DateTime date, string BranchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_followups");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = BranchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtEnquiries = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.Enquiry.getEnquiries(dtEnquiries);
                   // return dtEnquiries;
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
        public static DataTable getFollStud(DateTime date, string BranchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_folowupStud");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = BranchId == "-1" ? "%": BranchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtEnquiry = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtEnquiry;
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
        public static DataTable getAllFollStudent(DateTime Fromdate,DateTime Todate, string BranchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_All_folowupStud");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Fromdate", SqlDbType.Date).Value = Fromdate ;
                com.Parameters.Add("@Todate", SqlDbType.Date).Value = Todate;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value =BranchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtEnquiry = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtEnquiry;
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
        public static DataTable getFolloupReport(string BranchId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_followups_report");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = BranchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtEnquiries = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtEnquiries;
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


        public static DataTable getFolloups(string BranchId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_followups");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = BranchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtEnquiries = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtEnquiries;
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

        public static DataTable getFollowupAny(int admissionNo, string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Followp_of_any");
                com.CommandType = CommandType.StoredProcedure;
              
                com.Parameters.Add("@admissionNo", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
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


        public static DataTable getFollowupdue( DateTime todate, int identifier, DateTime FromDate)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_OutstandingDue_followup");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@identifire", SqlDbType.Int).Value =identifier;
                com.Parameters.Add("@ToDate", SqlDbType.DateTime).Value =todate.ToString("yyyy-MM-dd");
                com.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate.ToString("yyyy-MM-dd");
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
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





        public static DataTable getFollowupofoutstanding(int admissionNo, string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Followp_of_outstanding");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@admissionNo", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
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



        public static DataTable getFollowupofFees(int admissionNo, string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Followp_of_Fees");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@admissionNo", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
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


        public static DataTable viewFollowUp(int EnquiryId)
        {
            try
            {
                com = new SqlCommand("s_pr_view_followup");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Enq_ID", SqlDbType.Int).Value = EnquiryId;
               

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
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

        public static bool updateFollowStatus(int followupID, string status)
        {
            try
            {
                com = new SqlCommand("s_pr_update_followup_status");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@followupId", SqlDbType.Int).Value = followupID;
                com.Parameters.Add("@status", SqlDbType.VarChar).Value = status;

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

        public static bool updateFollowStatusForDue(int followupID, string status)//added by ashvini on 25-04-2019
        {
            try
            {
                com = new SqlCommand("s_pr_update_followup_status_For_Due");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@followupId", SqlDbType.Int).Value = followupID;
                com.Parameters.Add("@status", SqlDbType.VarChar).Value = status;

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
        public static DataTable CountOfFollowUp(string branch)
        {
            try
            {
                com = new SqlCommand("s_pr_count_followup");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branch;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
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
