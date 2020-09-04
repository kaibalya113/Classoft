
using ClassManager.WinApp.UICommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using ClassManager.Common;
using ClassManager.Info;
//using ClassManager.DAL;

namespace ClassManager.WinApp
{
    public partial class FrmImportRegistration : FrmParentForm
    {

        DataTable globalData;
        string sCaption = "Import";
        int StrmId;
        int courseId;
        int BatchId;
        int AccId;
        FeesPackage objFeePackage;
        public FrmImportRegistration()
        {
            InitializeComponent();
        }

        private void FrmSMImportRegistration_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog csvFilePath = new OpenFileDialog();
                csvFilePath.InitialDirectory = Application.ExecutablePath.ToString();

                csvFilePath.RestoreDirectory = true;
                if (csvFilePath.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = csvFilePath.FileName.ToString();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtPath.Text.Length != 0)
                {
                    readExcel(txtPath.Text);
                }

                else
                {
                    UICommon.WinForm.showStatus("Please Select File.", sCaption, this);
                }
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
            Cursor.Current = Cursors.Default;
        }

        
        private void readExcel(string path)

        {

            //Instance reference for Excel Application

            Microsoft.Office.Interop.Excel.Application objXL = null;

            //Workbook refrence

            Microsoft.Office.Interop.Excel.Workbook objWB = null;

            try

            {

                //Instancing Excel using COM services

                objXL = new Microsoft.Office.Interop.Excel.Application();

                //Adding WorkBook

                objWB = objXL.Workbooks.Open(path);

                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Excel.Worksheet)objWB.ActiveSheet;
                Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;

                DataTable dt = new DataTable();

                for (int i = 1; i < range.Columns.Count; i++)
                {
                    string colname = ((Microsoft.Office.Interop.Excel.Range)range.Cells[1, i]).Text.ToString();
                    dt.Columns.Add(colname);



                }

                for (int i = 1; i < range.Rows.Count; i++)
                {

                    DataRow dr = dt.NewRow();
                    for (int c = 1; c <= dt.Columns.Count; c++)
                    {
                        dr[c - 1] = (range.Cells[i, c] as Excel.Range).Text.ToString();
                    }

                    dt.Rows.Add(dr);
                }

                //Closing workbook

                objWB.Close();

                //Closing excel application

                objXL.Quit();
                
                
                //Because first row is column, that is to be delete.
                dt.Rows[0].Delete();
                globalData = dt;
                adgvDataToImport.DataSource = dt;
                //return dt;
            }

            catch (Exception ex)

            {

                objWB.Saved = true;

                //Closing work book

                objWB.Close();

                //Closing excel application

                objXL.Quit();

                //Response.Write("Illegal permission");
            }
        }
        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (adgvDataToImport.Rows.Count != 0)
                {
                    int biometicId;
                    List<int> duplicateRecords = new List<int>();
                    foreach (DataRow row in globalData.Rows)
                    {

                        Info.Student objStudent = new Info.Student();
                        // Enum.GetValues(typeof(Student.MemberData));
                        objStudent.AdmissionStandard = new Standard();

                        objStudent.Fname = (row["FirstName"].ToString());
                        objStudent.Mname = (row["MiddleName"].ToString());
                        objStudent.Lname = (row["LastName"].ToString());
                        objStudent.ContactNo = (row["ContactNo"].ToString());
                        objStudent.EmailID = (row["EmailID"].ToString());
                        objStudent.Address = (row["Address"].ToString());
                        objStudent.AdharCard = (row["AdharNo"].ToString());
                        objStudent.MembershipNo = (row["MembershipNo"].ToString());
                        //objStudent.BiometricId = (row["BiometricID"]).ToString();
                        objStudent.BiometricId = (Int32.TryParse(row["BiometricID"].ToString(), out biometicId) ? biometicId : -1);
                       
                        objStudent.Gender = (row["Gender"].ToString());
                        objStudent.FatherName = (row["MiddleName"].ToString()) + ' ' + (row["LastName"].ToString());
                        objStudent.BMI = "";
                        objStudent.Height = "";
                        objStudent.Remark = "";
                        objStudent.BloodGroup = "";
                        objStudent.Weight = "";
                        objStudent.FatherContactNo = "";
                        objStudent.counselor = "";
                        objStudent.Reference = "";
                        objStudent.Category = "";
                        objStudent.GSTNo = "";
                        objStudent.HeathIssue = "";
                        objStudent.counselor = "";
                        objStudent.Source = "";
                        objStudent.Dob = Convert.ToDateTime(row["DOB"]);
                        objStudent.AdmissionDate = Convert.ToDateTime(row["AdmissionDate"]);
                        //string Name = (row["Stream"].ToString());
                        objStudent.Enquiry = new Enquiry(-1);
                        objStudent.Branch.BranchId = Program.LoggedInUser.BranchId;
                        try
                        {
                            BLL.StudentHandller.RegisterStudent(objStudent);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Equals("Record Already Exists from SP s_pr_register_student"))
                            {
                                duplicateRecords.Add(objStudent.AdmisionNo);
                            }
                        }
                        int admsNo = objStudent.AdmisionNo;
                        Student obj = new Student();
                        obj = BLL.StudentHandller.GetStudent(admsNo, null, null, null, Program.LoggedInUser.BranchId);
                        objStudent.Fees.FeesId = obj.Fees.FeesId;

                        // cOMMINTED
                        List<Account> lstAcc = new List<Account>();
                        lstAcc = BLL.AccountHandller.getAccounts(Program.LoggedInUser.BranchId.ToString());
                        List<Info.Stream> lststream = new List<Info.Stream>();
                        lststream = BLL.StreamHandller.getStreams(Program.LoggedInUser.BranchId.ToString());
                        List<Info.Standard> lststd = new List<Info.Standard>();
                        List<Info.Batch> lstBatch = new List<Info.Batch>();
                        string Name = (row["Stream"]).ToString();

                        foreach (Info.Stream objstrm in lststream)
                        {
                            if (objstrm.Name == Name)
                            {
                                StrmId = (objstrm.ID);

                            }
                        }
                        int id = StrmId;

                        lststd = BLL.StreamHandller.getStandards(Program.LoggedInUser.BranchId, id);
                        string course = (row["Course"]).ToString();
                        String[] CourseName = course.Split(',');


                        foreach (Info.Standard objstd in lststd)
                        {
                            foreach (String SplitValue in CourseName)
                            {
                                if ((objstd.StandardName == SplitValue))
                                {
                                    courseId = (objstd.Standardid);
                                    // int[] SplitId = courseId.split

                                    int crseId = courseId;
                                    lstBatch = BLL.StandardHandller.GetBatches(crseId, Program.LoggedInUser.BranchId);
                                    string Batch = (row["Batch"].ToString());
                                    String[] splitBatch = Batch.Split(',');
                                    foreach (Info.Batch objbatch in lstBatch)
                                    {
                                        foreach (String singleBatch in splitBatch)
                                        {
                                            if (objbatch.Name == singleBatch)
                                            {
                                                BatchId = (objbatch.id);

                                            }

                                        }
                                    }
                                    if (chkAssignCourse.Checked)
                                    {
                                        foreach (FeesPackage objFeePackage in BLL.FeesPackageHandller.getStandardPackages(courseId, Program.LoggedInUser.BranchId))
                                        {
                                            string Package = (row["PackageName"]).ToString();
                                            String[] PackageName = Package.Split(',');
                                            foreach (String Pkge in PackageName)
                                            {
                                                if (objFeePackage.PackageName == Pkge)
                                                {

                                                    if (objStudent.AdmissionNo != 0)
                                                    {
                                                        StudentFacility objNewFacility = new StudentFacility();
                                                        if (objFeePackage.PackageType == PackageType.INSTALLMENT)
                                                        {
                                                            FeesPackage lstPackageInstallments = BLL.FeesPackageHandller.GetPackage(objFeePackage.Id);
                                                            objNewFacility.Package = lstPackageInstallments;
                                                        }
                                                        else
                                                        {
                                                            objNewFacility.Package = objFeePackage;
                                                        }

                                                        objNewFacility.FromDate = Convert.ToDateTime(row["AdmissionDate"]);
                                                        objNewFacility.Package.IsLumSum = false;
                                                        objNewFacility.AdmissionDate = Convert.ToDateTime(row["AdmissionDate"]);
                                                        //objNewFacility.Discount = (txtDiscount.Text == "") ? 0 : Convert.ToDecimal(txtDiscount.Text);
                                                        if ((row["Discount"]).ToString() == string.Empty)
                                                        {
                                                            objNewFacility.Discount = 0;
                                                        }
                                                        else
                                                        {
                                                            objNewFacility.Discount = Convert.ToDecimal(row["Discount"]);
                                                        }
                                                        objNewFacility.RenewDiscount = false;
                                                        objNewFacility.Student = objStudent;
                                                        objNewFacility.Student.Batch = new Batch();
                                                        objNewFacility.Student.Batch.id = BatchId;
                                                        objNewFacility.FacilityName = objFeePackage.PackageName;
                                                        objNewFacility.Amount = objFeePackage.PackageCost;
                                                        objStudent.Facilities.Add(objNewFacility);

                                                        BLL.FeesHandller.calculateInstallments(objNewFacility);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (objStudent.Facilities.Count > 0)
                                    {
                                        BLL.StudentHandller.addStudentFacilities(objStudent, objStudent.Facilities,0,0);
                                    }
                                }
                            }
                        }
                        // Done for payment of fees

                        if (chkAssignCourse.Checked)
                        {
                            if (objStudent.Facilities.Count > 0)
                            {
                                if ((row["PaymentDate"].ToString()) != string.Empty && (row["FeesPaid"].ToString()) != string.Empty)
                                {
                                    decimal serviceTaxPercentage = Info.SysParam.getValue<decimal>(SysParam.Parameters.SERVICE_TAX);
                                    objStudent.Fees.FineAmount = 0;
                                    if (row["FeesPaid"].ToString() == string.Empty)
                                    {
                                        objStudent.Fees.CashAmnt = 0;
                                    }
                                    else
                                    {
                                        objStudent.Fees.CashAmnt = Convert.ToDecimal(row["FeesPaid"].ToString());
                                    }
                                    // objStudent.Fees.ChequeAmnt = Cheques.Where(chq => chq.Status == Cheque.ChequeStatus.CLRD).Sum(chq => chq.Amount);
                                    // objStudent.Fees.PndgChqAmnt = Cheques.Where(chq => chq.Status == Cheque.ChequeStatus.PDNG).Sum(chq => chq.Amount);
                                    objStudent.Fees.FeesPaid = Convert.ToDecimal(row["FeesPaid"]);

                                    objStudent.Fees.FeesDiscount = 0;
                                    objStudent.Fees.AdmissionNo = objStudent.AdmissionNo;
                                    Transaction objTransaction = new Transaction();
                                    // Account obj = (row["PaymentBankCash"]) as Account;

                                    objTransaction.AcadYear = objStudent.Fees.AcadYear;
                                    objTransaction.AdmisionNo = objStudent.Fees.AdmissionNo;
                                    objTransaction.Amount = objStudent.Fees.FeesPaid + objStudent.Fees.FineAmount;
                                    objTransaction.Fine = objStudent.Fees.FineAmount;
                                    objTransaction.ReceivedBy = Program.LoggedInUser.UserId;
                                    objTransaction.RollNo = objStudent.RollNo;
                                    //  objTransaction.Cheques = Cheques;
                                    objTransaction.ServiceTax = objTransaction.Amount * (serviceTaxPercentage / 100);
                                    objTransaction.ServiceTaxPercentage = serviceTaxPercentage;
                                    //if ((row["PaymentDate"]) == string.Empty)
                                    // {
                                    //  objTransaction.PaymentDate =null;
                                    // }
                                    // else
                                    // {
                                    objTransaction.PaymentDate = Convert.ToDateTime(row["PaymentDate"].ToString());
                                    // }
                                    objTransaction.CashAmount = objStudent.Fees.CashAmnt;
                                    //int length = (row.ItemArray[Convert.ToInt32(Student.MemberData.PaymentBankCash)]).Length();
                                    string AccountName = (row["PaymentAccount"]).ToString();
                                    foreach (Info.Account objAccount in lstAcc)
                                    {
                                        if (objAccount.AccountName == AccountName)
                                        {
                                            objTransaction.CashAccount = objAccount;
                                        }
                                    }
                                    if ((row["ReceiptNo"]).ToString() != null)
                                    {
                                        StringBuilder receipt = new StringBuilder("M");
                                        string ReceiptNo = (receipt.Append((row["ReceiptNo"]).ToString())).ToString();
                                        objTransaction.ReceiptNo = ReceiptNo;
                                    }
                                    BLL.FeesHandller.PayFees(objStudent.Fees, objTransaction, Program.LoggedInUser.BranchId);

                                    Commongrid objCommon = Commongrid.getInstance();

                                    // objCommon.bindList(duplicateRecords);
                                }
                            }
                        }
                    }


                    UICommon.WinForm.showStatus("Data Imported Successfully.", sCaption, this);
                }

                else
                {
                    UICommon.WinForm.showStatus("Please Select file to Upload the Data.", sCaption, this,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

       
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                if (adgvDataToImport.Rows.Count != 0)
                {
                    if (CompulsoryFieldsValidation())
                    {
                        if (DataValidation())
                        {

                            UICommon.WinForm.showStatus("Validation completed, Please Assign Course and register Students", sCaption, this);

                        }
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("Please Select File to Upload the Data", sCaption, this);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public bool CompulsoryFieldsValidation()
        {
            try
            {
                foreach (DataGridViewRow dr in adgvDataToImport.Rows)
                {

                    if (dr.Cells["FirstName"].ToString() == "")
                    {
                        UICommon.WinForm.showStatus("Enter Name", sCaption, this);
                        dr.DefaultCellStyle.BackColor = Color.Tomato;
                        return false;
                    }
                  else  if (dr.Cells["ContactNo"].ToString() == "")
                    {
                        UICommon.WinForm.showStatus("Enter ContactNo.", sCaption, this);
                        dr.DefaultCellStyle.BackColor = Color.Tomato;
                        return false;
                    }
                   else if (dr.Cells["LastName"].ToString() == "")
                    {
                        UICommon.WinForm.showStatus("Enter LastName", sCaption, this);
                        dr.DefaultCellStyle.BackColor = Color.Tomato;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }   

        private bool DataValidation()
        {
            try
           {
               foreach (DataGridViewRow dr in adgvDataToImport.Rows)
              {
                    if (Regex.IsMatch(dr.Cells["FirstName"].Value.ToString(), @"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$"))
                    {
                        UICommon.WinForm.showStatus("Enter Valid Name", sCaption, this);
                        dr.DefaultCellStyle.BackColor = Color.Tomato;
                        return false;
                    }
                   else if (Regex.IsMatch(dr.Cells["MiddleName"].Value.ToString(), @"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$"))
                    {
                        UICommon.WinForm.showStatus("Enter Valid Middle Name", sCaption, this);
                        dr.DefaultCellStyle.BackColor = Color.Tomato;
                        return false;
                    }
                   else if (Regex.IsMatch(dr.Cells["LastName"].Value.ToString(), @"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$"))
                    {
                        UICommon.WinForm.showStatus("Enter Valid surname", sCaption, this);
                        dr.DefaultCellStyle.BackColor = Color.Tomato;
                        return false;
                    }
                    else if (Regex.IsMatch(dr.Cells["ContactNo"].Value.ToString(), "^[a-zA-Z]+$"))
                    {

                        UICommon.WinForm.showStatus("Enter Valid PhoneNumber", sCaption, this);
                        dr.DefaultCellStyle.BackColor = Color.Tomato;
                        return false;

                    }
                   
                    else if (dr.Cells["EmailID"].Value.ToString().Length > 0)          {
                        bool isEmail = Regex.IsMatch(dr.Cells["EmailID"].Value.ToString().Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
                        if (!isEmail)
                        {
                            UICommon.WinForm.showStatus("Please Enter valid email address.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                            return false;
                        }
                        return true;
                    }
                    else if(dr.Cells["ContactNo"].Value.ToString().Length!= 10)
                    {
                        UICommon.WinForm.showStatus("Please Enter valid Contact Number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void adgvDataToImport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow adrow in adgvDataToImport.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

                adgvDataToImport.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
} 