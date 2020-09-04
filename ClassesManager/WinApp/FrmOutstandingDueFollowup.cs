using ClassManager.WinApp.UICommon;
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
    public partial class FrmOutstandingDueFollowup : FrmParentForm
    {
        string sCaption = "Student Outstanding Due Details";

        public FrmOutstandingDueFollowup()
        {
            InitializeComponent();
        }

        private void cmbViewFollowUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDetails(cmbViewFollowUp.SelectedIndex);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                UICommon.WinForm.showError(ex, sCaption, this, "Oops something went. Please contact support.");
            }

        }

        private void loadDetails(int selectedIndex)
        {
            try
            {
                ADGVDueFollowup.DataSource = getDetails(selectedIndex);
                formatADGVFollowUp();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static DataTable getDetails(int index)
        {
            DataTable data = new DataTable();
            if (index == 1)
            {
                data = BLL.FollowupHandler.getFollowupdue(System.DateTime.Now.AddDays(-1), 1, BLL.DBHandller.getMinSQLDate());
            }
            else if (index == 0)
            {
                data = BLL.FollowupHandler.getFollowupdue(System.DateTime.Now, 0, System.DateTime.Now);

            }
            else if (index == 2)
            {
                data = BLL.FollowupHandler.getFollowupdue(System.DateTime.Now.AddDays(8), 2, System.DateTime.Now.Date.AddDays(1));
            }

            return data;
        }

        private void FrmOutstandingDueFollowup_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCheckBoxColumn isFollowpClosed = new DataGridViewCheckBoxColumn();
                isFollowpClosed.Name = "chkbxisClosed";
                isFollowpClosed.HeaderText = "Close";
                isFollowpClosed.Width = 60;
                ADGVDueFollowup.Columns.Insert(0, isFollowpClosed);
                cmbViewFollowUp.SelectedIndex = 0;

                int view =  chooseView(); 
                if(view != -1)
                {
                    loadDetails(view);
                }
                else
                {
                    loadDetails(1);
                }


            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
            
        }

        public static int chooseView()
        {
            try
            {
                DataTable dt = getDetails(0);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return 0;
                }
                else
                {
                    dt = getDetails(2);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        return 2;
                    }
                    else
                    {
                        return -1;
                    }
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex);
                throw;
            }
        }

        private void formatADGVFollowUp()
        {
            try
            {
                ADGVDueFollowup.Columns["ID"].Width = 100;
                ADGVDueFollowup.Columns["Description"].Width = 300;
                ADGVDueFollowup.Columns["FOLU_STATUS"].Visible = false;
                ADGVDueFollowup.Columns["FOLU_ID"].Visible = false;
                ADGVDueFollowup.Columns["chkbxisClosed"].Width = 100;

                ADGVDueFollowup.Columns["FOLU_ID"].Visible = false;
                //Formatting Date.
                ADGVDueFollowup.Columns["Due Date"].DefaultCellStyle = UICommon.WinForm.GridDateFormat; ;

                ADGVDueFollowup.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                foreach (DataGridViewRow check in ADGVDueFollowup.Rows)
                {
                    if (Convert.ToString(check.Cells["FOLU_STATUS"].Value) == "CLOSE")
                    {
                        check.Cells[0].Value = true;
                    }
                }

            }
            catch (Exception ex)
            {
                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
        private void ADGVDueFollowup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (BLL.FollowupHandler.updateFollowStatus(Convert.ToInt32(ADGVDueFollowup.Rows[e.RowIndex].Cells[1].Value), Convert.ToBoolean(ADGVDueFollowup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true ? "OPEN" : "CLOSE"))
                    {
                        UICommon.WinForm.showStatus("Status Updated", sCaption, this);
                        loadDetails(cmbViewFollowUp.SelectedIndex);
                    }
                }
            }
            catch (Exception ex)
            {

                UICommon.WinForm.showError(ex, sCaption, this);
            }
        }
    }
}
