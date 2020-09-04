using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassManager.Info;
using System.Data;

namespace ClassManager.Info
{
  public class PaymentDetails
    {
        public int Id;
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int BranchID { get; set; }
        public string ReferenceNo { get; set; }
        public PaymentType Type { get; set; }
        public string Details { get; set; }
        public string FromAcc{ get; set; }
        public string ToAcc { get; set; }
        public Account DepositAccount { get; set; }
        public Student Student;


        public PaymentDetails()
        {
            this.DepositAccount = new Account();
            this.Student = new Student();
        }
        enum ColumnNames
        {
            PD_ID,
            PD_AMOUNT,
            PD_FROM_ACC,
            PD_TO_ACC,
            PD_REFERANCE_NO,
            PD_TYPE,
            PD_DETAILS,
            PD_BRANCH_ID, PD_DATE
        }

        public static List<PaymentDetails> getDetails(DataTable dtDetails)
        {
            List<PaymentDetails> lstDetails = new List<PaymentDetails>();
            foreach (DataRow drDetail in dtDetails.Rows)
            {
                lstDetails.Add(getPayDetails(drDetail));
            }

            return lstDetails;

        }

        public static PaymentDetails getPayDetails(DataRow drDetails)
        {
            try
            {
                PaymentDetails objPayDetail = new PaymentDetails();

                objPayDetail.Id = EntityManager.getValue<Int32>(drDetails, ColumnNames.PD_ID.ToString());
                objPayDetail.ReferenceNo = EntityManager.getValue<string>(drDetails, ColumnNames.PD_REFERANCE_NO.ToString());
                objPayDetail.Amount = EntityManager.getValue<decimal>(drDetails, ColumnNames.PD_AMOUNT.ToString());
                objPayDetail.PaymentDate = EntityManager.getValue<DateTime>(drDetails, ColumnNames.PD_DATE.ToString());
                objPayDetail.Details = EntityManager.getValue<string>(drDetails, ColumnNames.PD_DETAILS.ToString());
                objPayDetail.FromAcc = EntityManager.getValue<string>(drDetails, ColumnNames.PD_FROM_ACC.ToString());
                objPayDetail.ToAcc = EntityManager.getValue<string>(drDetails, ColumnNames.PD_TO_ACC.ToString());

                objPayDetail.Type = (PaymentType)Enum.Parse(typeof(PaymentType), drDetails[ColumnNames.PD_TYPE.ToString()].ToString(), true);
                objPayDetail.BranchID = EntityManager.getValue<int>(drDetails, ColumnNames.PD_BRANCH_ID .ToString());
                objPayDetail.DepositAccount = Account.getAccount(drDetails);
                objPayDetail.Student = Student.getStudent(drDetails);

                return objPayDetail;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public enum PaymentType
        {
          BANK_TRANSFER,

        }
    }
}
