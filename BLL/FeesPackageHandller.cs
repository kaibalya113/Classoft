using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using ClassManager.Info;
using ClassManager.Common;
using ClassManager.Common.Exceptions;


namespace ClassManager.BLL
{
    public class FeesPackageHandller
    {
        static SqlCommand com;
        static SqlTransaction objTrans;

        public static int CreateNewPackage(Info.FeesPackage objCmplsryPkg, List<Info.FeesPackage> lstOptnlPkgs,int branchId)
        {
            try
            {
                InsertPackage(objCmplsryPkg,branchId);
                return objCmplsryPkg.Id;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static bool InsertPackage(Info.FeesPackage objCmplsryPkg,int branchId)
        {
            try
            {   
                com = new SqlCommand("s_pr_create_package");
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.Add("@ComboID", SqlDbType.VarChar).Value = objCmplsryPkg.ComboID;
                com.Parameters.Add("@PackageName", SqlDbType.VarChar).Value = objCmplsryPkg.PackageName;
                com.Parameters.Add("@PackageType", SqlDbType.Int).Value = (int)objCmplsryPkg.PackageType;
                com.Parameters.Add("@Duration", SqlDbType.Int).Value = objCmplsryPkg.PackageDuration;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@StandardID", SqlDbType.VarChar).Value = objCmplsryPkg.Standard.Standardid;
                com.Parameters.Add("@ValidStandards", SqlDbType.VarChar).Value = objCmplsryPkg.ValidStandards;
                com.Parameters.Add("@RegAmnt", SqlDbType.Decimal).Value = objCmplsryPkg.RegistrationAmount;
                com.Parameters.Add("@MiscAmnt", SqlDbType.Decimal).Value = objCmplsryPkg.MiscAmount;
                com.Parameters.Add("@RecursiveAmnt", SqlDbType.Decimal).Value = objCmplsryPkg.RecurAmnt;
                com.Parameters.Add("@TotalTuition", SqlDbType.Decimal).Value = objCmplsryPkg.TotalTuiAmnt;
                com.Parameters.Add("@TotalPackageCost", SqlDbType.Decimal).Value = objCmplsryPkg.PackageCost;
                com.Parameters.Add("@LumpSumCost", SqlDbType.Decimal).Value = objCmplsryPkg.LumsumAmount;
                com.Parameters.Add("@Package_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@HasOptionalSubject", SqlDbType.Bit).Value = objCmplsryPkg.HasOptionalSubject;
                com.Parameters.Add("@RemindRenewal", SqlDbType.Bit).Value = objCmplsryPkg.RemindRenewal;
                com.Parameters.Add("@AutoRenew", SqlDbType.Bit).Value = objCmplsryPkg.AutoRenew;
                com.Parameters.Add("@SACcode", SqlDbType.VarChar).Value = objCmplsryPkg.SACCode;
                com.Parameters.Add("@SGSTPercentage", SqlDbType.Decimal).Value = objCmplsryPkg.SGSTPercentage;
                com.Parameters.Add("@CGSTPercentage", SqlDbType.Decimal).Value = objCmplsryPkg.CGSTPercentage;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com,false);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    objCmplsryPkg.Id = Convert.ToInt32(com.Parameters["@Package_ID"].Value);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

                return true;

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }
        public static bool updatePackage(FeesPackage compulsory)
        {
            try
            {
                com = new SqlCommand("s_pr_update_Package");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@PackageID", SqlDbType.Int).Value = compulsory.Id;
                com.Parameters.Add("@ComboID", SqlDbType.VarChar).Value = compulsory.ComboID;
                com.Parameters.Add("@PackageName", SqlDbType.VarChar).Value = compulsory.PackageName;
                com.Parameters.Add("@PackageType", SqlDbType.Int).Value = (int)compulsory.PackageType;
                com.Parameters.Add("@Duration", SqlDbType.Int).Value = compulsory.PackageDuration;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = compulsory.BranchID;
                com.Parameters.Add("@StandardID", SqlDbType.VarChar).Value = compulsory.Standard.Standardid;
                com.Parameters.Add("@ValidStandards", SqlDbType.VarChar).Value = compulsory.ValidStandards;
                com.Parameters.Add("@RegAmnt", SqlDbType.Decimal).Value = compulsory.RegistrationAmount;
                com.Parameters.Add("@MiscAmnt", SqlDbType.Decimal).Value = compulsory.MiscAmount;
                com.Parameters.Add("@RecursiveAmnt", SqlDbType.Decimal).Value = compulsory.RecurAmnt;
                com.Parameters.Add("@TotalTuition", SqlDbType.Decimal).Value = compulsory.TotalTuiAmnt;
                com.Parameters.Add("@TotalPackageCost", SqlDbType.Decimal).Value = compulsory.PackageCost;
                com.Parameters.Add("@LumpSumCost", SqlDbType.Decimal).Value = compulsory.LumsumAmount;
                com.Parameters.Add("@HasOptionalSubject", SqlDbType.Bit).Value = compulsory.HasOptionalSubject;
                com.Parameters.Add("@RemindRenewal", SqlDbType.Bit).Value = compulsory.RemindRenewal;
                com.Parameters.Add("@AutoRenew", SqlDbType.Bit).Value = compulsory.AutoRenew;
                com.Parameters.Add("@SAC_CODE", SqlDbType.VarChar).Value = compulsory.SACCode;
                com.Parameters.Add("@SGSTPercentage", SqlDbType.Decimal).Value = compulsory.SGSTPercentage;
                com.Parameters.Add("@CGSTPercentage", SqlDbType.Decimal).Value = compulsory.CGSTPercentage;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com );
             
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

        public static bool deleteFeeStructure(int packageid, int branchId)
        {
            try
            {

                com = new SqlCommand("s_pr_delete_fee_structure");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@package_id", SqlDbType.Int).Value = packageid;
                com.Parameters.Add("@branchid", SqlDbType.Int).Value = branchId;
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

        public static bool deleteInstallments(int packageid, int branchid)
        {
            try
            {
                
                    com = new SqlCommand("s_pr_delete_installment");
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@branchid", SqlDbType.Int).Value = branchid;
                    com.Parameters.Add("@Package_Id", SqlDbType.Int).Value = packageid;
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
    
        public static List<Info.FeesPackage> getStandardPackages(int StandardID, int? branchid=null)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_std_packages");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@standard_id", SqlDbType.Int).Value = StandardID;
              
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

               
                DataTable dtPackage = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.FeesPackage.getPackages(dtPackage);
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


        public static List<Info.FeesPackage> getCourseWisePackages(int StreamId, int? branchid = null)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_standardwise_Packages");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Stream", SqlDbType.Int).Value = StreamId;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                
                DataTable dtPackage = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.FeesPackage.getPackages(dtPackage);
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

        public static Info.FeesPackage GetPackage(int PackageId)

        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_package");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@FPKG_ID", SqlDbType.Int).Value = PackageId;              
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                
                DataSet dsPackage = Sqlhelper.GetDataset(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return  Info.FeesPackage.getPackage(dsPackage);
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

        public static DataTable GetPackagesInBranch(string branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_course_package");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = branchID;
               
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

            
                DataTable dtPackage = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtPackage;
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

        public static bool InsertSubject(Info.FeeStructure objFeeStruct, int branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_insert_subject");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@PackageID", SqlDbType.Int).Value = objFeeStruct.MainPackageId;
                com.Parameters.Add("@subName", SqlDbType.VarChar).Value = objFeeStruct.PackageName;
                com.Parameters.Add("@subAmount", SqlDbType.Decimal).Value = objFeeStruct.SubjAmount;
                com.Parameters.Add("@packageType", SqlDbType.Int).Value = (int)objFeeStruct.PackageType;
                com.Parameters.Add("@AutoRenew", SqlDbType.Bit).Value = objFeeStruct.AutoRenew;
                com.Parameters.Add("@BranchID", SqlDbType.Int).Value = branchID;

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

     
        public static List<Info.FeesPackage> getStudentFacilities(int admissionNo,char status = 'A')
        {
            try
            {
                /*ALTER PROCEDURE [dbo].[s_pr_get_fees_structure]
				
                     (
                     @packageID int ,
                     @NUM_ERROR_CODE INT OUTPUT
                     )	
                 */
                com = new SqlCommand("s_pr_get_student_facilities");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@admissionNo", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@status", SqlDbType.Char).Value = status;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtSubject = Sqlhelper.GetDatatable(com);
                Sqlhelper.ExecuteNonQuery(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    List<Info.FeesPackage> lstFees = Info.FeeStructure.getFeeStructures(dtSubject);
                    return lstFees;
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

        public static bool InsertFacility(int instNo,Info.StudentFacility objFacility,int branchId, int biomId, int Count,string oldStflId =null,SqlTransaction transaction = null)
        {
            try
            {
                
                com = new SqlCommand("s_pr_insert_facilities");

                //com.Connection = DAL.Sqlhelper.getConnection();
                com.CommandType = CommandType.StoredProcedure;
                bool isTransactionAttached = (transaction == null) ? false : true;

                if (isTransactionAttached)
                {
                    com.Transaction = transaction;
                }

                com.Parameters.Clear();
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = objFacility.Student.AdmissionNo;
                com.Parameters.Add("@BatchId", SqlDbType.Int).Value = (objFacility.Student.Batch == null) ? -1 : objFacility.Student.Batch.id;
                com.Parameters.Add("@rollNo", SqlDbType.VarChar).Value = (objFacility.Student.RollNo == null) ? "" : objFacility.Student.RollNo;
                com.Parameters.Add("@FeesId", SqlDbType.Int).Value = objFacility.Student.Fees.FeesId;
                com.Parameters.Add("@facilityName", SqlDbType.VarChar).Value = objFacility.Package.PackageName;
                com.Parameters.Add("@PackageID", SqlDbType.Int).Value = objFacility.Package.Id;
                com.Parameters.Add("@remindRenewal", SqlDbType.Bit).Value = objFacility.Package.RemindRenewal;
                com.Parameters.Add("@isMainPackage", SqlDbType.Bit).Value = objFacility.Package.IsMainPackage;
                com.Parameters.Add("@fromdate", SqlDbType.Date).Value = objFacility.FromDate;
                com.Parameters.Add("@toDate", SqlDbType.Date).Value = objFacility.ToDate;
                com.Parameters.Add("@amount", SqlDbType.Decimal).Value = objFacility.Amount;
                com.Parameters.Add("@discount", SqlDbType.Decimal).Value = objFacility.Discount;
                com.Parameters.Add("@oldStflID", SqlDbType.VarChar).Value = (oldStflId == null) ? "-1" : oldStflId;
                com.Parameters.Add("@isAuto_Renew", SqlDbType.Bit).Value = objFacility.Package.AutoRenew;
                com.Parameters.Add("@admission_date", SqlDbType.DateTime).Value = objFacility.AdmissionDate;
                com.Parameters.Add("@renewDiscount", SqlDbType.Bit).Value = objFacility.RenewDiscount;
                com.Parameters.Add("@biomId", SqlDbType.Int).Value = biomId;
                com.Parameters.Add("@Count", SqlDbType.Int).Value = Count;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@instructorId", SqlDbType.Int).Value = objFacility.InstructorId;
                com.Parameters.Add("@discountReason", SqlDbType.VarChar).Value = (objFacility.DiscountReason == null) ? "" : objFacility.DiscountReason;
                com.Parameters.Add("@creditamount", SqlDbType.Decimal).Value = objFacility.CreditAmount;


                //com.Parameters.Add("@InstructorId", SqlDbType.Int).Value = InstructorId;
                com.Parameters.Add("@facility_id", SqlDbType.Int).Direction = ParameterDirection.Output;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com, isTransactionAttached);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (com.Parameters["@facility_id"].Value.ToString() == "")
                    {
                        return false;
                    }

                    objFacility.Id = Convert.ToInt32(com.Parameters["@facility_id"].Value);

                    com.CommandText = "s_pr_add_instDetails";

                    foreach (Info.InstallmentDetail objInstallment in objFacility.Installments)
                    {
                        com.Parameters.Clear();
                        com.Parameters.Add("@instMonth", SqlDbType.Int).Value = objInstallment.InstMonth;
                        com.Parameters.Add("@instNo", SqlDbType.Int).Value = instNo + objInstallment.InstNo;
                        com.Parameters.Add("@instDate", SqlDbType.Date).Value = objInstallment.InstDate;
                        com.Parameters.Add("@status", SqlDbType.VarChar).Value = objInstallment.Status;
                        com.Parameters.Add("@description", SqlDbType.VarChar).Value = objInstallment.Description;
                        com.Parameters.Add("@instAmount", SqlDbType.Decimal).Value = objInstallment.InstAmount;
                        com.Parameters.Add("@instID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        com.Parameters.Add("@feesID", SqlDbType.Int).Value = objFacility.Student.Fees.FeesId;
                        com.Parameters.Add("@facilityId", SqlDbType.Int).Value = objFacility.Id;
                        com.Parameters.Add("@discount", SqlDbType.Decimal).Value = objInstallment.Discount;
                        com.Parameters.Add("@standadId", SqlDbType.Int).Value = objFacility.Package.Standard.Standardid;
                        com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
                        com.Parameters.Add("@duration", SqlDbType.Int).Value = objInstallment.Duration;
                        com.Parameters.Add("@reason", SqlDbType.VarChar).Value = (objFacility.DiscountReason == null) ? " " : objFacility.DiscountReason;

                        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        Sqlhelper.ExecuteNonQuery(com, isTransactionAttached);

                        if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                        {
                            objInstallment.Id = (int)com.Parameters["@instID"].Value;
                        }
                        else
                        {
                            throw new Common.Exceptions.InvalidReturnCodeException(com);
                        }
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

        public static bool renewFacility(int facilitiyId)
        {
            try
            {
                com = new SqlCommand("s_pr_renew_facility");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@facility_id", SqlDbType.Int).Value = facilitiyId;
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
