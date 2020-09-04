using ClassManager.Info;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Info
{
    public class Invoice
    {
        public Int32 id { get; set; }
        public string invoiceNo { get; set; }
        public string clientName { get; set; }
        public DateTime? invoiceDate { get; set; }
        public decimal amount { get; set; }
        public int admissionNo { get; set; }
        public int branchId { get; set; }
        public string clientGSTN { get; set; }
        public int facilityId { get; set; }

        public List<InvoiceDetails> invoiceItems { get; set; }
        public int TransactionId { get; set; }

        enum ColumnName
        {
            INVOICE_BRANCH_ID,
            INVOICE_ID,
            INVOICE_NO,
            INVOICE_CLIENT,
            INVOICE_DATE,
            INVOICE_AMOUNT,
            INVOICE_ADMISSION_NO,
            INVOICE_CLIENT_GSTN
        }

        public Invoice()
        {
            facilityId = 0;
            TransactionId = 0;
        }

        public static Invoice getInvoice(DataTable dtInvoices)
        {
            if(dtInvoices.Rows.Count  > 0)
            {
                Invoice objInvoice = new Invoice();

                objInvoice.branchId = EntityManager.getValue<Int32>(dtInvoices.Rows[0], ColumnName.INVOICE_BRANCH_ID.ToString());
                objInvoice.id = EntityManager.getValue<Int32>(dtInvoices.Rows[0], ColumnName.INVOICE_ID.ToString());
                objInvoice.invoiceNo = EntityManager.getValue<String>(dtInvoices.Rows[0], ColumnName.INVOICE_NO.ToString());
                objInvoice.clientGSTN = EntityManager.getValue<String>(dtInvoices.Rows[0], ColumnName.INVOICE_CLIENT_GSTN.ToString());
                objInvoice.clientName = EntityManager.getValue<String>(dtInvoices.Rows[0], ColumnName.INVOICE_CLIENT.ToString());
                objInvoice.invoiceDate = EntityManager.getValue<DateTime>(dtInvoices.Rows[0], ColumnName.INVOICE_DATE.ToString());
                objInvoice.amount = EntityManager.getValue<decimal>(dtInvoices.Rows[0], ColumnName.INVOICE_AMOUNT.ToString());
                objInvoice.admissionNo = EntityManager.getValue<Int32>(dtInvoices.Rows[0], ColumnName.INVOICE_ADMISSION_NO.ToString());
                objInvoice.invoiceItems = getInvoiceItems(dtInvoices);
                

                return objInvoice;
            }
            else
            {
                return null;
            }

        }

        private static List<InvoiceDetails> getInvoiceItems(DataTable dtInvoices)
        {
            List<InvoiceDetails> invoiceDetails = new List<InvoiceDetails>();

            foreach (DataRow dr in dtInvoices.Rows)
            {
                invoiceDetails.Add(InvoiceDetails.getInvoiceDetails(dr));
            }

            return invoiceDetails;

        }
    }
}
