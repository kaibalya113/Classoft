using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassManager.Info
{
    [Serializable]
    public class Transaction
    {

        public Transaction()
        {
            Cheques = new List<Cheque>();
        }

        enum Columns
        {
            TRNC_ID,
            TRNC_ADMISSION_NO,
            TRNC_ROLL_NO,
            TRNC_DATE,
            TRNC_PAYMENTS,
            TRNC_AMOUNT,
            TRNC_FINE,
            TRNC_RECEIVED_BY,
            TRNC_QUARTER,
            TRNC_ACADEMIC_YEAR,
            TRNC_FIN_YEAR,
            TRNC_BANK_NAME,
            TRNC_CHEQUE_NO,
            TRNC_BRANCH,
            TRNC_CHEQUE_DATE,
            TRNC_PAYMENT_MODE,
            TRNC_RECEIPT_NO,
            TRNC_SERVICE__TAX,
            TRNC_SERVICE_TAX_PRECENTAGE,
            TRNC_CR_DR,
            TRNC_BRANCH_ID,
            TRNC_RECEIVED_FROM_TO,
            TRNC_EXPENSE_ID,
            TRNC_CRTD_AT,
            TRNC_UPDT_AT,
            TRNC_DLTD_AT,
            TRNC_CRTD_BY,
            TRNC_UPDAT_BY,
            TRNC_DLTD_BY,
            TRNC_CHEQUE_AMOUNT,
            TRNC_CASH_AMOUNT,
            ID,
            TRNC_TRANSFER_AMOUNT,
            TRNC_REMARK

        }

        public int TrancID { get; set; }
        public int AdmisionNo { get; set; }
        public string RollNo { get; set; }
        public int AcadYear { get; set; }
        public DateTime Date { get; set; }
        public string Payments { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Fine { get; set; }
        public string ReceivedBy { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Quarter { get; set; }
        public int FinancialYear { get; set; }
        public string Branch { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public string ReceiptNo { get; set; }
        public decimal ServiceTax { get; set; }
        public decimal ServiceTaxPercentage { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<Cheque> Cheques { get; set; }
        public List<PaymentDetails> BankTransfer { get; set; }
        public decimal CashAmount { get; set; }
        public Account CashAccount { get; set; }
        public decimal TransferAmount { get; set; }
        public StudentFacility Facility { get; set; }
        public string reason { get; set; }
        public StudentFacility PaymentPackage { get; set; }

        public static Transaction getTransaction(DataRow dtTransaction)
        {
            Transaction objTransaction = new Transaction();

            objTransaction.AcadYear = EntityManager.getValue<Int32>(dtTransaction, Columns.TRNC_ACADEMIC_YEAR.ToString());
            objTransaction.AdmisionNo = EntityManager.getValue<Int32>(dtTransaction, Columns.TRNC_ADMISSION_NO.ToString());
            objTransaction.Amount = EntityManager.getValue<decimal>(dtTransaction, Columns.TRNC_AMOUNT.ToString());
            objTransaction.Date = EntityManager.getValue<DateTime>(dtTransaction, Columns.TRNC_DATE.ToString());
            objTransaction.PaymentDate = EntityManager.getValue<DateTime>(dtTransaction, Columns.TRNC_DATE.ToString());
            objTransaction.ReceiptNo = EntityManager.getValue<String>(dtTransaction, Columns.TRNC_RECEIPT_NO.ToString());
            objTransaction.TrancID = EntityManager.getValue<Int32>(dtTransaction, Columns.TRNC_ID.ToString());
            objTransaction.Facility = StudentFacility.getStudentFacility(dtTransaction);
            return objTransaction;
             
        }

        public static List<Transaction> getTransactions(DataTable dtTransaction)
        {
            List<Transaction> trasactions = new List<Transaction>();

            foreach(DataRow dr in dtTransaction.Rows)
            {
                trasactions.Add(getTransaction(dr));
            }

            return trasactions;
        }
    }
}
