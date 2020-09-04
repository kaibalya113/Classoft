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
    public partial class FrmSystemParam : FrmParentForm
    {
        string branchId = WinApp.Program.LoggedInUser.BranchId.ToString();
        
        RolePrivilege formPrevileges;
        
        string sCaption = "System Parameter";
        public FrmSystemParam()
        {
            InitializeComponent();
            gridViewReadOnly = false;
        }

        private void NewSysParam_Load(object sender, EventArgs e)
        {
            try
            {
                ADGVSysParam.ReadOnly = false;
                ADGVSysParam.DataSource = BLL.SystemParameterHandler.getSysParam();

                ApplyPrevileges();

            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
                // UICommon.WinForm.showError(ex, "Cannot retrieve data for System Parameter.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
            AssignEvents();

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
                        btnSave.Visible = false;
                    }

                    if (formPrevileges.Create == false)
                    {
                       
                    }

                    if (formPrevileges.Delete == false)
                    {
                     
                    }
                    if (formPrevileges.View == false)
                    {
                  
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Encrypts GridView TextBoxCell.Mohan(27-July-2017).
        //private void encryptPassword()
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow row in ADGVSysParam.Rows)
        //        {
        //            if (row.Cells[0].Value != null)
        //            {
                        //if (row.Cells[0].Value.Equals("SMS_PASSWORD"))
                        //{
                        //    row.Cells[1].Value = Common.EncryptionDecryption.Encrypt(row.Cells[1].Value.ToString());
                        //}
        //                if (row.Cells[0].Value.Equals("SMTP_PASSWORD"))
        //                {
        //                    row.Cells[1].Value = Common.EncryptionDecryption.Encrypt(row.Cells[1].Value.ToString());
        //                }
        //                else if (row.Cells[0].Value.Equals("SYNC_PASSWORD"))
        //                {
        //                    row.Cells[1].Value = Common.EncryptionDecryption.Encrypt(row.Cells[1].Value.ToString());
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        private void AssignEvents()
        {
            ADGVSysParam.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVSysParam.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }
        private void txtParamName_TextChanged(object sender, EventArgs e)
       {
            BindingSource bs = new BindingSource();
            bs.DataSource = ADGVSysParam.DataSource;
            bs.Filter = ADGVSysParam.Columns[0].HeaderText.ToString() + " LIKE '%" + txtParamName.Text.ToString() + "%'";
            ADGVSysParam.DataSource = WinForm.FromBindingSourceToDataTable(bs);
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        DataTable dt = new DataTable();
        //        dt = ADGVSysParam.DataSource as DataTable;
        //        Info.SysParam objSysParam = new Info.SysParam();
        //        bool flag=false;
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dtRows in dt.Rows)
        //            {
        //                objSysParam.PRM_Name = dtRows[0].ToString();
        //                objSysParam.PRM_Value = dtRows[1].ToString();


        //               flag=BLL.SystemParameterHandler.updateSystemParam(objSysParam);
                       

        //            }
        //            if (flag)
        //            {
        //                SysParam.loadSystemParameter();
        //                UICommon.WinForm.showStatus("Updated SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //            }
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("No Record to Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    } 
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Common.ImportExport.ImportToExcel(ADGVSysParam);
        //     }
        //    catch (Exception ex)
        //    {
        //        UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
              
        //    }
        //}

        private void ADGVSysParam_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVSysParam,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Common.ImportExport.ImportToExcel(ADGVSysParam,null);
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ADGVSysParam.DataSource as DataTable;
               
                Info.SysParam objSysParam = new Info.SysParam();
                bool flag = false;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtRows in dt.Rows)
                    {
                        objSysParam.PRM_Name = dtRows[0].ToString();
                        objSysParam.PRM_Value = dtRows[1].ToString();


                        flag = BLL.SystemParameterHandler.updateSystemParam(objSysParam);
                        //Info.SysParam.loadSystemParameter(Convert.ToInt16(branchId));

                    }
                    if (flag)
                    {
                        BLL.SystemParameterHandler.loadSystemParameter(Convert.ToInt16(branchId));

                        BLL.SystemParameterHandler.loadSystemParameter();
                        UICommon.WinForm.showStatus("Updated SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                        //encryptPassword();
                    }
                }
                else
                {
                    UICommon.WinForm.showStatus("No Record to Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);

                }
            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, "Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }
        
        private void ADGVSysParam_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
               
             
            }

            catch (Exception ex)
            {
                WinForm.showError(ex, sCaption, this);
            }
        }

        private void ADGVSysParam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ////if (e.ColumnIndex == ADGVSysParam.Columns["PRM_Value"].Index)
            ////{
            ////    ADGVSysParam.Columns["PRM_Value"].ReadOnly = false;
            ////}
            //if (ADGVSysParam.Columns.Contains("PRM_Value") == true)
            //{
            //    ADGVSysParam.ReadOnly = false;
            //    ADGVSysParam.Columns["PRM_Value"].ReadOnly = false;

            //}
        }

        private void ADGVSysParam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (ADGVSysParam.Columns.Contains("PRM_Value") == true)
            //{
            //    ADGVSysParam.ReadOnly = false;
            //    ADGVSysParam.Columns["PRM_Value"].ReadOnly = false;

            //}
        }
    }
}
