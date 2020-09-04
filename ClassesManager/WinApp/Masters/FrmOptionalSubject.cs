using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmOptionalSubject : FrmParentForm
    {

        RolePrivilege formPrevileges;
        List<Info.StudentFacility> allFacilities;
        List<Info.StudentFacility> selectedFacilities;
        public static  Decimal totalSubjectCost;
        string sCaption = " Optional Subject";
      

        public FrmOptionalSubject()
        {
            InitializeComponent();
        }

        public bool populateList(List<Info.StudentFacility> allSubjects, List<Info.StudentFacility> selctedSubjects)
        {
            this.allFacilities = allSubjects;
            this.selectedFacilities = selctedSubjects;

            lstofAllSubjects.DataSource = null;
            lstofAllSubjects.DataSource = allSubjects;

            lstofSelectedSubjects.DataSource = null;
            lstofSelectedSubjects.DataSource = selctedSubjects;

            updateFees();

            return true;
        }

        

        //private void btnAddSubject_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
                
        //    if (lstofAllSubjects.SelectedItem != null)
        //    {
        //        Info.StudentFacility objFeeStrcuture = lstofAllSubjects.SelectedItem as Info.StudentFacility;

        //        //if (objFeeStrcuture.IsFacility == true && objFeeStrcuture.PackageType != Info.PackageType.ONE_TIME)
        //        //{
        //            FrmMonthSelector frmMnthSelector = new FrmMonthSelector();
        //            frmMnthSelector.feeStructure = objFeeStrcuture;
        //            frmMnthSelector.ShowDialog();              
        //            objFeeStrcuture.selectedMonths = frmMnthSelector.selectedMonths;
        //            if (frmMnthSelector.selectedMonths.Count > 0)
        //            {
        //                selectedFacilities.Add(frmMnthSelector.feeStructure);
        //                allFacilities.Remove(frmMnthSelector.feeStructure);
        //            }
        //        //}
        //        //else
        //        //{
        //        //    selctedSubjects.Add(objFeeStrcuture);                    
        //        //    allSubjects.Remove(objFeeStrcuture);
                    
        //        //}

        //        lstofSelectedSubjects.DataSource = null;
        //        lstofSelectedSubjects.DataSource = selectedFacilities;
        //        lstofAllSubjects.DataSource = null;
        //        lstofAllSubjects.DataSource = allFacilities;
        //    }

      //   updateFees();
        //    }
        //    catch (Exception ex)
        //    {
        //          UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

        private void updateFees()
        {
            decimal optionalPackageFees = 0;
            foreach (StudentFacility selectedFeeStructure in selectedFacilities)
            {

                if (selectedFeeStructure.Package.IsMainPackage)
                {
                    optionalPackageFees = optionalPackageFees + ((selectedFeeStructure.Package.IsLumSum) ? selectedFeeStructure.Package.LumsumAmount : selectedFeeStructure.Package.SubjAmount);
                }
                else
                {
                    if (selectedFeeStructure.Package.PackageType != PackageType.ONE_TIME)
                    {
                        optionalPackageFees += selectedFeeStructure.Package.SubjAmount * selectedFeeStructure.selectedMonths.Count;
                    }
                    else
                    {
                        optionalPackageFees = optionalPackageFees + selectedFeeStructure.Package.SubjAmount;
                    }
                }
            }
            txtTotalFees.Text = optionalPackageFees.ToString();
            
        }

        //private void btnRemoveSubject_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lstofSelectedSubjects != null)
        //        {
        //            Info.StudentFacility objFeeStrcuture = lstofSelectedSubjects.SelectedItem as Info.StudentFacility;

        //            selectedFacilities.Remove(objFeeStrcuture);
        //            lstofSelectedSubjects.DataSource = null;
        //            lstofSelectedSubjects.DataSource = selectedFacilities;

        //            allFacilities.Add(objFeeStrcuture);
        //            lstofAllSubjects.DataSource = null;
        //            lstofAllSubjects.DataSource = allFacilities;
        //        }
        //        updateFees();
        //    }
        //    catch (Exception ex)
        //    {
        //            UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }

           
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        calcTotalFees();
        //        this.Close();
        //        this.OnClosing(null);

        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
            
        //}

        public void calcTotalFees()
        {
            
            
        }

        private void OptionalSubject_FormClosing(object sender, FormClosingEventArgs e)
        {
            calcTotalFees();
        }

        private void FrmOptionalSubject_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }


        /// <summary>
        /// This Function will assign Privileges based on the type of the user logged in.
        /// </summary>
        private void ApplyPrevileges()
        {
            try
            {
                int functionId = Convert.ToInt32(this.Tag.ToString());
                //formPrevileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                calcTotalFees();
                this.Close();
                this.OnClosing(null);

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            try
            {

                if (lstofAllSubjects.SelectedItem != null)
                {
                    Info.StudentFacility objFeeStrcuture = lstofAllSubjects.SelectedItem as Info.StudentFacility;

                    //if (objFeeStrcuture.IsFacility == true && objFeeStrcuture.PackageType != Info.PackageType.ONE_TIME)
                    //{
                    FrmMonthSelector frmMnthSelector = new FrmMonthSelector(null);
                    frmMnthSelector.feeStructure = objFeeStrcuture;
                    frmMnthSelector.ShowDialog();
                    objFeeStrcuture.selectedMonths = frmMnthSelector.selectedMonths;
                    if (frmMnthSelector.selectedMonths.Count > 0)
                    {
                        selectedFacilities.Add(frmMnthSelector.feeStructure);
                        allFacilities.Remove(frmMnthSelector.feeStructure);
                    }
                    //}
                    //else
                    //{
                    //    selctedSubjects.Add(objFeeStrcuture);                    
                    //    allSubjects.Remove(objFeeStrcuture);

                    //}

                    lstofSelectedSubjects.DataSource = null;
                    lstofSelectedSubjects.DataSource = selectedFacilities;
                    lstofAllSubjects.DataSource = null;
                    lstofAllSubjects.DataSource = allFacilities;
                }

                updateFees();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

        private void btnRemoveSubject_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstofSelectedSubjects != null)
                {
                    Info.StudentFacility objFeeStrcuture = lstofSelectedSubjects.SelectedItem as Info.StudentFacility;

                    selectedFacilities.Remove(objFeeStrcuture);
                    lstofSelectedSubjects.DataSource = null;
                    lstofSelectedSubjects.DataSource = selectedFacilities;

                    allFacilities.Add(objFeeStrcuture);
                    lstofAllSubjects.DataSource = null;
                    lstofAllSubjects.DataSource = allFacilities;
                }
                updateFees();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }

        }
    }
}
