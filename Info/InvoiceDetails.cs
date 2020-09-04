using ClassManager.Info;
using System;
using System.Data;

namespace ClassManager.Info
{
    public class InvoiceDetails
    {
        public Int32 id { get; set; }
        public Int32 invoiceId { get; set; }
        public Decimal amount { get;  set; }
        public Decimal packageAmount { get; set; }
        public string SACCode { get; set; }
        public int quantity { get; set; }
        public decimal actualAmount { get; set; }
        public decimal CGSTPercentage { get; set; }
        public decimal SGSTPercentage { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal totalTax { get; set; }
        public decimal paidAmount { get; set; }
        public decimal balanceAmount { get; set; }
        public int branchId { get; set; }
        public string packageName { get; set; }
        public decimal discount { get; set; }


        enum ColumnName
        {
            INVC_ID,
            INVC_INVOICE_ID,
            INVC_AMOUNT,
            INVC_PAKG_AMT,
            INVC_SAC_CODE,
            INVC_QUANTITY,
            INVC_ACTUAL_AMT,
            INVC_CGST_PERCENTAGE,
            INVC_SGST_PERCENTAGE,
            INVC_CGST,
            INVC_SGST,
            INVC_TOTAL_TAX,
            INVC_PAID_AMT,
            INVC_BALANCE,
            INVC_BRANCH_ID,
            INVC_PCKG_NAME,
            INVC_DISCOUNT
        }


        public static InvoiceDetails getInvoiceDetails(DataRow dr)
        {
            InvoiceDetails objInvoiceDetails = new InvoiceDetails();

            objInvoiceDetails.id = EntityManager.getValue<Int32>(dr, ColumnName.INVC_ID.ToString());
            objInvoiceDetails.invoiceId = EntityManager.getValue<Int32>(dr, ColumnName.INVC_INVOICE_ID.ToString());
            objInvoiceDetails.amount = EntityManager.getValue<decimal>(dr, ColumnName.INVC_AMOUNT.ToString());
            objInvoiceDetails.packageAmount = EntityManager.getValue<decimal>(dr, ColumnName.INVC_PAKG_AMT.ToString());
            objInvoiceDetails.SACCode = EntityManager.getValue<string>(dr, ColumnName.INVC_SAC_CODE.ToString());
            objInvoiceDetails.quantity = EntityManager.getValue<Int32>(dr, ColumnName.INVC_QUANTITY.ToString());
            objInvoiceDetails.actualAmount = EntityManager.getValue<decimal>(dr, ColumnName.INVC_ACTUAL_AMT.ToString());
            objInvoiceDetails.CGSTPercentage = EntityManager.getValue<decimal>(dr, ColumnName.INVC_CGST_PERCENTAGE.ToString());
            objInvoiceDetails.SGSTPercentage = EntityManager.getValue<decimal>(dr, ColumnName.INVC_SGST_PERCENTAGE.ToString());
            objInvoiceDetails.CGSTAmount = EntityManager.getValue<decimal>(dr, ColumnName.INVC_CGST.ToString());
            objInvoiceDetails.SGSTAmount = EntityManager.getValue<decimal>(dr, ColumnName.INVC_SGST.ToString());
            objInvoiceDetails.totalTax = EntityManager.getValue<decimal>(dr, ColumnName.INVC_TOTAL_TAX.ToString());
            objInvoiceDetails.paidAmount = EntityManager.getValue<decimal>(dr, ColumnName.INVC_PAID_AMT.ToString());
            objInvoiceDetails.balanceAmount = EntityManager.getValue<decimal>(dr, ColumnName.INVC_BALANCE.ToString());
            objInvoiceDetails.branchId = EntityManager.getValue<Int32>(dr, ColumnName.INVC_BRANCH_ID.ToString());
            objInvoiceDetails.packageName = EntityManager.getValue<string>(dr, ColumnName.INVC_PCKG_NAME.ToString());
            objInvoiceDetails.discount = EntityManager.getValue<decimal>(dr, ColumnName.INVC_DISCOUNT.ToString());

            return objInvoiceDetails;

        }
    }
}