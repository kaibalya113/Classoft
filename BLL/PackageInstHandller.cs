using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;

namespace ClassManager.BLL
{
    public class PackageInstHandller
    {

        static SqlCommand com;
        public static bool addInst(Info.PackageInstallment objPackageInstallment,int branchId) 
        {
            try
            {
                com = new SqlCommand("s_pr_create_Installment");
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.Add("@Package_Id", SqlDbType.Int).Value = objPackageInstallment.Package.MainPackageId;
                com.Parameters.Add("@Inst_Amnt", SqlDbType.Decimal).Value = objPackageInstallment.InstallmentAmount;
                com.Parameters.Add("@Inst_Duration", SqlDbType.Int).Value = objPackageInstallment.Duration;
                com.Parameters.Add("@InstName", SqlDbType.VarChar).Value = objPackageInstallment.InstName;
                com.Parameters.Add("@NoOfmonth", SqlDbType.Int).Value = objPackageInstallment.NoOfMonth;
                com.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = objPackageInstallment.NoOfDays;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = branchId;

                com.Parameters.Add("@Inst_Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    
                    objPackageInstallment.InstallmentId = (int)com.Parameters["@Inst_Id"].Value;
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

        public static List<Info.PackageInstallment> getPackageInstallments(int packageId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_package_installments");
                com.CommandType = CommandType.StoredProcedure;
                /*(
                     @PackageId int,
	                 @NUM_ERROR_CODE int output 	
                )*/
                com.Parameters.Add("@PackageId", SqlDbType.Int).Value = packageId;             
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable installmentDT = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {

                    List<Info.PackageInstallment> objInstallments = Info.PackageInstallment.getInstallments(installmentDT);

                    return objInstallments;


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


        public static DataTable getDeleteFacility(string BranchID)
        {
            try
            {
                com = new SqlCommand("s_pr_view_delete_packages");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@BRANCHID", SqlDbType.Int).Value = BranchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable facility = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return facility;
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