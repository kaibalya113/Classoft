using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace ClassManager.Info
{
     [Serializable]
    public class Branch
    {
        public int BranchId { get; set; }
        
        public string BranchName { get; set; }

        public string Address { get; set; }

        public string Head { get; set; }

        public int Receipt { get; set; }

        public string BranchClassName { get; set; }  
        
        public string InvoiceNo { get; set; } 


        enum ColumnName
        {
            BRCH_ID,
            BRCH_NAME,
            BRCH_ADDRESS,
            BRCH_HEAD,
            BRCH_IS_CURRENT,
            BRCH_CRTD_AT,
            BRCH_UPDT_AT,
            BRCH_DLTD_AT,
            BRCH_CRTD_BY,
            BRCH_UPDAT_BY,
            BRCH_DLTD_BY,
            RECEIPT_COUNT,
            BRCH_CLASS_NAME,
            BRCH_INVOICE_NO

        }
        public Branch(int BranchId)
        {
            // TODO: Complete member initialization
            this.BranchId = BranchId;
        }

        public Branch()
        {
            // TODO: Complete member initialization
        }

        public string IsCurrent { get; set; }
       
        public override string ToString()
        {
            return BranchName;
        }

        public static List<Branch> getBranchs(DataTable dtBranch)
        {
            try
            {
                List<Branch> lstBranch = new List<Branch>();

                foreach (DataRow drBranch in dtBranch.Rows)
                {
                    lstBranch.Add(getBranch(drBranch));
                }
                return lstBranch;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Branch getBranch(DataRow drBranch)
        {
            try
            {
                Branch objBranch = new Branch();

                
                objBranch.BranchId= EntityManager.getValue<Int32>(drBranch, ColumnName.BRCH_ID.ToString());
                
                objBranch.BranchName = EntityManager.getValue<string>(drBranch, ColumnName.BRCH_NAME.ToString());
                
                objBranch.Address = EntityManager.getValue<string>(drBranch, ColumnName.BRCH_ADDRESS.ToString());
               
                objBranch.Head = EntityManager.getValue<string>(drBranch, ColumnName.BRCH_HEAD.ToString());
               
                objBranch.IsCurrent = EntityManager.getValue<string>(drBranch, ColumnName.BRCH_IS_CURRENT.ToString());
                objBranch.Receipt = EntityManager.getValue<int>(drBranch, ColumnName.RECEIPT_COUNT.ToString());
                objBranch.InvoiceNo = EntityManager.getValue<string>(drBranch, ColumnName.BRCH_INVOICE_NO.ToString());
                objBranch.BranchClassName = EntityManager.getValue<string>(drBranch, ColumnName.BRCH_CLASS_NAME.ToString());
                return objBranch;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}
