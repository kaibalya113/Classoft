using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HerambCoachingClasses.Common;
using HerambCoachingClasses.BLL;

namespace HerambCoachingClasses.WinApp
{
    public partial class Master : Form
    {
        Info.Standard objStandard;

        public Master()
        {
            InitializeComponent();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            Style.FormButtonStyle(this);
            objStandard = new Info.Standard();
            objStandard.Standardid = 1;
        }

        #region "val"
        private void btnNSAdd_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnNSAdd_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnSSAdd_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnSSAdd_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnCAdd_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnCAdd_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnOAdd_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnOAdd_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnCDelete_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnCDelete_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnODelete_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnODelete_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnAPackage_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnAPackage_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void txtLumpsum_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void txtInstallment_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void txtSCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.decimalOnly(sender as Control, e);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        private void btnNCAdd_MouseEnter(object sender, EventArgs e)
        {
            Style.ButtonHoverEnable(sender as Control);
        }

        private void btnNCAdd_MouseLeave(object sender, EventArgs e)
        {
            Style.ButtonHoverDisable(sender as Control);
        }

        #endregion

        private void btnCAdd_Click(object sender, EventArgs e)
        {
            lstCmplSub.Items.Add(txtCS.Text);
        }

        private void btnCDelete_Click(object sender, EventArgs e)
        {
            lstCmplSub.Items.Remove(lstCmplSub.SelectedItem);
        }

        private void btnOAdd_Click(object sender, EventArgs e)
        {
            Info.FeeStructure objFeeStructure = new Info.FeeStructure();
            objFeeStructure.Subject = txtOS.Text;
            objFeeStructure.InstallmentAmt = Convert.ToDecimal(txtOptnlInstllAmnt.Text);
            objFeeStructure.LumsumAmt = Convert.ToDecimal(txtOptnlLumpAmnt.Text);

            lstOptnSub.Items.Add(objFeeStructure);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string cmplsrySubList = String.Empty;
            
            Info.FeesPackage objCmplsyFeePckg = new Info.FeesPackage();
            List<Info.FeesPackage> objOptnsFeePckgs = new List<Info.FeesPackage>();

            objCmplsyFeePckg.Subjects = (List<Info.FeeStructure>)lstCmplSub.Items.Cast<Info.FeeStructure>().ToList();
            objCmplsyFeePckg.ComboID = txtSPN.Text;
            objCmplsyFeePckg.PackageName = txtSPN.Text;
            objCmplsyFeePckg.PackageType = "C";
            objCmplsyFeePckg.StandardID = objStandard.Standardid;
            objCmplsyFeePckg.ValidStandards = txtValidStd.Text;

            objOptnsFeePckgs = (List<Info.FeesPackage>)lstOptnlPkges.Items.Cast<Info.FeesPackage>().ToList();


            foreach (object listItem in lstCmplSub.Items)
            {
                cmplsrySubList = cmplsrySubList + listItem.ToString() + ",";
            }
            objCmplsyFeePckg.SubList = cmplsrySubList;


            FeesPackageHandller.CreateNewPackage(objCmplsyFeePckg, objOptnsFeePckgs);
        }

        private void btnAPackage_Click(object sender, EventArgs e)
        {
            string pkgSubList = String.Empty;
            Info.FeesPackage objFeePckg = new Info.FeesPackage();

            objFeePckg.Subjects = (List<Info.FeeStructure>)lstOptnSub.Items.Cast<Info.FeeStructure>().ToList();
            objFeePckg.ComboID = txtComboId.Text;
            objFeePckg.PackageName = txtSPN.Text;
            objFeePckg.PackageType = "O";
            objFeePckg.StandardID = objStandard.Standardid;

            foreach (object listItem in lstOptnSub.Items)
            {
                pkgSubList = pkgSubList + listItem.ToString() + ",";
            }
            objFeePckg.SubList = pkgSubList;
            lstOptnlPkges.Items.Add(objFeePckg);


        }

        private void btnODelete_Click(object sender, EventArgs e)
        {
            lstOptnSub.Items.Remove(lstOptnSub.SelectedItem);
        }

        private void cmbSStd_SelectedIndexChanged(object sender, EventArgs e)
        {
            objStandard = new Info.Standard();
            objStandard.Standardid = 1;
        }
    }
}
