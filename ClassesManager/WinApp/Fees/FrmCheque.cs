using ClassManager.Info;
using ClassManager.WinApp.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassManager.WinApp
{
    public partial class FrmCheque : Form
    {
        List<Account> lstAccount;
        public static Cheque objCheque = null;
        StudentMaster ObjStudentMaster;
        static Info.Student objStudent;
        private static FrmChequePopup myInstance;
        private string sCaption = "Show Cheque";
        public static bool isAdd = true;
        string branchId = Program.LoggedInUser.BranchId.ToString();
        public int Sudent_id;
        List<ComboItem> lstStudentDetails = new List<ComboItem>();
        private bool isFormToClose;
        public FrmCheque()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (isAdd == false)
                {
                   
                    objCheque.Amount = Convert.ToDecimal(txtAmount.Text);
                    objCheque.Bank = txtBank.Text;
                    objCheque.BankBranch = txtBranch.Text;
                    objCheque.ChequeNo = txtChequeNo.Text;
                    objCheque.Status = (Info.Cheque.ChequeStatus)cmbChequeStatus.SelectedIndex;
                    string bounce = txtBounceCharges.Text;
                    if (bounce == "")
                    {
                        txtBounceCharges.Text = "0";
                    }
                    objCheque.BounceCharges = Convert.ToDecimal(txtBounceCharges.Text);
                    objCheque.Date = dtpCheque.Value;
                    //objCheque.DepositAccount = cmbAccounts.SelectedItem as Account;
                    //     BLL.ChequeHandler.UpdateCheque(objCheque);
                 //   BLL.ChequeHandler.Insert(objCheque, id);
                    this.Close();
                }
                else
                {
                    if (isFormToClose = validateForm())
                    {
                        Sudent_id = objStudent.AdmissionNo;
                        int id = objStudent.AdmissionNo;
                        string name = StudName.SelectedItem.ToString();
                       objCheque = new Cheque();
                        objCheque.Amount = Convert.ToDecimal(txtAmount.Text);
                        objCheque.Bank = txtBank.Text;
                        objCheque.BankBranch = txtBranch.Text;
                        objCheque.ChequeNo = txtChequeNo.Text;
                        objCheque.Status = (Info.Cheque.ChequeStatus)cmbChequeStatus.SelectedIndex;
                        
                        string bounce = txtBounceCharges.Text;
                        if (bounce == "")
                        {
                            txtBounceCharges.Text = "0";
                        }
                        objCheque.BounceCharges = Convert.ToDecimal(txtBounceCharges.Text);
                        objCheque.Date = dtpCheque.Value;
                        objCheque.Student.AdmissionNo = id;
                      
                        BLL.ChequeHandler.Insert(objCheque);
                        UICommon.WinForm.showMessage("Check Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        clearForm();
                    }
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }
        public bool validateForm()
        {
            try
            {
                if (txtBank.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Bank Name.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtBank.Focus();
                    return false;
                }
                else if (txtBranch.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Branch of Bank.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtBranch.Focus();
                    return false;
                }
                else if (txtChequeNo.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Cheque Number.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtChequeNo.Focus();
                    return false;
                }
                else if (cmbChequeStatus.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please select Status of the Cheque.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                    return false;
                }

              //  else if (cmbAccounts.SelectedIndex == -1)
               // {
               //     UICommon.WinForm.showStatus("Please select Account for the Cheque to be deposited.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
              //      return false;
              //  }
                else if (txtAmount.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please Enter Amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtAmount.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void clearForm()
        {
            txtBounceCharges.Text = "0";
            txtAmount.Text = "";
            txtBank.Text = "";
            txtBranch.Text = "";
            txtChequeNo.Text = "";
            cmbChequeStatus.SelectedIndex = 0;
            //cmbAccounts.SelectedIndex = 0;
        }
        private void FrmCheque_Load(object sender, EventArgs e)
        {
            try
            {
                //Setting cheque status. By default, it would be cleared.

                //if (myInstance == null || btnSave.Text=="Add")
                //{
                cmbChequeStatus.SelectedIndex = 0;
                //}

                AssignEvents();
                UICommon.WinForm.formatDateTimePicker(dtpCheque);
                if (isAdd == true)
                {
                    // assignAccountDataSource();
                    StudentDetails();
                }
                
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        public void AssignEvents()
        {
            txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtBounceCharges.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
            txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
        }

        private void StudName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (StudName.SelectedItem != null)
                {
                   loadStudent((StudName.SelectedItem as ComboItem).key);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        public void loadStudent(int admissionNo = -1)
        {
            try
            {
                if (admissionNo == -1)
                {
                    admissionNo = (objStudent != null) ? objStudent.AdmissionNo : -1;
                }

                if (admissionNo == -1)
                {
                    throw new Common.Exceptions.RecordNotFoundException("Student details not exists");
                }

                objStudent = BLL.StudentHandller.GetStudent(admissionNo, null, null, null, Program.LoggedInUser.BranchId);
               // populateData();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void StudentDetails()
        {
            try
            {
                lstStudentDetails.Add(new ComboItem(-1, "Select Member"));

                lstStudentDetails.AddRange(BLL.StudentHandller.getStudentList(branchId));

                StudName.DataSource = new List<Student>();
                StudName.DisplayMember = "name";
               // StudName.DataSource = lstStudentDetails;

                // then you have to set the PropertySelector like this:
                StudName.PropertySelector = collection => collection.Cast<ComboItem>().Select(p => p.name);
                if (this.IsMdiChild != true)
                {
                    string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                   
                    StudName.Text = objStudent.DisplayName;
                }
                else
                {
                  //  materialTabSelector1.BaseTabControl = tabMain;

                    //Last Tab Column(FollowUp).
                    DataGridViewCheckBoxColumn isFollowpClosed = new DataGridViewCheckBoxColumn();
                    isFollowpClosed.Name = "chkbxisClosed";
                    isFollowpClosed.HeaderText = "Close";
                   // ADGVFollowup.Columns.Insert(0, isFollowpClosed);
                    //ADGVFollowup.Columns[0].ReadOnly = false;

                  //  UICommon.WinForm.setDate(dtpfrom, dtpto);

                  //  ofdImage.Filter = "Image File (*.jpeg)|*.jpeg|Image File (*.jpg)|*.jpg";
                   // d//tpDOB.MaxDate = DateTime.Now.AddYears(-2);

                    List<ComboItem> lstStudentDetails = new List<ComboItem>();
                    List<ComboItem> lstBatch = new List<ComboItem>();
                    //lstStudentDetails.Add(new ComboItem(-1, "Select Student"));

                    lstStudentDetails.AddRange(BLL.StudentHandller.getStudentList(branchId));




                    StudName.DataSource = new List<Student>();
                    StudName.DisplayMember = "name";
                    StudName.DataSource = lstStudentDetails;
                    StudName.SelectedIndex = -1;

                    // then you have to set the PropertySelector like this:
                    StudName.PropertySelector = collection => collection.Cast<ComboItem>().Select(p => p.name);



                 //   assignValidationEvents();
                    AssignEvents();
                    clearForm();
                 //   btnAddFacilities.Enabled = false;
                  //  cmdBrwseImg.Enabled = false;
                  //  linkLabel1.Enabled = false;
                  //  lnkClear.Enabled = false;
                  //  bAllowIndexChange = true;
                   // tabMain.Visible = false;
                   // formatForm();
                  //  allow = true;
                   // formatdate();
                    //ApplyPrevileges();
                    string name = Info.SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);
                    
                   // loadFields();
                }
            }
            catch (Exception ex)
            {
              //  UICommon.WinForm.checkInternetConnection(ex, sCaption);
            }
        }
    }
}
