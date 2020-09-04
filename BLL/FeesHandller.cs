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
    public class FeesHandller
    {
        public static List<InstallmentDetail> existingpackage = new List<InstallmentDetail>();
        string sCaption = "FeesPayment";
        static SqlCommand com;
        static SqlTransaction objTrans;
        //private static Info.InstallmentDetails objInstDetails;
        public static bool PayBookingAmount(Info.Fees objFees)
        {
            try
            {
                com = new SqlCommand("s_pr_pay_booking_amnt");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BookingAmount", SqlDbType.Decimal).Value = objFees.BookingAmount;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = objFees.AdmissionNo;
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


        public static bool PayFees(Info.Fees objFees, Info.Transaction objTransaction, int branchId)
        {
            try
            {
                objTrans = Sqlhelper.getConnection().BeginTransaction();
                com = new SqlCommand("s_pr_pay_fees");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;

                com.Parameters.Add("@BookingAmount", SqlDbType.Decimal).Value = objFees.BookingAmount;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = objFees.AdmissionNo;
                com.Parameters.Add("@fees_paid", SqlDbType.Decimal).Value = objFees.FeesPaid;
                com.Parameters.Add("@Fine", SqlDbType.Decimal).Value = objTransaction.Fine;
                com.Parameters.Add("@ServiceTaxPercentage", SqlDbType.Decimal).Value = objTransaction.ServiceTaxPercentage;
                com.Parameters.Add("@ServiceTax", SqlDbType.Decimal).Value = objTransaction.ServiceTax;
                com.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = objTransaction.PaymentDate;
                com.Parameters.Add("@ReceivedBy", SqlDbType.VarChar).Value = objTransaction.ReceivedBy;
                com.Parameters.Add("@amountPaid", SqlDbType.Decimal).Value = objTransaction.Amount;
                com.Parameters.Add("@CashDepositAccount", SqlDbType.Int).Value = objTransaction.CashAccount.Id;
                com.Parameters.Add("@ChequeAmount", SqlDbType.Decimal).Value = objFees.FeesPaid - objFees.CashAmnt - objFees.TransferAmount;
                com.Parameters.Add("@CashAmount", SqlDbType.Decimal).Value = objFees.CashAmnt;
                com.Parameters.Add("@UnclearedAmount", SqlDbType.Decimal).Value = objFees.PndgChqAmnt;
                com.Parameters.Add("@TransferAmount", SqlDbType.Decimal).Value = objFees.TransferAmount;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@Discount", SqlDbType.Decimal).Value = objFees.FeesDiscount;
                com.Parameters.Add("@ImportreceiptNo", SqlDbType.VarChar).Value = objTransaction.ReceiptNo;
                com.Parameters.Add("@Mode", SqlDbType.VarChar).Value = objTransaction.PaymentMode;
                com.Parameters.Add("@USER_ID", SqlDbType.VarChar).Value = objTransaction.ReceivedBy;
                com.Parameters.Add("@MonthPaidStatus", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                com.Parameters.Add("@TransactionID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@ReceiptNo", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.Parameters.Add("@facilityIdToPay", SqlDbType.Int).Value = (objTransaction.PaymentPackage != null) ? objTransaction.PaymentPackage.Id: -1;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com, true);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {

                    objTransaction.TrancID = Convert.ToInt32(com.Parameters["@TransactionID"].Value);
                    objTransaction.ReceiptNo = com.Parameters["@ReceiptNo"].Value.ToString();
                    objFees.InstallmetPaymentStatus = com.Parameters["@MonthPaidStatus"].Value;



                    com = new SqlCommand("s_pr_insert_cheque");
                    com.CommandType = CommandType.StoredProcedure;
                    foreach (Cheque objCheque in objTransaction.Cheques)
                    {
                        com.Transaction = objTrans;
                        com.Parameters.Clear();
                        com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = objFees.AdmissionNo;
                        com.Parameters.Add("@CHEQUE_DATE", SqlDbType.Date).Value = objCheque.Date;
                        com.Parameters.Add("@CHEQUE_DEPOSIT_ACC", SqlDbType.Int).Value = objCheque.DepositAccount.Id;
                        com.Parameters.Add("@CHEQUE_BRANK", SqlDbType.NVarChar).Value = objCheque.Bank;
                        com.Parameters.Add("@CHEQUE_No", SqlDbType.NVarChar).Value = objCheque.ChequeNo;
                        com.Parameters.Add("@CHEQUE_BRANK_BRANCH", SqlDbType.NVarChar).Value = objCheque.BankBranch;
                        com.Parameters.Add("@CHEQUE_AMOUNT", SqlDbType.Decimal).Value = objCheque.Amount;
                        com.Parameters.Add("@CHEQUE_STATUS", SqlDbType.VarChar).Value = objCheque.Status.ToString();
                        com.Parameters.Add("@CHEQUE_TRANC_ID", SqlDbType.Int).Value = objTransaction.TrancID;
                        com.Parameters.Add("@CHEQUE_BRANCH_ID", SqlDbType.Int).Value = branchId;

                        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                        Sqlhelper.ExecuteNonQuery(com, true);

                        if (Common.Exceptions.ExceptionHandller.HandleDBError(com) == false)
                        {
                            throw new Common.Exceptions.InvalidReturnCodeException(com);
                        }
                    }

                    com = new SqlCommand("s_pr_insert_paymentdetails");
                    com.CommandType = CommandType.StoredProcedure;
                    foreach (PaymentDetails objDetails in objTransaction.BankTransfer)
                    {
                        com.Transaction = objTrans;
                        com.Parameters.Clear();
                        com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = objFees.AdmissionNo;
                        com.Parameters.Add("@PAYMENT_AMOUNT", SqlDbType.Decimal).Value = objDetails.Amount;
                        com.Parameters.Add("@PAYMENT_DATE", SqlDbType.Date).Value = objDetails.PaymentDate.Date;
                        com.Parameters.Add("@PAYMENT_FROM", SqlDbType.NVarChar).Value = objDetails.FromAcc;
                        com.Parameters.Add("@PAYMENT_TO", SqlDbType.Int).Value = objDetails.DepositAccount.Id;
                        com.Parameters.Add("@PAYMENT_TRNC_ID", SqlDbType.Int).Value = objTransaction.TrancID;
                        com.Parameters.Add("@PAYMENT_REF_NO", SqlDbType.VarChar).Value = objDetails.ReferenceNo;
                        // com.Parameters.Add("@PAYMENT_DETAILS", SqlDbType.VarChar).Value = (objDetails.Details.ToString() == null) ? "" : objDetails.Details.ToString();
                        com.Parameters.Add("@PAYMENT_TYPE", SqlDbType.VarChar).Value = objDetails.Type.ToString();
                        com.Parameters.Add("@PAYMENT_BRANCH_ID", SqlDbType.Int).Value = branchId;

                        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                        Sqlhelper.ExecuteNonQuery(com, true);

                        if (Common.Exceptions.ExceptionHandller.HandleDBError(com) == false)
                        {
                            throw new Common.Exceptions.InvalidReturnCodeException(com);
                        }
                    }

                    objTrans.Commit();
                    return true;
                }
                else
                {
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
                throw ex;
            }
        }

        public static bool InsertInvoice(int branchId, Info.Reporting.FeeReceiptReportData objFeeData, string ID = null)
        {
            try
            {
                objTrans = Sqlhelper.getConnection().BeginTransaction();

                com = new SqlCommand("s_pr_insert_invoice");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;

                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = (objFeeData.AdmsnNo);
                com.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(objFeeData.PackageAmount);
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = objFeeData.StudentName;
                com.Parameters.Add("@SAC_Code", SqlDbType.VarChar).Value = objFeeData.SACCode;
                com.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = objFeeData.PaymentDate.Date;
                com.Parameters.Add("@CGST", SqlDbType.Decimal).Value = Convert.ToDecimal(objFeeData.CGST);
                com.Parameters.Add("@SGST", SqlDbType.Decimal).Value = Convert.ToDecimal(objFeeData.CGST);
                com.Parameters.Add("@TotalTax", SqlDbType.Decimal).Value = Convert.ToDecimal(Convert.ToDecimal(objFeeData.CGST) + Convert.ToDecimal(objFeeData.CGST));
                com.Parameters.Add("@Quantity", SqlDbType.Int).Value = 1;
                com.Parameters.Add("@PackageAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(objFeeData.PackageAmount);
                com.Parameters.Add("@PaidAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(objFeeData.AmountPaid);
                com.Parameters.Add("@ActualAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(objFeeData.NonTaxAmount);
                com.Parameters.Add("@outstanding", SqlDbType.Decimal).Value = Convert.ToDecimal(objFeeData.OutstandingAmount);
                com.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = objFeeData.ReceiptNo.ToString();
                com.Parameters.Add("@packageName", SqlDbType.VarChar).Value = objFeeData.PackageName.ToString();
                com.Parameters.Add("@Discount", SqlDbType.Decimal).Value = objFeeData.DisCount.ToString();
                com.Parameters.Add("@stflID", SqlDbType.VarChar).Value = ID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com, true);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    //  Sqlhelper.ExecuteNonQuery(com, true);
                    objTrans.Commit();
                    return true;
                }
                else
                {
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
                throw ex;
            }
        }

        public static object getFeesCollectiondemo(int index)
        {
            return index;
        }



        public static DataSet checkInvoice(int branchId, string ID)
        {
            try
            {
                com = new SqlCommand("s_pr_check_invoice");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@stflId", SqlDbType.VarChar).Value = ID;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                DataSet dt = Sqlhelper.GetDataset(com);

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
                throw;
            }

        }

        public static Info.Fees GetFeesDetails(int AdmissionNo)
        {
            try
            {
                Info.Fees ObjFees = new Info.Fees();
                com = new SqlCommand("s_pr_get_fees_details");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@AdmissionNo", SqlDbType.VarChar).Value = AdmissionNo;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtFees = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dtFees.Rows.Count > 0)
                    {
                        ObjFees = Info.Fees.getFees(dtFees);

                        return ObjFees;
                    }
                    else
                    {
                        throw new ClassManager.Common.Exceptions.NoFeesException("No fees details for student");
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

        public static Decimal getOutstngAsofDate(int admissionNo, DateTime todaysDate)
        {

            try
            {
                com = new SqlCommand("s_pr_get_outstng_as_of_date");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@admission_no", SqlDbType.VarChar).Value = admissionNo;
                com.Parameters.Add("@date", SqlDbType.DateTime).Value = todaysDate;
                com.Parameters.Add("@amnt_due", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtFees = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    Decimal todaysDue = Convert.ToDecimal(com.Parameters["@amnt_due"].Value);
                    return todaysDue;
                }
                else
                {
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

                throw ex;
            }

        }

        /// <summary>
        /// Get All Student Name From who are in fees Table
        /// </summary>
        /// <param name="dtFees"></param>
        /// <returns></returns>

        public static List<Info.Fees> getAllStudentInFees(DataTable dtFees)
        {
            try
            {
                List<Info.Fees> lstFees = new List<Info.Fees>();

                foreach (DataRow drFees in dtFees.Rows)
                {
                    lstFees.Add(Info.Fees.getNameFees(drFees));
                }

                return lstFees;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static decimal getServiceTax()
        {
            try
            {
                com = new SqlCommand("select PRM_VALUE_INT from SYSTEM_PRM where PRM_NAME = 'SERVICE_TAX' and PRM_TO_DT is null");
                return Convert.ToDecimal(Sqlhelper.ExeScaler(com));
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static DataTable getOutstandingFees(string branchID, bool studentWise, DateTime? date = null, string StreamId = "%", string CourseId = "%", string BatchId = "%",DateTime? toDate = null )
        {

            try
            {
                if (!date.HasValue)
                {
                    date = DateTime.Now;
                }
                com = new SqlCommand("s_pr_disp_outstng_fees");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Branch_Id", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                com.Parameters.Add("@stream", SqlDbType.VarChar).Value = StreamId;
                com.Parameters.Add("@course", SqlDbType.VarChar).Value = CourseId;
                com.Parameters.Add("@batch", SqlDbType.VarChar).Value = BatchId;
                com.Parameters.Add("@studentwise", SqlDbType.Bit).Value = studentWise;
                if(toDate != null)
                {
                    com.Parameters.Add("@isWithinRange", SqlDbType.Bit).Value = true;
                }
                
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFees = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
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

        public static Invoice createInvoice(Invoice objInvoice, int branchId)
        {
            try
            {
                objTrans = Sqlhelper.getConnection().BeginTransaction();

                com = new SqlCommand("s_pr_create_invoice");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;

                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = objInvoice.admissionNo;
                com.Parameters.Add("@Amount", SqlDbType.Decimal).Value = objInvoice.amount;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = objInvoice.clientName;
                com.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = objInvoice.invoiceDate;
                com.Parameters.Add("@Client_GSTN", SqlDbType.VarChar).Value = "";
                com.Parameters.Add("@facilityId", SqlDbType.Int).Value = objInvoice.facilityId;
                com.Parameters.Add("@transaction_id", SqlDbType.Int).Value = objInvoice.TransactionId;
                com.Parameters.Add("@invoiceId", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@receipNo", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com, true);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    objInvoice.id = Convert.ToInt32(com.Parameters["@invoiceId"].Value);
                    objInvoice.invoiceNo = com.Parameters["@receipNo"].Value.ToString();

                    foreach (InvoiceDetails invoiceDetail in objInvoice.invoiceItems)
                    {

                        com = new SqlCommand("s_pr_create_invoice_details");
                        com.CommandType = CommandType.StoredProcedure;
                        com.Transaction = objTrans;

                        com.Parameters.Add("@invoiceId", SqlDbType.Int).Value = objInvoice.id;
                        com.Parameters.Add("@Amount", SqlDbType.Decimal).Value = invoiceDetail.amount;
                        com.Parameters.Add("@pakgAmount", SqlDbType.Decimal).Value = invoiceDetail.packageAmount;
                        com.Parameters.Add("@sacCode", SqlDbType.VarChar).Value = (invoiceDetail.SACCode == null ? "" : invoiceDetail.SACCode);
                        com.Parameters.Add("@quantity", SqlDbType.Int).Value = invoiceDetail.quantity;
                        com.Parameters.Add("@actualAmount", SqlDbType.Decimal).Value = invoiceDetail.actualAmount;
                        com.Parameters.Add("@CGSTPercentage", SqlDbType.Decimal).Value = invoiceDetail.CGSTPercentage;
                        com.Parameters.Add("@SGSTPercentage", SqlDbType.Decimal).Value = invoiceDetail.SGSTPercentage;
                        com.Parameters.Add("@CGSTAmount", SqlDbType.Decimal).Value = invoiceDetail.CGSTAmount;
                        com.Parameters.Add("@SGSTAmount", SqlDbType.Decimal).Value = invoiceDetail.SGSTAmount;
                        com.Parameters.Add("@totalTax", SqlDbType.Decimal).Value = invoiceDetail.totalTax;
                        com.Parameters.Add("@paidAmount", SqlDbType.Decimal).Value = invoiceDetail.paidAmount;
                        com.Parameters.Add("@balance", SqlDbType.Decimal).Value = invoiceDetail.balanceAmount;
                        com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
                        com.Parameters.Add("@packageName", SqlDbType.VarChar).Value = invoiceDetail.packageName;
                        com.Parameters.Add("@discount", SqlDbType.Decimal).Value = invoiceDetail.discount;
                        com.Parameters.Add("@USER_ID ", SqlDbType.VarChar).Value = UserHandler.loggedInUser.UserId;
                        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                        Sqlhelper.ExecuteNonQuery(com, true);

                        if (!ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                        {
                            throw new Common.Exceptions.InvalidReturnCodeException(com);
                        }
                    }

                    objTrans.Commit();

                    return objInvoice;
                }
                else
                {
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
                throw ex;
            }
        }

        public static Invoice loadInvoiceDetails(int invoiceNo)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_detailed_invoice");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@invoiceNo", SqlDbType.Int).Value = invoiceNo;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtInvoiceDetails = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Invoice.getInvoice(dtInvoiceDetails);
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



        public static List<Info.InstallmentDetail> calculateInstallments(StudentFacility objStudentFacility, bool regenerate = true)
        {

            List<Info.InstallmentDetail> lstTempInstallment = new List<Info.InstallmentDetail>();
            if (regenerate)
            {
                FeeStructure objFeestrctr = new FeeStructure();
                int installNo = 1;
                string status = "NP";
                //foreach (FeeStructure optionalFees in optionalPackages)  //by sayali
                //{                   
                objStudentFacility.Installments = new List<InstallmentDetail>();

                if (objStudentFacility.Package.IsMainPackage == false)
                {
                    foreach (DateTime feesDate in objStudentFacility.selectedMonths)
                    {
                        Info.InstallmentDetail objInstDetail = new Info.InstallmentDetail();
                        objInstDetail.InstDate = feesDate;
                        objInstDetail.InstMonth = feesDate.Month;
                        objInstDetail.InstNo = installNo++;
                        objInstDetail.InstAmount = objStudentFacility.Package.SubjAmount;
                        objInstDetail.Status = status;
                        //
                        objInstDetail.Reason = objStudentFacility.Reason;
                        //
                        objInstDetail.Description = objStudentFacility.Package.PackageName;
                        lstTempInstallment.Add(objInstDetail);
                        objStudentFacility.Installments.Add(objInstDetail);
                    }
                }
                else
                {
                    if (objStudentFacility.Package.RegistrationAmount > 0 && objStudentFacility.Package.IsLumSum == false)
                    {
                        //Create installment for registration and Misc fees
                        Info.InstallmentDetail objRegInst = new Info.InstallmentDetail();
                        objRegInst.InstDate = objStudentFacility.FromDate;
                        objRegInst.InstNo = installNo++;
                        objRegInst.InstMonth = objRegInst.InstDate.Month;
                        objRegInst.InstAmount = objStudentFacility.Package.RegistrationAmount;
                        objRegInst.Status = status;
                        //

                        objRegInst.Reason = (objStudentFacility.Reason == null) ? "" : objStudentFacility.Reason;
                        //
                        objRegInst.Description = "Registration Fees";
                        objStudentFacility.Installments.Add(objRegInst);
                        lstTempInstallment.Add(objRegInst);
                    }

                    if (objStudentFacility.Package.MiscAmount > 0 && objStudentFacility.Package.IsLumSum == false)
                    {
                        //Create installment for registration and Misc fees
                        Info.InstallmentDetail objMiscInst = new Info.InstallmentDetail();
                        objMiscInst.InstDate = objStudentFacility.FromDate;
                        objMiscInst.InstNo = installNo++;
                        objMiscInst.InstMonth = objMiscInst.InstDate.Month;
                        objMiscInst.InstAmount = objStudentFacility.Package.MiscAmount;
                        objMiscInst.Status = status;
                        //
                        objMiscInst.Reason = (objStudentFacility.Reason == null) ? "" : objStudentFacility.Reason;
                        //
                        objMiscInst.Description = "Misc Fees";
                        lstTempInstallment.Add(objMiscInst);
                        objStudentFacility.Installments.Add(objMiscInst);
                    }



                    if (objStudentFacility.Package.IsLumSum == true)
                    {
                        Info.InstallmentDetail objInstDetails = new Info.InstallmentDetail();

                        objInstDetails.InstDate = objStudentFacility.FromDate;
                        objInstDetails.InstNo = installNo++;
                        objInstDetails.InstMonth = objInstDetails.InstDate.Month;
                        objInstDetails.InstAmount = objStudentFacility.Package.LumsumAmount;
                        objInstDetails.Status = status;
                        //
                        objInstDetails.Reason = (objStudentFacility.Reason == null) ? "" : objStudentFacility.Reason;
                        //
                        objInstDetails.Description = "Installment";
                        lstTempInstallment.Add(objInstDetails);
                        objStudentFacility.Installments.Add(objInstDetails);
                    }
                    else
                    {
                        if (objStudentFacility.Package.PackageType == PackageType.INSTALLMENT)
                        {

                            List<PackageInstallment> lstPack = new List<PackageInstallment>();
                            lstPack = objStudentFacility.Package.packInstmnts;
                            DateTime installmntDate = objStudentFacility.FromDate;

                            foreach (Info.PackageInstallment installDetails in lstPack)
                            {
                                Info.InstallmentDetail objInstDetails = new Info.InstallmentDetail();

                                installmntDate = installmntDate.AddMonths(installDetails.NoOfMonth).AddDays(installDetails.NoOfDays);
                                objInstDetails.InstDate = installmntDate;
                                objInstDetails.InstNo = installNo++;
                                objInstDetails.InstMonth = objInstDetails.InstDate.Month;
                                objInstDetails.InstAmount = installDetails.InstallmentAmount;
                                objInstDetails.Status = status;
                                objInstDetails.Description = (installDetails.InstName == null) ? " " : installDetails.InstName.ToString();
                                objInstDetails.Duration = installDetails.Duration;
                                objInstDetails.Reason = (objStudentFacility.Reason == null) ? "" : objStudentFacility.Reason;
                                //
                                lstTempInstallment.Add(objInstDetails);
                                objStudentFacility.Installments.Add(objInstDetails);

                            }
                        }
                        else
                        {

                            for (int i = 0; i < objStudentFacility.Package.PackageDuration; i = i + objStudentFacility.Package.MonthIncrement)
                            {
                                Info.InstallmentDetail objInstDetails = new Info.InstallmentDetail();

                                objInstDetails.InstDate = objStudentFacility.FromDate.AddMonths(i);
                                objInstDetails.InstMonth = objInstDetails.InstDate.Month;
                                objInstDetails.InstNo = installNo++;
                                objInstDetails.InstAmount = objStudentFacility.Package.RecurAmnt;
                                objInstDetails.Status = status;
                                //
                                objInstDetails.Reason = (objStudentFacility.Reason == null) ? "" : objStudentFacility.Reason;
                                //
                                objInstDetails.Description = objStudentFacility.Package.PackageName; // +" " + objInstDetails.InstDate.ToString("MMMM yyyy");//commented becoz 
                                lstTempInstallment.Add(objInstDetails);
                                objStudentFacility.Installments.Add(objInstDetails);
                            }
                        }
                    }
                }

                objStudentFacility.Package.SubjAmount = objStudentFacility.Installments.Sum(installment => installment.InstAmount);
                allocateDiscountToInstallments(objStudentFacility);
            }
            else
            {
                lstTempInstallment = objStudentFacility.Installments;
            }

            List<Info.InstallmentDetail> lstSortedList = lstTempInstallment.OrderBy(feesinstallment => feesinstallment.InstDate).ThenBy(feesinstallment => feesinstallment.Id).ToList();


            //Reorder installment nos
            for (int i = 0; i < lstSortedList.Count; i++)
            {
                lstSortedList[i].InstNo = i + 1;
            }


            return lstSortedList;
        }

        internal static void updateExpirySMSSentDate(DateTime lastSMSSentDate)
        {
            try
            {
                SqlCommand com = new SqlCommand();

                com.CommandText = "update STUDENT_FACILITIES set STFL_EXPIRY_SMS_DATE = GETDATE() where STFL_EXPIRY_SMS_DATE is null or STFL_EXPIRY_SMS_DATE = @date";
                com.Parameters.Add("@date", SqlDbType.Date).Value = lastSMSSentDate;


                Sqlhelper.ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw;
            }

            
        }

        public static DataTable getPayments(int admissionNo, DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                if (fromDate == null)
                {
                    fromDate = default(DateTime);
                }
                if (toDate == null)
                {
                    toDate = DateTime.MaxValue;
                }
                com = new SqlCommand("s_pr_get_payments");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
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
        public static DataTable getInvoice(int admissionNo)
        {
            try
            {
                com = new SqlCommand("s_pr_get_invoice");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = admissionNo;
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
        public static DataTable CourseWiseOutstanding(string BranchId)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_Coursewise_outstng_fees");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Branch_Id", SqlDbType.VarChar).Value = BranchId;
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

        public static StudentFacility getTransactionFacility(int transactionId)
        {
            try
            {
                SqlCommand com = new SqlCommand("select Top 1 * from STUDENT_FACILITIES where STFL_ID in (select sfd.STFL_FACILITY_ID from STUDENT_FEES_DETAILS sfd where sfd.STFL_TRANSACTION_ID = " + transactionId  + ") order by STFL_ID desc");
                DataTable facilities = Sqlhelper.GetDatatable(com);
                if(facilities.Rows.Count > 0)
                {
                    return StudentFacility.getStudentFacility(facilities.Rows[0]);
                }
                else
                {
                    return null;
                }
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void allocateDiscountToInstallments(StudentFacility objFacility)
        {

            objFacility.Installments = objFacility.Installments.OrderBy(feesinstallment => feesinstallment.InstDate).ThenBy(feesinstallment => feesinstallment.Id).ToList();

            decimal remainingDiscount = objFacility.Discount;

            if (objFacility.AutoRenewEnabled == false)
            {
                foreach (InstallmentDetail installment in objFacility.Installments)
                {
                    installment.Discount = Math.Min(remainingDiscount, installment.InstAmount);
                    remainingDiscount = Math.Max(remainingDiscount - installment.Discount, 0);
                }
            }
            else
            {
                foreach (InstallmentDetail installment in objFacility.Installments)
                {
                    installment.Discount = objFacility.Discount;
                }
            }
        }


        public static Fees getFeesDetails(int AdmissionNo)
        {
            try
            {
                List<Info.Fees> ObjFees = new List<Info.Fees>();
                com = new SqlCommand("s_pr_get_fees_details");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = AdmissionNo;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataSet dsFees = Sqlhelper.GetDataset(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dsFees.Tables[0].Rows.Count > 0)
                    {
                        return Fees.getFees(dsFees);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
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

                throw ex;
            }
        }

        public static decimal calculateOutstandingFees(Fees objFees, FeesPackage studentFeesPackage, List<FeeStructure> facilities)
        {
            //Decimal totalOustanding = 0;
            //if (studentFeesPackage.AutoRenew == true)
            //{
            //    Common.DateCalculator objDateCalculator = new Common.DateCalculator(objFees.PaymentStartDate, DateTime.Now);
            //    objDateCalculator.CalculateDateDifference();


            //    DateTime startDate = objFees.PaymentStartDate;
            //    while (DateTime.Now > startDate)
            //    {
            //        totalOustanding += studentFeesPackage.RecurAmnt;
            //        startDate = startDate.AddMonths(studentFeesPackage.MonthIncrement);
            //    }

            //}
            //else
            //{
            //    totalOustanding = objFees.TotalFees - (objFees.FeesPaid + objFees.BookingAmount + objFees.FeesDiscount);
            //}

            //foreach (FeeStructure facility in facilities)
            //{
            //    if (facility.AutoRenew == true)
            //    {
            //        DateTime startDate = fac.PaymentStartDate;
            //        while (DateTime.Now > startDate)
            //        {
            //            totalOustanding += studentFeesPackage.RecurAmnt;
            //            startDate = startDate.AddMonths(studentFeesPackage.MonthIncrement);
            //        }
            //    }
            //}


            //return totalOustanding;

            throw new NotImplementedException();
        }


        public static DataTable getFacilitiesDetails(int admissionNo)
        {

            try
            {

                com = new SqlCommand("s_pr_disp_student_facilities");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@AdmissionNo", SqlDbType.VarChar).Value = admissionNo;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtFacilities = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    //  return Info.FeeStructure.getFeeStructure(dtFacilities);
                    return dtFacilities;
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

        public static List<InstallmentDetail> orderInstallments(List<StudentFacility> lstStudentFacilities)
        {
            List<Info.InstallmentDetail> lstTempInstallment = new List<Info.InstallmentDetail>();
            FeeStructure objFeestrctr = new FeeStructure();
            foreach (StudentFacility optionalFees in lstStudentFacilities)
            {
                lstTempInstallment.AddRange(optionalFees.Installments);
            }

            List<Info.InstallmentDetail> lstSortedList = lstTempInstallment.OrderBy(feesinstallment => feesinstallment.InstDate).ThenBy(feesinstallment => feesinstallment.Id).ToList();


            //Reorder installment nos
            for (int i = 0; i < lstSortedList.Count; i++)
            {
                lstSortedList[i].InstNo = i + 1;
            }


            return lstSortedList;
        }

        public static List<Info.DueNotification> getOutstandingFeesDetails(string branchID, DateTime date, string admissionNo = "%",DateTime? toDate = null)
        {
            try
            {

                com = new SqlCommand("s_pr_get_outstng_details");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@admissionNo", SqlDbType.VarChar).Value = admissionNo;
                com.Parameters.Add("@date", SqlDbType.Date).Value = date;
                com.Parameters.Add("@branch_id", SqlDbType.VarChar).Value = (branchID == "-1") ? "%" : branchID.ToString();
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;

                if (toDate != null) {
                    com.Parameters.Add("@isWithinRange", SqlDbType.Bit).Value = true;
                }

                
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                DataTable dtTodaysDue = Sqlhelper.GetDatatable(com);

                Common.Log.LogError("Called get outstanding", Common.ErrorLevel.INFORMATION);

                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    return Info.DueNotification.getDues(dtTodaysDue);
                }
                else
                {
                    throw new Exception("Error occured");
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

        public static List<PaymentDetails> getTransactionPaymentDetails(int transactionId)
        {
            try
            {
                try
                {
                    com = new SqlCommand("s_pr_get_transaction_payment_details");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@transactionId", SqlDbType.VarChar).Value = transactionId;
                    com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                    DataTable paymentDetails = Sqlhelper.GetDatatable(com);
                    if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                    {
                        return Info.PaymentDetails.getDetails(paymentDetails);
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
            catch (Exception)
            {

                throw;
            }
        }


        public static List<DueNotification> getPaymentDueDetails(string BranchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_payment_due_details");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@branch_id", SqlDbType.VarChar).Value = (BranchId == "-1") ? "%" : BranchId.ToString();
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                DataTable dtTodaysDue = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.DueNotification.getDues(dtTodaysDue);
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

        public static List<FeesCollRpt> getFeesCollectionReport(string branchId, DateTime FromDate, DateTime ToDate)
        { //, string student=""
            try
            {
                com = new SqlCommand("s_pr_get_Fees_Collection_Report");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                com.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
              //  com.Parameters.Add("@student", SqlDbType.Bit).Value = student;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFees = Sqlhelper.GetDatatable(com);

                //DataView dv = new DataView(dtFees);

                //DataTable distinct = dv.ToTable(true, "TRNC_RECEIPT_NO", "FeesPaid", "StudentName",  "FEE_LAST_PAYMENT_DATE");

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.FeesCollRpt.getFCollRpt(dtFees);
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

        public static List<FeesCollRpt> getFeesCollectionReport1(string branchId, DateTime FromDate, DateTime ToDate, string student)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Fees_Collection_Report");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                com.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;

                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFees = Sqlhelper.GetDatatable(com);

                //DataView dv = new DataView(dtFees);

                //DataTable distinct = dv.ToTable(true, "TRNC_RECEIPT_NO", "FeesPaid", "StudentName",  "FEE_LAST_PAYMENT_DATE");

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.FeesCollRpt.getFCollRpt(dtFees);
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


        public static List<FeesCollRpt> getFeesCollectiondemo(string branchId, Stream FromDate, Stream ToDate)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Fees_Collection_Report");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate;
                com.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate;

                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.VarChar).Value = ParameterDirection.Output;
                DataTable dtFees = Sqlhelper.GetDatatable(com);

                //DataView dv = new DataView(dtFees);

                //DataTable distinct = dv.ToTable(true, "TRNC_RECEIPT_NO", "FeesPaid", "StudentName",  "FEE_LAST_PAYMENT_DATE");

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.FeesCollRpt.getFCollRpt(dtFees);
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





        #region "Constrution Methods"


        public static Decimal getoutfees(int admissionNo, DateTime todaysdate)
        {
            try
            {
                com = new SqlCommand("s_pr_get_outstng_as_of_date");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@admission_no", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@date", SqlDbType.DateTime).Value = todaysdate;
                com.Parameters.Add("@amnt_due", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFees = Sqlhelper.GetDatatable(com);

                Decimal todaysDue = Convert.ToDecimal(com.Parameters["@amnt_due"].Value);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return todaysDue;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable getTransactionReprint(string TransID, int facilityId = -1)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Transaction_Details_Reprint");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@TransID", SqlDbType.VarChar).Value = TransID;
                com.Parameters.Add("@facilityId", SqlDbType.VarChar).Value = facilityId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       public static DataTable getTransaction(string TransID)
       {
           try
           {
                //  string query = "select TRNC_ADMISSION_NO, TRNC_DATE, TRNC_AMOUNT, TRNC_PAYMENT_MODE, TRNC_RECEIPT_NO, TRNC_RECEIVED_FROM_TO from [Transaction] where TRNC_ID=" + TransID+"";
                //inner join  CHEQUE_DETAILS on PDEX_TRANSACTION_ID= CHQ_ID
                string query = "select * from [TRANSACTION] inner join PAID_EXPENSES on TRNC_ID = PDEX_TRANSACTION_ID   where TRNC_ID=" + TransID + "";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);
                return dtStandards;

            }
            catch (Exception ex)
           {

                throw ex;
            }
        }
        public static DataTable getCheque(string TransID)
        {
            try
            {
                string query = "select CHQ_ID, CHQ_NO, CHQ_DATE, CHQ_BANK_NAME, CHQ_BANK_BRANCH, CHQ_BOUNCE_CHARGES, CHQ_AMOUNT, CHQ_STATUS, CHQ_CRTD_AT from CHEQUE_DETAILS where CHQ_TRANC_ID=" + TransID+"";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);
                return dtStandards;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable getInvoiceReprint(string InvoiceNo, string InvoiceId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Invoice_details_Reprint");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@InvoiceId", SqlDbType.VarChar).Value = InvoiceId;
                com.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = InvoiceNo;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataTable getCumulative(int admissionNo, DateTime from, DateTime to)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_Cumulative");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = from;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = to;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable getRenewalOnLoad(string branchID, int identifire, DateTime? FromDate = null, DateTime? Todate = null)
        {
            try
            {
                if (Todate == null || FromDate == null)
                {

                    FromDate = new DateTime(1753, 1, 1);
                    Todate = DateTime.MaxValue;
                }
                com = new SqlCommand("s_pr_disp_Renew_on_load");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = (branchID == "-1") ? "%" : branchID.ToString();
                com.Parameters.Add("@identifire", SqlDbType.Int).Value = identifire;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = FromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = Todate;
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

        public static DataTable getRenewalOn(string branchID, int identifire, DateTime? FromDate = null, DateTime? Todate = null)
        {
            try
            {
                if (Todate == null || FromDate == null)
                {

                    FromDate = new DateTime(1753, 1, 1);
                    Todate = DateTime.MaxValue;
                }
                com = new SqlCommand("s_pr_disp_Renew_on_load");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = (branchID == "-1") ? "%" : branchID.ToString();
                com.Parameters.Add("@identifire", SqlDbType.Int).Value = identifire;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = FromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = Todate;
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


        public static DataTable getActiveExpiredMembers(string branchID, int identifire, DateTime? FromDate = null, DateTime? Todate = null)
        {
            try
            {
                if (Todate == null || FromDate == null)
                {

                    FromDate = new DateTime(1753, 1, 1);
                    Todate = DateTime.MaxValue;
                }
                com = new SqlCommand("s_pr_disp_Active_Absent_Members");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = (branchID == "-1") ? "%" : branchID.ToString();
                com.Parameters.Add("@identifire", SqlDbType.Int).Value = identifire;
                com.Parameters.Add("@fromDate", SqlDbType.Date).Value = FromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = Todate;
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

        public static bool cancelPayment(int transactionId)
        {
            try
            {
                
                SqlCommand com = new SqlCommand();
                com.CommandText = "s_pr_cancel_payment";
                com.CommandType = CommandType.StoredProcedure; // UserHandler.loggedInUser.UserId
                com.Parameters.Add("@transactionId", SqlDbType.Int).Value = transactionId;
                com.Parameters.Add("@loggedUser", SqlDbType.VarChar).Value = UserHandler.loggedInUser.UserId;

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

        public static bool getCourseWiseOutstandingFees(int feesId, int standardId, out decimal outstandingFees, out decimal courseFees, out decimal discount)
        {
            try
            {
                com = new SqlCommand("s_pr_get_course_outstng_fees");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@fees_id", SqlDbType.Int).Value = feesId;
                com.Parameters.Add("@standard_id", SqlDbType.Int).Value = standardId;
                com.Parameters.Add("@courseFees", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                com.Parameters.Add("@outstandingFees", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                com.Parameters.Add("@discount", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (com.Parameters["@outstandingFees"].Value == DBNull.Value)
                    {
                        outstandingFees = 0;
                        courseFees = 0;
                        discount = 0;
                    }
                    else
                    {
                        outstandingFees = Convert.ToDecimal(com.Parameters["@outstandingFees"].Value);
                        courseFees = Convert.ToDecimal(com.Parameters["@courseFees"].Value);
                        discount = Convert.ToDecimal(com.Parameters["@discount"].Value);
                    }

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


        #endregion
    }
}