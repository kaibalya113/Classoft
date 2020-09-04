using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info.Reporting
{
    public class FeeReceiptReportData : IReportData
    {
        public string ReceiptNo, StudentName, FatherContactNo, EmailId, ParentName, RupeesInWord, RollNo,
            PaymentMode, ChequeNo, BankName, Standard, ClassName, ClassAddress, CINNO, ServiceTaxNo, Address, ContactNo, FatherCntct, Admission, Batch, duration,
            CmpnyPanNO, BranchId, PaymentDetails, Adhar, query, MembershipNo, ClassSubName, MainAdd, OwnerNo, clasContct, Email, SGST, CGST, ClientGSTNo,
            NonTaxAmount, PackageName, SACCode, BatchDays, BranchAddress, ClassNote;
        public DateTime PaymentDate, date, minDate, AdmsnDate, FromDate;

        public DateTime? ChequeDate, DOB, StartDate, EndDate;
        public List<InstallmentDetail> InstallDetails;
        public string Logo, SirName, InstMonth, LastInstallmentMonth, stud_photo;
        public decimal TuitionFees, ServiceTax, TotalFees, OutstandingAmount, AmountPaid, FineAmount, PackageAmount, DisCount, TotalAmount, FinalAmount;
        public List<string> attachments;
        public int year, month, TransactionId, AdmsnNo, FeesId;

        public float TaxPercentage;
        public String InstallmentMonths { get; set; }
        public decimal CashPayment { get; set; }
        public decimal ChequePayment { get; set; }
        public List<Cheque> Cheques { get; set; }
        public List<PaymentDetails> BankTransfer { get; set; }
        public string PaymentDate1 { get; set; }
        public object FacilityId { get; set; }
        public decimal TotalOutstanding { get; set; }
        public string ReceivedBy { get; set; }
        public string AppType { get; private set; }

        public FeeReceiptReportData()
        {
            this.ReceivedBy = "";
            this.ContactNo = "";
            this.FatherContactNo = "";
            this.AppType = SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME);

        }

        public string getBankTansferDetails()
        {
            if (this.BankTransfer != null && BankTransfer.Count > 0)
            {
                StringBuilder transferDetails = new StringBuilder();

                transferDetails.Append("Transfer :");
                foreach (PaymentDetails paymentDetail in BankTransfer)
                {
                    transferDetails.Append(" Rs. " + paymentDetail.Amount + " Ref: " + paymentDetail.ReferenceNo);
                }

                return transferDetails.ToString();
            }
            else
            {
                return "NO";
            }
        }
    }
}
