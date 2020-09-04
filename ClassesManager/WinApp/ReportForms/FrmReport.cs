using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.Info.Reporting;
using ClassManager.BLL;
using ClassManager.Info;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmReport : FrmParentForm
    {
        const String sCaption = "Reports"; 

        public FrmReport()
        {
            InitializeComponent();
        }
        public bool validate()
        {
            try
            {
                if (cmBxSlcType.SelectedIndex == -1)
                {
                    UICommon.WinForm.showStatus("Please select type of the report.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
                    return false;
                }
                else if (dtFrmDte.Value > dtToDte.Value)
                {
                    UICommon.WinForm.showStatus("Please select date properly.", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, this);
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

        //private void btnShow_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (validate())
        //        {
        //            PrintingConfig objPrintngConfig = new PrintingConfig();
        //            objPrintngConfig.ViewReport = true;
        //            objPrintngConfig.SaveReport = true;
        //            objPrintngConfig.exportFormat = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;

        //            CommonReportData CommonRprtData = new CommonReportData();
        //            CommonRprtData.FromDate = dtFrmDte.Value;
        //            CommonRprtData.ToDate = dtToDte.Value;
        //            CommonRprtData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.CLASS_NAME);
        //            CommonRprtData.ClassSubName = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_CLASSNAME);
        //            CommonRprtData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.CLASSES_FULL_ADDRESS);
        //            CommonRprtData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.CLASSES_NOTE);
        //            CommonRprtData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
        //            CommonRprtData.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), cmBxSlcType.Text);

        //            FrmReportViewer frmRprtViewer = UICommon.FormFactory.GetForm(UICommon.Forms.FrmReportViewer) as FrmReportViewer;
        //            frmRprtViewer.viewReport(CommonRprtData.ReportName, CommonRprtData, objPrintngConfig);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void FrmReport_Load(object sender, EventArgs e)
        {
            try
            {
                formatForm();
            }
            catch (Exception ex)
            {
                UICommon.WinForm.checkInternetConnection(ex, sCaption, this);
            }
        }

        private void formatForm()
        {
            try
            {
                UICommon.WinForm.formatDateTimePicker(dtFrmDte);
                UICommon.WinForm.formatDateTimePicker(dtToDte);
                this.Text = sCaption;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (validate())
                {
                    PrintingConfig objPrintngConfig = new PrintingConfig();
                    objPrintngConfig.ViewReport = true;
                    objPrintngConfig.SaveReport = true;
                    objPrintngConfig.exportFormat = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;

                    CommonReportData CommonRprtData = new CommonReportData();
                    CommonRprtData.FromDate = dtFrmDte.Value;
                    CommonRprtData.ToDate = dtToDte.Value;
                    CommonRprtData.ClassName = Info.SysParam.getValue<String>(SysParam.Parameters.NAME);
                    CommonRprtData.ClassSubName = Info.SysParam.getValue<String>(SysParam.Parameters.SUB_NAME);
                    CommonRprtData.ClassAddress = Info.SysParam.getValue<String>(SysParam.Parameters.FULL_ADDRESS);
                    CommonRprtData.ClassNote = Info.SysParam.getValue<String>(SysParam.Parameters.NOTE);
                    CommonRprtData.Logo = Info.SysParam.getValue<String>(SysParam.Parameters.LOGO_PATH);
                    CommonRprtData.ReportName = (Info.Reports)Enum.Parse(typeof(Info.Reports), cmBxSlcType.Text);

                    FrmReportViewer frmRprtViewer = UICommon.FormFactory.GetForm(UICommon.Forms.FrmReportViewer) as FrmReportViewer;
                    frmRprtViewer.viewReport(CommonRprtData.ReportName, CommonRprtData, objPrintngConfig);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
