using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassManager.Info
{
    public class Cheque
    {
        public int Id;
        public DateTime? Date { get; set; }
        public string BankBranch { get; set; }
        public decimal Amount { get; set; }
        public string Bank { get; set; }
        public string ChequeNo { get; set; }
        public ChequeStatus Status { get; set; }
        public Decimal BounceCharges { get; set; }
        public Account DepositAccount { get; set; }
        public int BranchID { get; set; }
        public Student Student;


        public Cheque()
        {
            this.DepositAccount = new Account();
            this.Student = new Student();
        }
        enum ColumnNames
        {
            CHQ_ID,
            CHQ_NO,
            CHQ_DATE,
            CHQ_BOUNCE_CHARGES,
            CHQ_BANK_NAME,
            CHQ_BANK_BRANCH,
            CHQ_AMOUNT,
            CHQ_STATUS,
            CHQ_BRANCH_ID
        }




        public static List<Cheque> getCheques(DataTable dtCheques)
        {
            List<Cheque> lstCheques = new List<Cheque>();
            foreach (DataRow drCheque in dtCheques.Rows)
            {
                lstCheques.Add(getCheque(drCheque));
            }

            return lstCheques;

        }

        public static Cheque getCheque(DataRow drCheque)
        {
            try
            {
                Cheque objCheque = new Cheque();

                objCheque.Id = EntityManager.getValue<Int32>(drCheque, ColumnNames.CHQ_ID.ToString());
                objCheque.Amount = EntityManager.getValue<decimal>(drCheque, ColumnNames.CHQ_AMOUNT.ToString());
                objCheque.Bank = EntityManager.getValue<string>(drCheque, ColumnNames.CHQ_BANK_NAME.ToString());
                objCheque.BankBranch = EntityManager.getValue<string>(drCheque, ColumnNames.CHQ_BANK_BRANCH.ToString());
                objCheque.ChequeNo = EntityManager.getValue<string>(drCheque, ColumnNames.CHQ_NO.ToString());
                objCheque.Date = EntityManager.getValue<DateTime>(drCheque, ColumnNames.CHQ_DATE.ToString());
                objCheque.BounceCharges = EntityManager.getValue<decimal>(drCheque, ColumnNames.CHQ_BOUNCE_CHARGES.ToString());
                objCheque.Status = EntityManager.getValue<ChequeStatus>(drCheque, ColumnNames.CHQ_STATUS.ToString());
                objCheque.BranchID = EntityManager.getValue<int>(drCheque, ColumnNames.CHQ_BRANCH_ID.ToString());
                objCheque.DepositAccount = Account.getAccount(drCheque);
                objCheque.Student = Student.getStudent(drCheque);

                return objCheque;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public enum ChequeStatus
        {
            PDNG, CLRD, BNCD, PDC
        }

    }
}