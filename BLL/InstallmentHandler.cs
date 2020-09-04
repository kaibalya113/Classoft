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
    public class InstallmentHandler
    {
        static SqlTransaction objTrans;
        static SqlCommand com;
        public static List<Info.InstallmentDetail> getInstallmentDetails(int feesId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_inst_details");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@feesId", SqlDbType.Int).Value = feesId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtInstdetail = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.InstallmentDetail.getInstallmentDetails(dtInstdetail);
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
        public static bool updateInstDtl(DateTime fromDate,DateTime toDate, int Id, int branchId)
        {
            try
            {
                objTrans = Sqlhelper.getConnection().BeginTransaction();
                com = new SqlCommand("s_pr_update_instDate");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;
                com.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date;
                com.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate.Date;
                com.Parameters.Add("@Stfl_id", SqlDbType.Int).Value = Id;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branchId;
                
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;
              
                Sqlhelper.ExecuteNonQuery(com, true);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    objTrans.Commit();
                    return true;
                }
                else
                {
                    return false;
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
        public static bool insertUpdateFacility(int branch,DateTime oldDate, DateTime newDate, int admissionNo, int facilityId, int packageId)
        {
            try
            {
                com = new SqlCommand("s_pr_insert_facility_update");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@AdmissionNo ", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branch;
                com.Parameters.Add("@OldDate", SqlDbType.Date).Value = oldDate;
                com.Parameters.Add("@NewDate", SqlDbType.Date).Value = newDate;
                com.Parameters.Add("@packageId", SqlDbType.Int).Value = packageId;
                com.Parameters.Add("@facilityId", SqlDbType.Int).Value = facilityId;
                //com.Parameters.Add("@InstructorId", SqlDbType.Int).Value = InstructorId;
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

        public static DataTable getInsdDetails(string branch,Int64 feesId)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_NP_insd_details");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@FeesID", SqlDbType.BigInt).Value = feesId;
                com.Parameters.Add("@Branch_Id", SqlDbType.VarChar).Value = branch;
            
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

              //  Sqlhelper.ExecuteNonQuery(com);
                DataTable dtInstdetail = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {

                    return dtInstdetail;
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
        public static decimal getAmountPaid(Int64 ID)
        {
            try
            {
                com = new SqlCommand("select sum(INSD_AMOUNT_PAID) from INSTALLMENTS_DETAILS where INSD_FACILITY_ID =" + ID);
                com.CommandType = CommandType.Text;
                object dtPaid = Sqlhelper.ExeScaler(com);
                return (dtPaid == DBNull.Value )?0:Convert.ToDecimal(dtPaid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Info.InstallmentDetail> getFacilityInstallments(int facilityId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_facility_inst_details");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@facility_id", SqlDbType.Int).Value = facilityId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtInstdetail = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.InstallmentDetail.getInstallmentDetails(dtInstdetail);
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

        public static void updateFacilityInstallments(StudentFacility facility,Student objStudent)
        {
            try
            {
                decimal newFees = facility.Installments.Sum(inst => inst.InstAmount);
                decimal newDiscount = facility.Installments.Sum(inst => inst.Discount);

                objTrans = Sqlhelper.getConnection().BeginTransaction();

                //Delete all unpaid installments
                com = new SqlCommand();
                com.CommandText = "delete from INSTALLMENTS_DETAILS where insd_facility_id = " + facility.Id + " and insd_amount_paid = 0";
                com.Transaction = objTrans;
                Sqlhelper.ExecuteNonQuery(com, true);

                //Update existing paid installments
                foreach(InstallmentDetail installment in facility.Installments)
                {
                    if(installment.AmntPaid > 0)
                    {
                        com = new SqlCommand();
                        com.CommandText = "update installments_details set INSD_DATE = @date,INSD_INSTMNT_AMT = @amount,INSD_DISCOUNT=@discount,INSD_DESC=@desc where INSD_FACILITY_ID=@facility_id and insd_id = @insd_id";

                        com.Parameters.Add("@date", SqlDbType.Date).Value = installment.InstDate;
                        com.Parameters.Add("@discount", SqlDbType.Decimal).Value = installment.Discount;
                        com.Parameters.Add("@amount", SqlDbType.Decimal).Value = installment.InstAmount;
                        com.Parameters.Add("@desc", SqlDbType.VarChar, 400).Value = installment.Description;
                        com.Parameters.Add("@insd_id", SqlDbType.Int).Value = installment.Id;
                        com.Parameters.Add("@facility_id", SqlDbType.Int).Value = facility.Id;

                        com.Transaction = objTrans;
                        Sqlhelper.ExecuteNonQuery(com, true);
                    }
                }


                //Insert new installments
                com = new SqlCommand("select count(1) from installments_details where INSD_FACILITY_ID = " + facility.Id);
                com.Transaction = objTrans;
                int count =  Convert.ToInt32(Sqlhelper.ExeScaler(com,true));


                com = new SqlCommand();
                com.CommandText = "s_pr_add_instDetails";
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;

                foreach (InstallmentDetail installment in facility.Installments)
                {
                    if (installment.AmntPaid ==  0)
                    {
                        com.Parameters.Clear();
                        com.Parameters.Add("@instMonth", SqlDbType.Int).Value = installment.InstDate.Month;
                        com.Parameters.Add("@instNo", SqlDbType.Int).Value = ++count;
                        com.Parameters.Add("@instDate", SqlDbType.Date).Value = installment.InstDate;
                        com.Parameters.Add("@status", SqlDbType.VarChar).Value = "NP";
                        com.Parameters.Add("@description", SqlDbType.VarChar).Value = installment.Description;
                        com.Parameters.Add("@instAmount", SqlDbType.Decimal).Value = installment.InstAmount;
                        com.Parameters.Add("@instID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        com.Parameters.Add("@feesID", SqlDbType.Int).Value = facility.Student.Fees.FeesId;
                        com.Parameters.Add("@facilityId", SqlDbType.Int).Value = facility.Id;
                        com.Parameters.Add("@discount", SqlDbType.Decimal).Value = installment.Discount;
                        com.Parameters.Add("@standadId", SqlDbType.Int).Value = facility.Package.Standard.Standardid;
                        com.Parameters.Add("@branchId", SqlDbType.Int).Value = facility.Student.Branch.BranchId;
                        com.Parameters.Add("@duration", SqlDbType.Int).Value = installment.Duration;
                        com.Parameters.Add("@reason", SqlDbType.VarChar).Value = "";

                        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        Sqlhelper.ExecuteNonQuery(com, true);

                        if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                        {
                            installment.Id = (int)com.Parameters["@instID"].Value;
                        }
                        else
                        {
                            throw new Common.Exceptions.InvalidReturnCodeException(com);
                        }
                    }
                    
                }
                
                com = new SqlCommand("select isnull(sum(insd_instmnt_amt),0) from installments_details where INSD_FEES_ID = " + facility.Student.Fees.FeesId );
                com.Transaction = objTrans;
                decimal totalFees = Convert.ToDecimal(Sqlhelper.ExeScaler(com, true));

                
                com = new SqlCommand("select isnull(sum(insd_discount),0) from installments_details where INSD_FEES_ID = " + facility.Student.Fees.FeesId);
                com.Transaction = objTrans;
                decimal totalDiscount = Convert.ToDecimal(Sqlhelper.ExeScaler(com, true));


                com = new SqlCommand("select isnull(sum(insd_cncld_amt),0) from installments_details where INSD_FEES_ID = " + facility.Student.Fees.FeesId);
                com.Transaction = objTrans;
                decimal totalCncld = Convert.ToDecimal(Sqlhelper.ExeScaler(com, true));

                //update fees
                com = new SqlCommand();
                com.CommandText = "update fees set fee_total_fees ="+ totalFees+ "  , FEE_TUTION_AMOUNT = " + totalFees + ", fee_discount= "+ totalDiscount + ",fee_cancd_fees ="+ totalCncld + " where fee_admission_no =" + objStudent.AdmisionNo;
                com.Transaction = objTrans;

                Sqlhelper.ExecuteNonQuery(com, true);

                //Update stduent facility amount
                com = new SqlCommand();
                com.CommandText = "update student_facilities set stfl_amount =" + newFees + ", stfl_discount="+ newDiscount + " where stfl_id =" + facility.Id;
                com.Transaction = objTrans;

                Sqlhelper.ExecuteNonQuery(com, true);
                

                objTrans.Commit();


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
    }

}

