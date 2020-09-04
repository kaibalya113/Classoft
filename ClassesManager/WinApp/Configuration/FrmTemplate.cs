using ClassManager.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmTemplate : FrmParentForm
    {
        RolePrivilege formPrevileges;
        string sCaption = "Templates";
        public FrmTemplate()
        {
            InitializeComponent();
        }

        private void NewTemplate_Load(object sender, EventArgs e)

        {
            try
            {
                ADGVTemplate.DataSource = BLL.TemplateHandler.getTemplate();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
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


        private void AssignEvents()
        {
            ADGVTemplate.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVTemplate.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }
        private void txtTempType_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ADGVTemplate.DataSource;
            bs.Filter = ADGVTemplate.Columns[1].HeaderText.ToString() + " LIKE '%" + txtTempType.Text.ToString() + "%'";
            ADGVTemplate.DataSource = WinForm.FromBindingSourceToDataTable(bs);
            
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{

        //    DataTable dt = new DataTable();
        //    dt = ADGVTemplate.DataSource as DataTable;
        //    Info.Template objtemplate = new Info.Template();
        //    bool flag = false;
          
        //        foreach (DataRow dtRows in dt.Rows)
        //        {
        //            objtemplate.Template_name = dtRows[1].ToString();
        //            objtemplate.Template_text = dtRows[2].ToString();


        //            flag = BLL.TemplateHandler.updateTemplates(objtemplate);
        //        flag = true;

        //        }
        //        if (flag==true)
        //        {
        //            UICommon.WinForm.showStatus("Updated SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        }
         
        //    else
        //    {
        //        UICommon.WinForm.showStatus("No Record to Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ADGVTemplate.Rows.Count != 0)
        //        {
        //            Common.ImportExport.ImportToExcel(ADGVTemplate);
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
        //    }
        //}

       private void ADGVTemplate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                formatADGVTemplate();
                foreach (DataGridViewRow adrow in ADGVTemplate.Rows)
                {

                    adrow.Height = 30;
                    adrow.MinimumHeight = 30;

                }

              ADGVTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void formatADGVTemplate()
        {
            try
            {
                ADGVTemplate.Columns["TEMP_UPDT_AT"].Visible = false;
                ADGVTemplate.Columns["TEMP_BRANCH_ID"].Visible = false;
                ADGVTemplate.Columns["TEMP_CRTD_AT"].Visible = false;
                ADGVTemplate.Columns["TEMP_DLTD_AT"].Visible = false;
                ADGVTemplate.Columns["TEMP_CRTD_BY"].Visible = false;
                ADGVTemplate.Columns["TEMP_UPDAT_BY"].Visible = false;
                ADGVTemplate.Columns["TEMP_DLTD_BY"].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ADGVTemplate_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            UICommon.WinForm.ADGVSerialNo(ADGVTemplate,e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ADGVTemplate.DataSource as DataTable;
                Info.Template objtemplate = new Info.Template();
                bool flag = false;

                foreach (DataRow dtRows in dt.Rows)
                {
                    objtemplate.Template_name = dtRows[1].ToString();
                    objtemplate.Template_text = dtRows[2].ToString();


                    flag = BLL.TemplateHandler.updateTemplates(objtemplate);
                    flag = true;

                }
                if (flag == true)
                {
                    UICommon.WinForm.showStatus("Updated SuccessFully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }

                else
                {
                    UICommon.WinForm.showStatus("No Record to Save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ADGVTemplate.Rows.Count != 0)
                {
                    Common.ImportExport.ImportToExcel(ADGVTemplate,null);
                }
                else
                {
                    UICommon.WinForm.showStatus("No records to save", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, "Please Install Excel So that Document can be Saved,Error Occured, Please Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, this);
            }
        }

       
    }
}
