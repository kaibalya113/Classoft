using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.BLL;
using ClassManager.WinApp.UICommon;
namespace ClassManager.WinApp
{
    public partial class FrmSubjectPackageMasterForm : FrmParentForm
    {

        RolePrivilege formPrevileges;

        static decimal lumSumTotal;
        static decimal installmentTotal;
        Info.Standard objStandard;
        List<Standard> lstStandards, lstAllowdStd;
        const string sCaption = "Subject Package Master";
        Info.FeesPackage objFeePckg = new Info.FeesPackage();
        static Decimal totalInstAmnt = 0;
        public List<PackageInstallment> packInstall;
        public List<FeeStructure> feeStruct;
        public List<Info.PackageInstallment> objInstallment = new List<Info.PackageInstallment>();
        Boolean sAllowIndexChange;
        List<FeesPackage> lstFeeStrctr = new List<FeesPackage>();
        string branchID = WinApp.Program.LoggedInUser.BranchId.ToString();
        PackageType selectedEnum;
        int autoRenewDuration;
        private FormOperation OperationMode;
        private bool isFromPackageView = false;


        public FrmSubjectPackageMasterForm()
        {
            InitializeComponent();

        }


        public bool validate_Package()
        {

            if (txtPackName.Text.Length == 0)
            {
                UICommon.WinForm.showStatus("Enter Package name first.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                txtPackName.Select();
                return false;
            }

            else if (txtDuration.Text.Length == 0)
            {
                UICommon.WinForm.showStatus("Enter Duration for Package.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                txtDuration.Select();
                return false;
            }
            else if (cmbPackType.SelectedIndex == -1)
            {
                UICommon.WinForm.showStatus("Please Select Valid Payment Type for Package", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                cmbPackType.Select();
                return false;
            }
            else
            {
                return true;
            }
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (validate_btnSave())
        //        {
        //            if (btnSave.Text == "Update Package" && objFeePckg.Id != 0)
        //            {
        //                objFeePckg.ComboID = txtPackName.Text;
        //                objFeePckg.PackageName = txtPackName.Text;

        //                objFeePckg.PackageType = (PackageType)cmbPackType.SelectedItem;
        //                objFeePckg.Standard = cmbCourse.SelectedItem as Standard;
        //                objFeePckg.RegistrationAmount = Convert.ToDecimal(txtRegistAmt.Text);
        //                objFeePckg.MiscAmount = Convert.ToDecimal(txtMisclnAmt.Text);
        //                objFeePckg.RecurAmnt = Convert.ToDecimal(txtCmplInstlAmnt.Text);
        //                objFeePckg.TotalTuiAmnt = Convert.ToDecimal(txtTTuitionAmnt.Text);
        //                objFeePckg.PackageCost = Convert.ToDecimal(txtCmplLumAmnt.Text);
        //                objFeePckg.LumsumAmount = Convert.ToDecimal(txtLumpSum.Text);
        //                objFeePckg.PackageDuration = Convert.ToInt32(txtDuration.Text);

        //                objFeePckg.HasOptionalSubject = chkHasOptionalSubjects.Checked;
        //                objFeePckg.AutoRenew = chkAutoRenew.Checked;

        //                //This is to update the Main Package,i.e, FeesPackage Table.
        //                FeesPackageHandller.updatePackage(objFeePckg);

        //                //This will update Fee_structure table.
        //                if (lstFeeStrctr.Count > 0)
        //                {
        //                    BLL.FeesPackageHandller.deleteFeeStructure(objFeePckg.Id, Program.LoggedInUser.BranchId);
        //                    foreach (Info.FeeStructure objFeeStrctr in lstFeeStrctr)
        //                    {
        //                        objFeeStrctr.MainPackageId = objFeePckg.Id;
        //                        BLL.FeesPackageHandller.InsertSubject(objFeeStrctr, Program.LoggedInUser.BranchId);
        //                    }
        //                }
        //                if (packInstall.Count > 0)
        //                {
        //                    BLL.FeesPackageHandller.deleteInstallments(objFeePckg.Id, Program.LoggedInUser.BranchId);
        //                    foreach (Info.PackageInstallment objPackInstallment in packInstall)
        //                    {
        //                        objPackInstallment.Package.MainPackageId = objFeePckg.Id;
        //                        //saving installment details in Package_Installment table
        //                        BLL.PackageInstHandller.addInst(objPackInstallment, Program.LoggedInUser.BranchId);
        //                    }
        //                }
        //                UICommon.WinForm.showStatus("Package Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //                this.Close();
        //            }

        //            else
        //            {
        //                string cmplsrySubList = String.Empty;
        //                PackageType selectedEnum = (PackageType)cmbPackType.SelectedItem;

        //                Info.FeesPackage objCmplsyFeePckg = new Info.FeesPackage();
        //                List<Info.FeesPackage> objOptnsFeePckgs = new List<Info.FeesPackage>();

        //                Info.PackageInstallment objPackInst = new Info.PackageInstallment();

        //                objCmplsyFeePckg.ComboID = txtPackName.Text;
        //                objCmplsyFeePckg.PackageName = txtPackName.Text;

        //                objCmplsyFeePckg.PackageType = (PackageType)cmbPackType.SelectedItem;
        //                objCmplsyFeePckg.Standard = cmbCourse.SelectedItem as Standard;
        //                objCmplsyFeePckg.RegistrationAmount = Convert.ToDecimal(txtRegistAmt.Text);
        //                objCmplsyFeePckg.MiscAmount = Convert.ToDecimal(txtMisclnAmt.Text);
        //                objCmplsyFeePckg.RecurAmnt = Convert.ToDecimal(txtCmplInstlAmnt.Text);
        //                objCmplsyFeePckg.TotalTuiAmnt = Convert.ToDecimal(txtTTuitionAmnt.Text);
        //                objCmplsyFeePckg.PackageCost = Convert.ToDecimal(txtCmplLumAmnt.Text);
        //                objCmplsyFeePckg.LumsumAmount = Convert.ToDecimal(txtLumpSum.Text);
        //                objCmplsyFeePckg.PackageDuration = Convert.ToInt32(txtDuration.Text);

        //                objCmplsyFeePckg.HasOptionalSubject = chkHasOptionalSubjects.Checked;
        //                objCmplsyFeePckg.AutoRenew = chkAutoRenew.Checked;

        //                FeesPackageHandller.CreateNewPackage(objCmplsyFeePckg, objOptnsFeePckgs, Program.LoggedInUser.BranchId);

        //                //feeStruct.Add(objFeeStruct); 
        //                if (packInstall != null)
        //                {
        //                    foreach (Info.PackageInstallment objPackInstallment in packInstall)
        //                    {
        //                        objPackInstallment.Package.MainPackageId = objCmplsyFeePckg.Id;
        //                        //saving installment details in Package_Installment table
        //                        BLL.PackageInstHandller.addInst(objPackInstallment, Program.LoggedInUser.BranchId);
        //                    }
        //                }

        //                if (chkHasOptionalSubjects.Checked)
        //                {
        //                    if (lstFeeStrctr != null)
        //                    {
        //                        foreach (Info.FeeStructure objFeeStrctr in lstFeeStrctr)
        //                        {
        //                            objFeeStrctr.MainPackageId = objCmplsyFeePckg.Id;
        //                            BLL.FeesPackageHandller.InsertSubject(objFeeStrctr, Program.LoggedInUser.BranchId);
        //                        }
        //                    }
        //                }
        //                UICommon.WinForm.showStatus("Package created successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //                ClearForm();
        //                chkHasOptionalSubjects.Checked = false;
        //            }
        //        }
        //    }
        //    catch(Common.Exceptions.RecordAlreadyExistsException ex)
        //    {
        //        UICommon.WinForm.showError(ex,"Package name \""+txtPackName.Text +"\" already exists,Please provide other name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        /// <summary>
        /// Following function will be called from AddFacilities Screen if package is not created for the selected standard.
        /// </summary>
        /// <param name="index"></param>
        public void loadfromAddFacilities(int index)
        {
            try
            {
                if (index != 0)
                {
                    cmbStream.DataSource = StreamHandller.getStreams(Program.LoggedInUser.BranchId.ToString());
                    cmbCourse.DataSource = StandardHandller.getStandard(branchID.ToString());
                    sAllowIndexChange = true;
                    cmbCourse.SelectedIndex = index;
                    loadForm();
                    sAllowIndexChange = false;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void setPackage(int packageId)
        {
            try
            {
                //FeesPackage feesPackage = FeesPackageHandller.GetPackage(packageId);
                objFeePckg = FeesPackageHandller.GetPackage(packageId);
                this.setOperationMode(FormOperation.EDIT, objFeePckg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void setOperationMode(FormOperation formOperation, FeesPackage feesPackage = null)
        {
            try
            {
                switch (formOperation)
                {
                    case FormOperation.EDIT:
                        lblOperation.Text = "Edit " + feesPackage.PackageName.ToString();
                        loadForm();
                        //cmbStream.SelectedItem = feesPackage.Standard.Stream;
                        //cmbCourse.SelectedItem = feesPackage.Standard;

                        cmbStream.Text = feesPackage.Standard.Stream.ToString();
                        cmbCourse.Text = feesPackage.Standard.ToString();
                        cmbPackType.SelectedItem = feesPackage.PackageType;
                        txtPackName.Text = feesPackage.PackageName.ToString();
                        txtDuration.Text = feesPackage.PackageDuration.ToString();
                        chkAutoRenew.Checked = feesPackage.AutoRenew;
                        chkRemindRenewal.Checked = objFeePckg.RemindRenewal;
                        chkHasOptionalSubjects.Checked = feesPackage.HasOptionalSubject;

                        txtRegistAmt.Text = feesPackage.RegistrationAmount.ToString();
                        txtMisclnAmt.Text = feesPackage.MiscAmount.ToString();
                        txtCmplInstlAmnt.Text = feesPackage.RecurAmnt.ToString();
                        txtTTuitionAmnt.Text = feesPackage.TotalTuiAmnt.ToString();
                        txtLumpSum.Text = feesPackage.LumsumAmount.ToString();
                        txtCmplLumAmnt.Text = feesPackage.PackageCost.ToString();
                        txtCGSTPercentage.Text = feesPackage.CGSTPercentage.ToString();
                        txtSGSTPercentage.Text = feesPackage.SGSTPercentage.ToString();
                        TxtSAC.Text = (feesPackage.SACCode != null ? feesPackage.SACCode :"");


                        lstFeeStrctr = feesPackage.Subjects;
                        packInstall = feesPackage.packInstmnts;

                        btnSave.Text = "UPDATE";

                        if (lstFeeStrctr.Count > 0)
                        {
                            subjPanel.Visible = true;
                            lstSubjects.DataSource = lstFeeStrctr;
                        }
                        if (packInstall.Count > 0)
                        {
                            //FrmInstallmentDetails objInstallments = UICommon.FormFactory.GetForm(UICommon.Forms.FrmInstallmentDetails, null, false) as FrmInstallmentDetails;
                            //objInstallments.objInstallment = packInstall;
                            //objInstallments.bindInstallmentsFromPackageView();
                            //objInstallments.Visible = true;

                            //installmentFrm.objInstallment = packInstall;
                            Panelnstallment.Visible = true;
                            this.Width = 1085;
                            this.Height = 698;
                            lstInstallments.DataSource = packInstall;
                        }
                        else
                        {
                            Panelnstallment.Visible = false;
                            this.Width = 764;
                            this.Height = 698;
                        }
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ClearForm()
        {
            try
            {
                sAllowIndexChange = false;

                //cmbStream.Text = " ";
                // cmbPackType.Text = " ";
                txtRegistAmt.Text = "";
                txtMisclnAmt.Text = "";
                txtPackName.Text = "";
                txtCmplInstlAmnt.Text = "";
                txtTTuitionAmnt.Text = "0";
                txtCmplInstlAmnt.Enabled = true;
                txtLumpSum.Text = "0";
                txtCmplLumAmnt.Text = "0";
                packInstall = new List<Info.PackageInstallment>();
                lstSubjects.DataSource = null;
                sAllowIndexChange = true;
                lstFeeStrctr.Clear();
                TxtSAC.Text = "";
                cmbPackType.Text = ""; ;
                cmbStream.Text = "";
                cmbCourse.Text = "";
                lblRecursve.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void SubjectPackageMasterForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsMdiChild != true)
                {

                }
                else
                {
                    //&& cmbCourse.Items.Count == 0
                    if (objFeePckg.Id == 0)
                    {
                        loadForm();
                        closeformifnoItems();
                    }

                    ApplyPrevileges();
                   if( btnSave.Text  == "UPDATE")
                    {
                       // Panelnstallment.Visible = true;
                      //  this.Width = 1085;
                       // this.Height = 698;
                    }
                    else
                    {
                        Panelnstallment.Visible = false;
                        this.Width = 764;
                        this.Height = 698;
                    }
                  
                    lblRecursiveText.Text = "";
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        //This Form should not be visible if no Stream and Course are Available.Mohan(13-July-2017).
        private void closeformifnoItems()
        {
            if (cmbStream.Items.Count == 0 || cmbCourse.Items.Count == 0)
            {
                UICommon.WinForm.showStatus("No Stream and Course Available", sCaption, this);
                this.BeginInvoke(new MethodInvoker(Close));
            }
        }

        /// <summary>
        /// This Function will assign Privileges based on the type of the user logged in.
        /// </summary>
        private void ApplyPrevileges()
        {
            try
            {
                int functionId = Convert.ToInt32(this.Tag);
                formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
                if (formPrevileges != null)
                {
                    if (formPrevileges.AllBranches == false)
                    {

                    }

                    if (formPrevileges.Modify == false)
                    {
                    }

                    if (formPrevileges.Create == false)
                    {
                        btnSave.Visible = false;
                    }

                    if (formPrevileges.Delete == false)
                    {

                    }
                    if (formPrevileges.View == false)
                    {
                        btnViewPackage.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void loadForm()
        {
            try
            {
                sAllowIndexChange = true;

                lblSubjects.Visible = false;
                subjPanel.Visible = false;
                cmbPackType.Items.Add(PackageType.MONTHLY);
                cmbPackType.Items.Add(PackageType.QUARTERLY);
                cmbPackType.Items.Add(PackageType.HALF_YEARLY);
                cmbPackType.Items.Add(PackageType.INSTALLMENT);
                cmbPackType.Items.Add(PackageType.YEARLY);

                cmbFaciltyPackType.Items.Add(PackageType.MONTHLY);
                cmbFaciltyPackType.Items.Add(PackageType.QUARTERLY);
                cmbFaciltyPackType.Items.Add(PackageType.HALF_YEARLY);

                cmbFaciltyPackType.Items.Add(PackageType.ONE_TIME);
               
                if (cmbCourse.Items.Count == 0)
                {
                    cmbStream.DataSource = StreamHandller.getStreams(branchID);
                }
               
                AssignEvents();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AssignEvents()
        {
            try
            {
                txtCmplInstlAmnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
                txtCmplLumAmnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
                txtRegistAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
                txtMisclnAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
                txtSubAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
                txtLumpSum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void cmbSStd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {
                    Info.FeesPackage objCmplsyFeePckg = new Info.FeesPackage();
                    //cmbOptnlSubs.DataSource = ((Standard)(cmbSStd.SelectedItem)).Subjects;
                    //cmboCmplsrySub.DataSource = ((Standard)(cmbSStd.SelectedItem)).Subjects;
                    txtPackName.Text = cmbStream.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        public bool validate_btnSave()
        {
            try
            {
                if (chkHasOptionalSubjects.Checked != true)
                {
                    if (cmbPackType.SelectedIndex == -1)
                    {
                        UICommon.WinForm.showStatus("Please Select Payment Type to Save Package Details.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        cmbPackType.Focus();
                        return false;
                    }
                    else if (txtLumpSum.Text.Length == 0 || txtLumpSum.Text == "0")
                    {
                        UICommon.WinForm.showStatus("Enter Package LumpSum cost.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtLumpSum.Focus();
                        return false;
                    }
                    else if ((txtCmplLumAmnt.Text.Length == 0 || txtCmplInstlAmnt.Text == "0") && (selectedEnum != PackageType.INSTALLMENT))
                    {
                        UICommon.WinForm.showStatus("Enter Package Total cost.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtCmplLumAmnt.Focus();
                        return false;
                    }
                    else if ((txtPackName.Text.Length == 0 || txtPackName.Text.Trim() == ""))
                    {
                        UICommon.WinForm.showStatus("Please Enter the Package Name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        txtPackName.Focus();
                        return false;
                    }
                   
                    else
                    {
                        return true;
                    }
                }

                else
                {
                    if (txtPackName.Text.Trim() == "")
                    {
                        UICommon.WinForm.showStatus("Invalid Package Name.", sCaption, this);
                        txtPackName.Focus();
                        return false;
                    }
                    else if (lstSubjects.Items.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

      
        private void cmboCmplsrySub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {
                    //If No batch for selected Course then User cannot create package.Mohan(13-July-2017).
                    List<Batch> lstBatch = BLL.StandardHandller.GetBatches((cmbCourse.SelectedItem as Standard).Standardid, Program.LoggedInUser.BranchId);
                    if(lstBatch.Count==0)
                    {
                        //disableControl();
                        UICommon.WinForm.showStatus("To Add Package for Selected standard,Batch is Compulsory", sCaption, this);
                       
                        UICommon.FormFactory.GetForm(UICommon.Forms.FrmStandardMasterForm).Visible = true;


                    }


                    // txtPackName.Text = cmbCourse.SelectedValue.ToString() + "_" + cmbPackType.Text;
                    txtPackName.Text = cmbCourse.SelectedValue.ToString();
                    if (!chkAutoRenew.Checked)
                    {
                        int duration = ((Standard)(cmbCourse.SelectedItem)).DurationInMonths;
                        txtDuration.Text = duration.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {
                    String stream = (cmbStream.SelectedItem as Stream).ID.ToString();
                    //cmbSStd.DataSource = StandardHandller.getStandard(stream);
                    cmbCourse.DataSource = StandardHandller.getStandard(branchID.ToString(), stream);
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }



        private void txtRegistAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {

                    total();
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        private void txtMisclnAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {
                    total();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }


        private void txtCmplInstlAmnt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {
                 
                    total();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }

        }

        private void total()
        {
            if (validateFiguresForTotal())
            {

                if (txtRegistAmt.Text == "")
                {
                    txtRegistAmt.Text = "0";
                }

                if (txtCmplInstlAmnt.Text == "")
                {
                    txtCmplInstlAmnt.Text = "0";
                }

                if (txtCmplLumAmnt.Text == "")
                {
                    txtCmplLumAmnt.Text = "0";
                }

                if (txtMisclnAmt.Text == "")
                {
                    txtMisclnAmt.Text = "0";
                }
                if (txtTTuitionAmnt.Text == "")
                {
                    txtTTuitionAmnt.Text = "0";
                }
                if (txtLumpSum.Text == "")
                {
                    txtLumpSum.Text = "0";
                }
                //lumSumTotal = Convert.ToDecimal(txtRegistAmt.Text) + Convert.ToDecimal(txtCmplLumAmnt.Text) + Convert.ToDecimal(txtMisclnAmt.Text);
                //installmentTotal = Convert.ToDecimal(txtRegistAmt.Text) + Convert.ToDecimal(txtCmplInstlAmnt.Text) + Convert.ToDecimal(txtMisclnAmt.Text);
                //txtInstallTotal.Text = installmentTotal.ToString();
                //txtLumpSumTotal.Text = lumSumTotal.ToString();
                Decimal reg =  Convert.ToDecimal(txtRegistAmt.Text);
                Decimal mis = Convert.ToDecimal(txtMisclnAmt.Text);
                Decimal recur = Convert.ToDecimal(txtCmplInstlAmnt.Text);
                Decimal tui = Convert.ToDecimal(txtTTuitionAmnt.Text);
                Decimal totalCost = Convert.ToDecimal(txtCmplLumAmnt.Text);
                Decimal dur = Convert.ToDecimal(txtDuration.Text);
                // Decimal instAmnt
                if (cmbPackType.SelectedItem != null)
                {
                    PackageType selectedEnum = (PackageType)cmbPackType.SelectedItem;

                    if (selectedEnum == PackageType.MONTHLY)
                    {
                        tui = (recur * (dur / 1));
                        txtTTuitionAmnt.Text = tui.ToString();
                        txtCmplLumAmnt.Text = (reg + mis + tui).ToString();
                        txtLumpSum.Text = (reg + mis + tui).ToString();
                        

                    }
                    else if (selectedEnum == PackageType.HALF_YEARLY)
                    {
                        tui = (recur * (dur / 6));
                        txtTTuitionAmnt.Text = tui.ToString();
                        txtCmplLumAmnt.Text = (reg + mis + tui).ToString();
                        txtLumpSum.Text = (reg + mis + tui).ToString();
                       
                    }
                    else if (selectedEnum == PackageType.QUARTERLY)
                    {
                        tui = (recur * (dur / 3));
                        txtTTuitionAmnt.Text = tui.ToString();
                        txtCmplLumAmnt.Text = (reg + mis + tui).ToString();
                        txtLumpSum.Text = (reg + mis + tui).ToString();
                      
                    }
                    else if (selectedEnum == PackageType.YEARLY)
                    {
                        tui = (recur * (dur / 12));
                        txtTTuitionAmnt.Text = tui.ToString();
                        txtCmplLumAmnt.Text = (reg + mis + tui).ToString();
                        txtLumpSum.Text = (reg + mis + tui).ToString();
                    }
                    else if (selectedEnum == PackageType.LUMPSUM)
                    {
                        tui = (recur * (dur / 12));
                        txtTTuitionAmnt.Text = tui.ToString();
                        txtCmplLumAmnt.Text = (reg + mis + tui).ToString();
                        txtLumpSum.Text = (reg + mis + tui).ToString();
                        lblSubjects.Visible = false;
                        subjPanel.Visible = false;
                    }
                    //else if (selectedEnum == PackageType.OPTIONAL)
                    //{
                    //    lblSubjects.Visible = true;
                    //    subjPanel.Visible = true;
                    //    txtCmplInstlAmnt.Enabled = false;
                    //    txtLumpSum.Enabled = false;
                    //    txtTTuitionAmnt.Enabled = false;
                    //    txtCmplLumAmnt.Text = (reg + mis + tui).ToString();
                    //}

                    else // One time or no. of installment
                    {
                        tui = totalInstAmnt;
                        txtTTuitionAmnt.Text = tui.ToString();
                        txtCmplLumAmnt.Text = (reg + mis + tui).ToString();
                        txtLumpSum.Text = (reg + mis + tui).ToString();
                       
                    }
                }
                //else
                //{       
                //    UICommon.WinForm.showStatus("Please Select Package Type First.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

                //}
            }

        }

        private bool validateFiguresForTotal()
        {
            if (txtDuration.Text == "")
            {
                UICommon.WinForm.showStatus("Please Provide Course Duration", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                return false;
            }
            return true;
        }

        private void cmbPackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sAllowIndexChange == true)
                {

                    lblRecursve.Visible = true;
                    txtCmplInstlAmnt.Visible = true;
                    selectedEnum = (PackageType)cmbPackType.SelectedItem;
                    if (objFeePckg.Id == 0)
                    {
                        //  txtPackName.Text = cmbCourse.SelectedValue.ToString() + "_" + cmbPackType.Text;
                        txtPackName.Text = cmbCourse.SelectedValue.ToString();
                    }
                    else
                    {
                        /// txtPackName.Text = objFeePckg.Standard.ToString() + "_" + cmbPackType.Text;
                        txtPackName.Text = objFeePckg.Standard.ToString();
                    }
                    if (selectedEnum == PackageType.MONTHLY)
                    {
                        lblRecursve.Enabled = true;
                        lblRecursiveText.Text = "* Enter Monthly Amount";
                        autoRenewDuration = 1;
                        txtCmplInstlAmnt.Enabled = true;
                        chkAutoRenew.Visible = true;
                    }
                    else if (selectedEnum == PackageType.HALF_YEARLY)
                    {
                        lblRecursve.Enabled = true;
                        lblRecursiveText.Text = "* Enter Half-Yearly Amount";
                        autoRenewDuration = 6;
                        txtCmplInstlAmnt.Enabled = true;
                        chkAutoRenew.Visible = true;
                    }
                    else if (selectedEnum == PackageType.QUARTERLY)
                    {
                        lblRecursve.Enabled = true;
                        lblRecursiveText.Text = "* Enter Quarterly Amount";
                        autoRenewDuration = 3;
                        txtCmplInstlAmnt.Enabled = true;
                        chkAutoRenew.Visible = true;
                    }
                    else if(selectedEnum == PackageType.YEARLY)
                    {
                        lblRecursve.Enabled = true;
                        lblRecursiveText.Text = "* Enter Yearly Amount";
                        autoRenewDuration = 12;
                        txtCmplInstlAmnt.Enabled = true;
                        chkAutoRenew.Visible = true;
                    }
                    else if (selectedEnum == PackageType.INSTALLMENT)
                    {
                        lblRecursve.Enabled = false;
                        txtCmplInstlAmnt.Text = "";
                        lblRecursiveText.Text = "";
                        txtCmplInstlAmnt.Enabled = true;
                        txtTTuitionAmnt.Text = "0";
                        txtLumpSum.Text = "0";
                        txtCmplLumAmnt.Text = "0";
                        objInstallment.Clear();

                        Panelnstallment.Visible = true;
                        this.Width = 1085;
                        this.Height = 698;
                        lstInstallments.DataSource = null;
                       // txtTotalInstallment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                        txtInstallmentAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                        txtDayGap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                        txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.numOnly);
                    
                    //installmentFrm.Visible = true;
                    chkAutoRenew.Checked = false;
                        chkAutoRenew.Visible = false;
                        txtCmplInstlAmnt.Enabled = false;
                    }

                    if (chkAutoRenew.Checked == true)
                    {
                        txtDuration.Text = autoRenewDuration.ToString();
                        txtDuration.Enabled = false;
                    }
                    //ClearForm();
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("value=" + packInstall);
        }

        public Decimal updateFeesInst(List<PackageInstallment> lstPackInstallment)
        {
            try
            {
                totalInstAmnt = 0;

                foreach (Info.PackageInstallment packageInst in lstPackInstallment)
                {
                    totalInstAmnt = totalInstAmnt + packageInst.InstallmentAmount;
                }
                string regAmount = txtRegistAmt.Text == "" ? "0" : txtRegistAmt.Text;
                string miscAmount = txtMisclnAmt.Text == "" ? "0" : txtMisclnAmt.Text;
                txtTTuitionAmnt.Text = (Convert.ToDecimal(regAmount) + Convert.ToDecimal(miscAmount) + totalInstAmnt).ToString();
                txtLumpSum.Text = (Convert.ToDecimal(regAmount) + Convert.ToDecimal(miscAmount) + totalInstAmnt).ToString();
                txtCmplLumAmnt.Text = (Convert.ToDecimal(regAmount) + Convert.ToDecimal(miscAmount) + totalInstAmnt).ToString();
                return totalInstAmnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool validate_btnAddSub()
        {
            try
            {
                if (txtSubName.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Enter subject name first.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtSubName.Focus();
                    return false;
                }
                else if (txtSubAmt.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Enter amount.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    txtSubAmt.Focus();
                    return false;
                }
                else if (cmbFaciltyPackType.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please Select Package Type", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    cmbFaciltyPackType.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        
        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void chkIsFacility_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasOptionalSubjects.Checked)
            {
                lblSubjects.Visible = true;
                subjPanel.Visible = true;
            }
            else
            {
                lblSubjects.Visible = false;
                subjPanel.Visible = false;
            }
        }

        private void chkAutoRenew_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAutoRenew.Checked)
                {
                    txtDuration.Text = autoRenewDuration.ToString();
                    txtDuration.Enabled = false;
                    total();
                }
                else
                {
                    //txtDuration.Enabled = true;
                    txtDuration.Text = ((Standard)(cmbCourse.SelectedItem)).DurationInMonths.ToString();
                    total();
                }
            }
            catch (Exception ex)
            {

                WinForm.showError(ex, sCaption, this);
            }
          
        }

        private void cmbFaciltyPackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PackageType selectedOptionalEnum = (PackageType)cmbFaciltyPackType.SelectedItem;
                if (selectedOptionalEnum == PackageType.INSTALLMENT)
                {
                    lblRecursve.Enabled = false;
                    txtCmplInstlAmnt.Text = "";
                    lblRecursiveText.Text = "";
                    txtCmplInstlAmnt.Enabled = true;
                    FrmInstallmentDetails installmentFrm = (FrmInstallmentDetails)FormFactory.GetForm(Forms.FrmInstallmentDetails, this.MdiParent);
                    //installmentFrm.subjectPackageMasterForm = this;
                    installmentFrm.objInstallment = packInstall;
                    installmentFrm.Visible = true;
                    chkAutoRenew.Checked = false;
                    chkAutoRenew.Visible = false;
                    txtCmplInstlAmnt.Enabled = false;
                }
                else if (selectedOptionalEnum == PackageType.ONE_TIME)
                {
                    chkOptionalAutoRenew.Checked = false;
                    chkOptionalAutoRenew.Visible = false;

                }
                else
                {
                    chkOptionalAutoRenew.Checked = true;
                    chkOptionalAutoRenew.Visible = true;

                }

            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDuration.SelectionLength = 2;
        }

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FeeStructure selectedFacility = lstSubjects.SelectedItem as FeeStructure;
                if (selectedFacility != null)
                {
                    
                        txtSubName.Text = selectedFacility.PackageName;
                        txtSubAmt.Text = selectedFacility.SubjAmount.ToString();
                        cmbFaciltyPackType.Text = selectedFacility.PackageType.ToString();
                        if (selectedFacility.AutoRenew == true)
                        {
                            chkOptionalAutoRenew.Checked = true;
                        }
                }
            }
            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate_btnSave())
                {
                    if (btnSave.Text == "UPDATE" && objFeePckg.Id != 0)
                    {
                        objFeePckg.ComboID = txtPackName.Text;
                        objFeePckg.PackageName = txtPackName.Text;

                        objFeePckg.PackageType = (PackageType)cmbPackType.SelectedItem;
                        objFeePckg.Standard = cmbCourse.SelectedItem as Standard;
                        objFeePckg.RegistrationAmount = Convert.ToDecimal(txtRegistAmt.Text);
                        objFeePckg.MiscAmount = Convert.ToDecimal(txtMisclnAmt.Text);
                        objFeePckg.RecurAmnt = Convert.ToDecimal(txtCmplInstlAmnt.Text);
                        objFeePckg.TotalTuiAmnt = Convert.ToDecimal(txtTTuitionAmnt.Text);
                        objFeePckg.PackageCost = Convert.ToDecimal(txtCmplLumAmnt.Text);
                        objFeePckg.LumsumAmount = Convert.ToDecimal(txtLumpSum.Text);
                        objFeePckg.PackageDuration =  Convert.ToInt32(txtDuration.Text);
                        objFeePckg.SACCode = TxtSAC.Text == "" ? "0" : TxtSAC.Text;
                        objFeePckg.HasOptionalSubject = chkHasOptionalSubjects.Checked;
                        objFeePckg.AutoRenew = chkAutoRenew.Checked;
                        objFeePckg.RemindRenewal = chkRemindRenewal.Checked;
                        objFeePckg.SGSTPercentage = Convert.ToDecimal(txtSGSTPercentage.Text);
                        objFeePckg.CGSTPercentage = Convert.ToDecimal(txtCGSTPercentage.Text);
                        objFeePckg.SACCode = TxtSAC.Text;
                        objFeePckg.PackageDurationDays = (txtDurationDays.Text.Equals(""))?0: Convert.ToInt32(txtDurationDays.Text);

                        //This is to update the Main Package,i.e, FeesPackage Table.
                        FeesPackageHandller.updatePackage(objFeePckg);

                        //This will update Fee_structure table.
                        if (lstFeeStrctr.Count > 0)
                        {
                            BLL.FeesPackageHandller.deleteFeeStructure(objFeePckg.Id, Program.LoggedInUser.BranchId);
                            foreach (Info.FeeStructure objFeeStrctr in lstFeeStrctr)
                            {
                                objFeeStrctr.MainPackageId = objFeePckg.Id;
                                BLL.FeesPackageHandller.InsertSubject(objFeeStrctr, Program.LoggedInUser.BranchId);
                            }
                        }
                        if (packInstall.Count > 0)
                        {
                            BLL.FeesPackageHandller.deleteInstallments(objFeePckg.Id, Program.LoggedInUser.BranchId);
                            foreach (Info.PackageInstallment objPackInstallment in packInstall)
                            {
                                objPackInstallment.Package.MainPackageId = objFeePckg.Id;
                                //saving installment details in Package_Installment table
                                BLL.PackageInstHandller.addInst(objPackInstallment, Program.LoggedInUser.BranchId);
                            }
                        }
                        UICommon.WinForm.showStatus("Package Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        this.Close();
                    }

                    else
                    {
                        string cmplsrySubList = String.Empty;
                        PackageType selectedEnum = (PackageType)cmbPackType.SelectedItem;

                        Info.FeesPackage objCmplsyFeePckg = new Info.FeesPackage();
                        List<Info.FeesPackage> objOptnsFeePckgs = new List<Info.FeesPackage>();

                        Info.PackageInstallment objPackInst = new Info.PackageInstallment();

                        objCmplsyFeePckg.ComboID = txtPackName.Text;
                        objCmplsyFeePckg.PackageName = txtPackName.Text;

                        objCmplsyFeePckg.PackageType = (PackageType)cmbPackType.SelectedItem;
                        objCmplsyFeePckg.Standard = cmbCourse.SelectedItem as Standard;
                        objCmplsyFeePckg.RegistrationAmount = txtRegistAmt.Text=="" ? 0 : Convert.ToDecimal(txtRegistAmt.Text);
                        objCmplsyFeePckg.MiscAmount = txtMisclnAmt.Text == "" ? 0 : Convert.ToDecimal(txtMisclnAmt.Text);
                        objCmplsyFeePckg.RecurAmnt = txtCmplInstlAmnt.Text == "" ? 0 : Convert.ToDecimal(txtCmplInstlAmnt.Text);
                        objCmplsyFeePckg.TotalTuiAmnt = Convert.ToDecimal(txtTTuitionAmnt.Text);
                        objCmplsyFeePckg.PackageCost = Convert.ToDecimal(txtCmplLumAmnt.Text);
                        objCmplsyFeePckg.LumsumAmount = Convert.ToDecimal(txtLumpSum.Text);
                        objCmplsyFeePckg.PackageDuration = Convert.ToInt32(txtDuration.Text);
                        objCmplsyFeePckg.SACCode = (TxtSAC.Text).ToString();
                        objCmplsyFeePckg.HasOptionalSubject = chkHasOptionalSubjects.Checked;
                        objCmplsyFeePckg.AutoRenew = chkAutoRenew.Checked;
                        objCmplsyFeePckg.SGSTPercentage = Convert.ToDecimal(txtSGSTPercentage.Text);
                        objCmplsyFeePckg.CGSTPercentage = Convert.ToDecimal(txtCGSTPercentage.Text);
                        objCmplsyFeePckg.PackageDurationDays = (txtDurationDays.Text.Equals("")) ? 0 : Convert.ToInt32(txtDurationDays.Text);
                        objCmplsyFeePckg.SACCode = TxtSAC.Text;

                        FeesPackageHandller.CreateNewPackage(objCmplsyFeePckg, objOptnsFeePckgs, Program.LoggedInUser.BranchId);

                        //feeStruct.Add(objFeeStruct); 
                        if (packInstall != null)
                        {
                            foreach (Info.PackageInstallment objPackInstallment in packInstall)
                            {
                                objPackInstallment.Package.MainPackageId = objCmplsyFeePckg.Id;
                                //saving installment details in Package_Installment table
                                BLL.PackageInstHandller.addInst(objPackInstallment, Program.LoggedInUser.BranchId);
                            }
                        }

                        if (chkHasOptionalSubjects.Checked)
                        {
                            if (lstFeeStrctr != null)
                            {
                                foreach (Info.FeeStructure objFeeStrctr in lstFeeStrctr)
                                {
                                    objFeeStrctr.MainPackageId = objCmplsyFeePckg.Id;
                                    BLL.FeesPackageHandller.InsertSubject(objFeeStrctr, Program.LoggedInUser.BranchId);
                                }
                            }
                        }
                        UICommon.WinForm.showStatus("Package created successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        ClearForm();
                        chkHasOptionalSubjects.Checked = false;
                    }
                }
            }
            catch (Common.Exceptions.RecordAlreadyExistsException ex)
            {
                UICommon.WinForm.showError(ex, "Package name \"" + txtPackName.Text + "\" already exists,Please provide other name", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate_btnAddSub())
                {
                    Info.FeesPackage objFeeStruct = new Info.FeesPackage();


                    if (lstFeeStrctr == null)
                    {
                        lstFeeStrctr = new List<Info.FeesPackage>();
                    }
                    objFeeStruct.PackageName = txtSubName.Text;
                    objFeeStruct.SubjAmount = Convert.ToDecimal(txtSubAmt.Text);
                    objFeeStruct.PackageType = (PackageType)cmbFaciltyPackType.SelectedItem;

                    objFeeStruct.AutoRenew = chkOptionalAutoRenew.Checked;

                    lstFeeStrctr.Add(objFeeStruct);

                    lstSubjects.DataSource = null;
                    lstSubjects.DataSource = lstFeeStrctr;

                    txtSubName.Clear();
                    txtSubAmt.Clear();

                }

            }

            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnRemoveSub_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSubjects.SelectedItem != null)
                {
                    lstFeeStrctr.Remove(lstSubjects.SelectedItem as Info.FeesPackage);
                    lstSubjects.DataSource = null;
                    lstSubjects.DataSource = lstFeeStrctr;
                    txtSubAmt.Text = "";
                    txtSubName.Text = "";
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void txtRegistAmt_Click(object sender, EventArgs e)
        {

        }

        private void btnAddInst_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateForm())
                {
                    if (objInstallment == null)
                    {
                        objInstallment = new List<Info.PackageInstallment>();
                    }
                   
                   
                    Info.PackageInstallment objPackInstall = new Info.PackageInstallment();
                    objPackInstall.InstallmentAmount = Convert.ToDecimal(txtInstallmentAmount.Text);
                    objPackInstall.countofInstallment = objInstallment.Count + 1;
                    objPackInstall.NoOfMonth = Convert.ToInt32(txtMonth.Text);
                    objPackInstall.NoOfDays = Convert.ToInt32(txtDayGap.Text);
                    objPackInstall.Duration =txtDurationInst.Text == "" ?0: Convert.ToInt32(txtDurationInst.Text);
                    objPackInstall.InstName =txtInstallmentAmount.Text==""?" ": txtInstName.Text.ToString();

                    objInstallment.Add(objPackInstall);

                    isFromPackageView = false;
                    lstInstallments.DataSource = null;
                    lstInstallments.DataSource = objInstallment;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Something went wrong please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }


        private bool validateForm()
        {
            try
            {
                if (txtInstallmentAmount.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please enter installment amount", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (txtDayGap.Text.Length == 0)
                {
                    UICommon.WinForm.showStatus("Please enter no of days", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                return true;
            }
            catch (Exception EX)
            {
                throw EX;
            }

        }

        private void btnRemoveInstallmnent_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstInstallments.SelectedItem != null)
                {
                    objInstallment.Remove(lstInstallments.SelectedItem as Info.PackageInstallment);
                    lstInstallments.DataSource = null;
                    lstInstallments.DataSource = objInstallment;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnREmove_Click(object sender, EventArgs e)
        {
            try
            {
                objInstallment.Clear();
                lstInstallments.DataSource = null;
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnSaveInstallment_Click(object sender, EventArgs e)
        {
            try
            {
              
                packInstall = objInstallment;
                updateFeesInst(packInstall);
                txtInstallmentAmount.Text = "";
                txtDayGap.Text = "";
                txtMonth.Text = "";
                lstInstallments.DataSource = null;
                lstInstallments.Items.Clear();
              
                Panelnstallment.Visible = false;
                this.Width = 764;
                this.Height = 698;
               
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void txtCmplInstlAmnt_Click(object sender, EventArgs e)
        {

        }

        private void lstInstallments_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (isFromPackageView == true)
                {
                    Info.PackageInstallment objselectedInstallment = lstInstallments.SelectedItem as Info.PackageInstallment;
                    txtInstallmentAmount.Text = objselectedInstallment.InstallmentAmount.ToString();
                    txtMonth.Text = objselectedInstallment.NoOfMonth.ToString();
                    txtDayGap.Text = objselectedInstallment.NoOfDays.ToString();
                    txtDurationInst.Text = objselectedInstallment.Duration.ToString();
                    txtInstName.Text = objselectedInstallment.InstName.ToString();
                    isFromPackageView = false;
                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }

        private void btnViewPackage_Click(object sender, EventArgs e)
        {
            try
            {
                UICommon.FormFactory.GetForm(UICommon.Forms.FrmPackagesView).Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        //private void btnViewPackage_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        UICommon.FormFactory.GetForm(UICommon.Forms.FrmPackagesView).Visible = true;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

        //    }
        //}
    }
}
