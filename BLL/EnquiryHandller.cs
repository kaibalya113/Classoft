using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using ClassManager.Info;
using ClassManager.Common.Exceptions;

namespace ClassManager.BLL
{
    public class EnquiryHandller
    {
        static SqlCommand com;
        static SqlTransaction objTrans;

        public static bool SaveEnquiry(Info.Enquiry objEnquiry)
        {
            try
            {
                com = new SqlCommand("s_pr_create_enquiry");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@FName", SqlDbType.VarChar).Value = objEnquiry.FName;
                com.Parameters.Add("@MName", SqlDbType.VarChar).Value = objEnquiry.MName;
                com.Parameters.Add("@LName", SqlDbType.VarChar).Value = objEnquiry.LName;

                com.Parameters.Add("@Addres", SqlDbType.VarChar).Value = objEnquiry.Addres;
                com.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = objEnquiry.ContactNo;
                com.Parameters.Add("@parentContact", SqlDbType.VarChar).Value = objEnquiry.parentContact;
                com.Parameters.Add("@Subjects", SqlDbType.VarChar).Value = objEnquiry.Subjects;
                com.Parameters.Add("@Field", SqlDbType.VarChar).Value = objEnquiry.Field;
                com.Parameters.Add("@DiscussedFees", SqlDbType.VarChar).Value = objEnquiry.Fees;
                //com.Parameters.Add("@Field", SqlDbType.VarChar).Value = objEnquiry.Field;

                if (objEnquiry.DOB != DateTime.MinValue)
                {
                    com.Parameters.Add("@DOB", SqlDbType.DateTime).Value = objEnquiry.DOB;
                }
                else
                {
                    com.Parameters.Add("@DOB", SqlDbType.DateTime).Value = DBNull.Value;
                }

                com.Parameters.Add("@EnqDate", SqlDbType.DateTime).Value = objEnquiry.EnquiryDate;
                com.Parameters.Add("@ClgName", SqlDbType.VarChar).Value = objEnquiry.ClgName;
                com.Parameters.Add("@LstYerMarks", SqlDbType.VarChar).Value = objEnquiry.LstYerMarks;
                com.Parameters.Add("@StandardId", SqlDbType.Int).Value = objEnquiry.Standard.Standardid;
                com.Parameters.Add("@status", SqlDbType.VarChar).Value = objEnquiry.Status;
                com.Parameters.Add("@Email_ID", SqlDbType.VarChar).Value = objEnquiry.EmailID;


                com.Parameters.Add("@ReferenceBy", SqlDbType.VarChar).Value = objEnquiry.ReferenceBy;

                com.Parameters.Add("@BranchID", SqlDbType.Int).Value = objEnquiry.Branch.BranchId;
                com.Parameters.Add("@Enquiry_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                if (Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME) == Common.Constants.CLASS_APP_TYPE)
                {
                    com.Parameters.Add("@SchoolName", SqlDbType.VarChar).Value = objEnquiry.SchoolName;
                }
                    
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (com.Parameters["@NUM_ERROR_CODE"].Value.ToString().Equals("3"))
                    {

                        objEnquiry.EnquiryID = Convert.ToInt32(com.Parameters["@Enquiry_ID"].Value);
                        objEnquiry.IsRegistered = Convert.ToBoolean(com.Parameters["@IsReg"].Value);
                        //  feesId = Convert.ToInt32(com.Parameters["@feesId"].Value);
                        // ObjStudent.Fees = new Fees(feesId);
                    }
                    objEnquiry.EnquiryID = (int)com.Parameters["@Enquiry_ID"].Value;
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

           

            }
            catch(RecordAlreadyExistsException ex)
            {
                objEnquiry.EnquiryID = Convert.ToInt32(com.Parameters["@Enquiry_ID"].Value);
                objEnquiry.IsRegistered = Convert.ToBoolean(com.Parameters["@IsReg"].Value);
                objEnquiry.EnquiryID = (int)com.Parameters["@Enquiry_ID"].Value;
                return true;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
       

}

        public static bool DeleteEnquiry(Int32 EnqNo, string Name, string Contact, int Branch)
        {

            try
            {

                com = new SqlCommand("s_pr_delete_enquiry");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ENQ_No", SqlDbType.Int).Value = EnqNo;
                com.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                com.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = Contact;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = Branch;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

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

        public static bool deleteTranferTrans(Int64 toaccountId, string branchid, decimal Amount, Int64 tranId, string fromAccount)
        {
            try
            {
                com = new SqlCommand("s_pr_delete_transfer_transaction");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@amount", SqlDbType.Decimal).Value = Amount;
                com.Parameters.Add("@fromAccount", SqlDbType.VarChar).Value = fromAccount;
                com.Parameters.Add("@toAccount", SqlDbType.BigInt).Value = toaccountId;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add("@transID", SqlDbType.BigInt).Value = tranId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

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

        public static Followup getLatestFollowup(int enquiryID)
        {
            try
            {
                com = new SqlCommand("s_pr_get_latest_followupid");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@enquiryId", SqlDbType.Int).Value = enquiryID;
                com.Parameters.Add("@NUM_ERROR_CODE", SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dt.Rows.Count < 0)
                    {
                        return null;
                    }
                    else
                    {
                        return Followup.getFollowUp(dt.Rows[0]);
                    }
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

        public static List<Info.Enquiry> GetEnquries(int enquiryId, String BranchId, bool isRegistered = false)
        {
            try
            {

                List<Info.Enquiry> enquiries = new List<Info.Enquiry>();

                com = new SqlCommand("s_pr_get_enquiries");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = BranchId;
                com.Parameters.Add("@enquiry_id", SqlDbType.VarChar).Value = (enquiryId == -1) ? "%" : enquiryId.ToString();
                com.Parameters.Add("@isRegistered", SqlDbType.Bit).Value = isRegistered;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtEnquries = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    enquiries = Info.Enquiry.getEnquiries(dtEnquries);
                    return enquiries;
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
        public static DataTable GetAllEnquries(string branchId, int EnquiryStatus, DateTime? FromDate = null, DateTime? ToDate = null)
        {
            try
            {
                if (ToDate == null || FromDate == null)
                {
                    //FromDate = DateTime.MinValue;
                    FromDate = new DateTime(1753, 1, 1);
                    ToDate = DateTime.MaxValue;
                }
                com = new SqlCommand("s_pr_disp_enquiries");
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@EnquiryStatus", SqlDbType.Int).Value = EnquiryStatus;
                com.Parameters.Add("@Fromdate", SqlDbType.DateTime).Value = FromDate;
                com.Parameters.Add("@Todate", SqlDbType.DateTime).Value = ToDate;
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtEnquries = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtEnquries;
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


        public static DataTable GetEnquiryStatusCount(string branchId)
        {
            try
            {
               
                com = new SqlCommand("s_pr_disp_Enquiry_Status");
                com.Parameters.Add("@Branch_Id", SqlDbType.VarChar).Value = branchId;
              
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtEnquries = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtEnquries;
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


        public static DataTable CourseWiseEnquiry(string branchId, string IsReg)
        {
            try
            {

                com = new SqlCommand("s_pr_disp_CourseWise_Enquiry");
                com.Parameters.Add("@Branch_Id", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@Reg", SqlDbType.VarChar).Value = IsReg;
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtEnquries = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtEnquries;
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
        public static bool UpdateStatus(Info.Enquiry objenq, string branch)
        {
            try
            {

                objTrans = Sqlhelper.getConnection().BeginTransaction();
                com = new SqlCommand("s_pr_update_Enquiries");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;
                com.Parameters.Add("@Address", SqlDbType.VarChar).Value = objenq.Addres;
                com.Parameters.Add("@contact ", SqlDbType.VarChar).Value = objenq.ContactNo;
                com.Parameters.Add("@RefferedBy", SqlDbType.VarChar).Value = objenq.ReferenceBy;
                com.Parameters.Add("@Dob", SqlDbType.DateTime).Value = objenq.DOB;
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = objenq.EmailID;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branch;
                com.Parameters.Add("@EnqStatus", SqlDbType.VarChar).Value = objenq.Status;
                com.Parameters.Add("@EnquiryId", SqlDbType.Int).Value = objenq.EnquiryID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com, true);

                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    objTrans.Commit();
                    return true;
                }
                else
                {
                    //Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }


            }
            catch (Exception ex)
            {

                if (objTrans != null)
                {
                    objTrans.Rollback();
                }

                objTrans = null;
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static DataSet getEnquiry(string enquiryID)
        {
            try
            {
                com = new SqlCommand("s_pr_get_enquiry");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Enquiryid", SqlDbType.VarChar).Value = enquiryID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                DataSet dtEnquiry = Sqlhelper.GetDataset(com);

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
                throw;
            }
        }

        public static bool updateEnquiry(Enquiry objEnqUpdate)
        {
            try
            {
                com = new SqlCommand("s_pr_update_enquiry");
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.Add("@FName", SqlDbType.VarChar).Value = objEnqUpdate.FName;
                com.Parameters.Add("@MName", SqlDbType.VarChar).Value = objEnqUpdate.MName;
                com.Parameters.Add("@LName", SqlDbType.VarChar).Value = objEnqUpdate.LName;
                com.Parameters.Add("@Addres", SqlDbType.VarChar).Value = objEnqUpdate.Addres;
                com.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = objEnqUpdate.ContactNo;
                com.Parameters.Add("@parentContact", SqlDbType.VarChar).Value = objEnqUpdate.parentContact;
                com.Parameters.Add("@motherContact", SqlDbType.VarChar).Value = objEnqUpdate.motherContact;
                com.Parameters.Add("@Subjects", SqlDbType.VarChar).Value = objEnqUpdate.Subjects;
                com.Parameters.Add("@Field", SqlDbType.VarChar).Value = objEnqUpdate.Qualification;
                com.Parameters.Add("@DiscussedFees", SqlDbType.VarChar).Value = objEnqUpdate.Fees;
                com.Parameters.Add("@batch", SqlDbType.VarChar).Value = objEnqUpdate.Batch.id;
                com.Parameters.Add("@Counselor", SqlDbType.VarChar).Value = objEnqUpdate.Field;

                if (objEnqUpdate.DOB != DateTime.MinValue)
                {
                    com.Parameters.Add("@DOB", SqlDbType.DateTime).Value = objEnqUpdate.DOB;
                }
                else
                {
                    com.Parameters.Add("@DOB", SqlDbType.DateTime).Value = DBNull.Value;
                }

                com.Parameters.Add("@EnqDate", SqlDbType.DateTime).Value = objEnqUpdate.EnquiryDate;
                com.Parameters.Add("@ClgName", SqlDbType.VarChar).Value = objEnqUpdate.ClgName;
                com.Parameters.Add("@LstYerMarks", SqlDbType.VarChar).Value = objEnqUpdate.LstYerMarks;
                com.Parameters.Add("@StandardId", SqlDbType.Int).Value = objEnqUpdate.Standard.Standardid;
                com.Parameters.Add("@status", SqlDbType.VarChar).Value = objEnqUpdate.Status;
                com.Parameters.Add("@Email_ID", SqlDbType.VarChar).Value = objEnqUpdate.EmailID;


                com.Parameters.Add("@ReferenceBy", SqlDbType.VarChar).Value = objEnqUpdate.ReferenceBy;

                com.Parameters.Add("@BranchID", SqlDbType.Int).Value = objEnqUpdate.Branch.BranchId;
                com.Parameters.Add("@Enquiry_ID", SqlDbType.Int).Value = objEnqUpdate.EnquiryID;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    //objEnqUpdate.EnquiryID = (int)com.Parameters["@Enquiry_ID"].Value;
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

