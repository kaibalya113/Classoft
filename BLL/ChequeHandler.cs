using ClassManager.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClassManager.Info;

namespace ClassManager.BLL
{
  public class ChequeHandler
    {
        static SqlCommand objcom;


        public static DataTable getAllCheques(int branchid, DateTime from=default(DateTime), DateTime? to=null)
        {
            try
            {
                objcom = new SqlCommand("s_pr_disp_all_cheques");
                if (to == null)
                {
                    to = DateTime.MaxValue;
                }

                objcom.CommandType = CommandType.StoredProcedure;
                objcom.Parameters.Add("@branchid", SqlDbType.Int).Value = branchid;
                objcom.Parameters.Add("@from", SqlDbType.Date).Value = from;
                objcom.Parameters.Add("@to", SqlDbType.Date).Value = to;

                objcom.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtCheques = Sqlhelper.GetDatatable(objcom);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objcom))
                {
                    return dtCheques;
                }
                else
                { 
                    throw new Common.Exceptions.InvalidReturnCodeException(objcom);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static bool UpdateCheque(Info.Cheque objcheque)
        {
            try
            {
                objcom = new SqlCommand("s_pr_Update_Cheque");
                objcom.CommandType = CommandType.StoredProcedure;

                //branchid should also be there
                objcom.Parameters.Add("@branchid", SqlDbType.Int).Value = objcheque.BranchID;

                objcom.Parameters.Add("@status", SqlDbType.VarChar).Value = objcheque.Status.ToString();
                objcom.Parameters.Add("@BankName", SqlDbType.VarChar).Value = objcheque.Bank;
                objcom.Parameters.Add("@BankBranch", SqlDbType.VarChar).Value = objcheque.BankBranch;
                objcom.Parameters.Add("@ChequeNo", SqlDbType.VarChar).Value = objcheque.ChequeNo;
                objcom.Parameters.Add("@ChequeDate", SqlDbType.Date).Value = objcheque.Date;
                objcom.Parameters.Add("@ChequeAmount", SqlDbType.VarChar).Value = objcheque.Amount;
                objcom.Parameters.Add("@BounceCharges", SqlDbType.VarChar).Value = objcheque.BounceCharges;
                objcom.Parameters.Add("@DepositAccount", SqlDbType.Int).Value = objcheque.DepositAccount.Id;
               
                objcom.Parameters.Add("@chequeId", SqlDbType.Int).Value = objcheque.Id;
                
                objcom.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteQuery(objcom);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objcom))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objcom);
                }


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool Insert(Info.Cheque objCheque)
        {
            try
            {
               objcom = new SqlCommand("s_pr_insert_cheque");
                objcom.CommandType = CommandType.StoredProcedure;

                //branchid should also be there
             //   objcom.Parameters.Add("@branchid", SqlDbType.Int).Value = objCheque.BranchID;

                objcom.Parameters.Add("@status", SqlDbType.VarChar).Value = "PDC";
                objcom.Parameters.Add("@BankName", SqlDbType.VarChar).Value = objCheque.Bank;
                objcom.Parameters.Add("@BankBranch", SqlDbType.VarChar).Value = objCheque.BankBranch;
                objcom.Parameters.Add("@ChequeNo", SqlDbType.VarChar).Value = objCheque.ChequeNo;
                objcom.Parameters.Add("@ChequeDate", SqlDbType.Date).Value = objCheque.Date;
                objcom.Parameters.Add("@ChequeAmount", SqlDbType.Decimal).Value = objCheque.Amount;
                objcom.Parameters.Add("@Branchid", SqlDbType.Int).Value = BLL.UserHandler.loggedInUser.BranchId;
                objcom.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = objCheque.Student.AdmissionNo;
                objcom.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteQuery(objcom);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objcom))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objcom);
                }


            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool UpdateChequeStatus(int chequeID)
        {
            try
            {
                objcom = new SqlCommand("s_pr_clear_cheque_status");
                objcom.CommandType = CommandType.StoredProcedure;

                objcom.Parameters.Add("@ChequeID", SqlDbType.Int).Value = chequeID;

                objcom.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(objcom);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objcom))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objcom);
                }



            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static Info.Cheque getCheque(int chequeID)
        {
            try
            {
                objcom = new SqlCommand("s_pr_get_cheque");
                objcom.CommandType = CommandType.StoredProcedure;
                objcom.Parameters.Add("@chequeID", SqlDbType.Int).Value = chequeID;
                objcom.Parameters.Add("@NUM_ERROR_CODE", SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(objcom);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objcom))
                {
                    return Info.Cheque.getCheque(dt.Rows[0]);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        internal static void sendChequeDueSMS(DateTime date, int branchid)
        {
            try
            {
                bool sendChequeDueSMS = Info.SysParam.getValue<Boolean>(SysParam.Parameters.SEND_CHEQUE_DUE);

                if (sendChequeDueSMS)
                {
                    string smsTemplate;
                    Dictionary<string, string> smsData = new Dictionary<string, string>();

                    //Get sms config
                    Info.SmsConfig smsConfig = Info.SmsConfig.getSMSConfig();

                    //get template
                    smsTemplate = Template.getValue<string>(Info.TemplateType.CHEQUESMS);

                    List<Cheque> dueCheques = getDueCheques(date, branchid.ToString());

                    //Traversing each cheque
                    foreach (Cheque objCheque in dueCheques)
                    {
                        //SMS content
                        StringBuilder smsBody = new StringBuilder(smsTemplate.ToString());

                        smsBody.Replace(":CHEQUE_NO", objCheque.ChequeNo);
                        smsBody.Replace(":AMOUNT", Common.Formatter.FormatCurrency(objCheque.Amount));
                        smsBody.Replace(":CNAME", Info.SysParam.getValue<String>(SysParam.Parameters.NAME));
                        smsBody.Replace(":CONTACT_NO", Info.SysParam.getValue<String>(SysParam.Parameters.CONTACT_NO));

                        smsData.Add(objCheque.Student.FatherContactNo,smsBody.ToString());
                    }
                    MailHandler.sendSMS(smsConfig, smsData,false,"ChequeSMS");
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        private static List<Cheque> getDueCheques(DateTime date, string branchid)
        {
            try
            {
                try
                {
                    objcom = new SqlCommand("s_pr_get_due_cheque");
                    objcom.CommandType = CommandType.StoredProcedure;
                    objcom.Parameters.Add("@cheque_date", SqlDbType.Date).Value = date;
                    objcom.Parameters.Add("@branch_id", SqlDbType.VarChar).Value = (branchid == "-1") ? "%" : branchid.ToString();
                    objcom.Parameters.Add("@NUM_ERROR_CODE", SqlDbType.Int).Direction = ParameterDirection.Output;

                    DataTable dt = Sqlhelper.GetDatatable(objcom);
                    if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objcom))
                    {
                        return Info.Cheque.getCheques(dt);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static List<Cheque> getPDC(int admisionNo)
        {

            try
            {
                try
                {
                    objcom = new SqlCommand("s_pr_get_pdc_cheque");
                    objcom.CommandType = CommandType.StoredProcedure;
                    objcom.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = admisionNo;
                   
                    objcom.Parameters.Add("@NUM_ERROR_CODE", SqlDbType.Int).Direction = ParameterDirection.Output;

                    DataTable dt = Sqlhelper.GetDatatable(objcom);
                    if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objcom))
                    {
                        return Info.Cheque.getCheques(dt);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                    throw ex;
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
