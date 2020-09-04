using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ClassManager.Info;
using System.Data;
using System.Reflection;
using ClassManager.Common;
using System.Globalization;
using ClassManager.WinApp.Gym;

namespace ClassManager.WinApp.UICommon
{
    static class WinForm
    {
        public static DataGridViewCellStyle GridDateFormat;
        public static DataGridViewCellStyle GridTimeFormat;
        public static DataGridViewCellStyle GridCurrencyFormat;



        static WinForm()
        {
            GridDateFormat = new DataGridViewCellStyle();
            GridDateFormat.Format = Common.Formatter.DateFormat;
            GridDateFormat.FormatProvider = CultureInfo.GetCultureInfo(Common.Formatter.Culture);
            GridDateFormat.NullValue = String.Empty;

            GridTimeFormat = new DataGridViewCellStyle();
            GridTimeFormat.Format = Common.Formatter.TimeFormat;
            GridTimeFormat.FormatProvider = CultureInfo.GetCultureInfo(Common.Formatter.Culture);
            GridTimeFormat.NullValue = String.Empty;

            GridCurrencyFormat = new DataGridViewCellStyle();
            GridCurrencyFormat.Format = Common.Formatter.CurrencyFormat;
            GridCurrencyFormat.FormatProvider = CultureInfo.GetCultureInfo(Common.Formatter.Culture);
            GridCurrencyFormat.NullValue = String.Empty;
        }

        /// <summary>
        /// Following function sets the focus of the Control.
        /// </summary>
        /// <param name="objControl"></param>
        public static void setFocus(Control objControl)
        {
            objControl.Focus();
        }

        public static DialogResult showStatus(string message, MessageBoxButtons button, MessageBoxIcon icon, string sCaption, Form ParentForm)
        {
            try

            {
                UICommon.FormFactory.setMainFormStatus(message);
            }
            catch (Exception ex)
            {

            }
            return MessageBox.Show(ParentForm, message, sCaption, button, icon);


        }

        public static DialogResult showMessage(string message, MessageBoxButtons button, MessageBoxIcon icon, string sCaption, Form ParentForm)
        {
            return MessageBox.Show(ParentForm, message, sCaption, button, icon);
        }

        public static DialogResult showStatus(string message, string sCaption, Form ParentForm, MessageBoxButtons button = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return showStatus(message, button, icon, sCaption, ParentForm);
        }

        public static DialogResult showError(Exception ex, string message, MessageBoxButtons button, MessageBoxIcon icon, string sCaption, Form ParentForm)
        {
            if (message == "" || message == null)
            {
                message = "Oops something went wrong, Please contact support \n Additional Information : " + ex.Message;
            }

            ClassManager.Common.Log.LogError(ex);

            return MessageBox.Show(ParentForm, message, sCaption, button, icon);
        }

        public static DialogResult showError(Exception e, string sCaption, Form ParentForm, string message = null, MessageBoxButtons button = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            return showError(e, message, button, icon, sCaption, ParentForm);
        }

        internal static void showStatus(string v, MessageBoxButtons oK, MessageBoxIcon information, object sCaption, FrmMeasurement frmMeasurement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When Internet Connection is Not Available and that Remote Name is not Resolved, then in such case, this Function is Called.
        /// </summary>
        /// <param name="sCaption"></param>
        /// <param name="ParentForm"></param>
        /// <param name="Message"></param>
        /// <param name="button"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static void showSMSError(string sCaption, Form ParentForm, string Message = "Internet Connection Not Available.", MessageBoxButtons button = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            //FrmMainForm obj = new FrmMainForm();
            //obj.setStatus("No Internet Connection Available to Send SMS.");
            //return showSMSError(sCaption, ParentForm, Message, button, icon);
            UICommon.FormFactory.setMainFormStatus("No Internet Connection Available to Send SMS from " + sCaption);
        }

        /// <summary>
        /// This Function is to Display that Message is sent or Not.
        /// </summary>
        /// <param name="isSent"></param>
        /// <param name="sCaption"></param>
        /// <param name="ParentForm"></param>
        /// <returns></returns>
        public static DialogResult dispSMSMessage(bool isSent, string sCaption, Form ParentForm)
        {
            if (isSent)
            {
                return UICommon.WinForm.showStatus("Message sent successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, ParentForm);
            }
            else
            {
                return UICommon.WinForm.showStatus("Message not sent", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, ParentForm);
            }
        }

        /// <summary>
        /// This function will be use to set the status.
        /// </summary>
        /// <param name="isSent"></param>
        /// <param name="sCaption"></param>
        /// <param name="ParentForm"></param>
        public static void setSMSStatus(bool isSent, string sCaption, Form ParentForm)
        {

            if (isSent)
            {

                UICommon.FormFactory.setMainFormStatus("Message Sent Successfully from " + sCaption);
            }
            else
            {
                UICommon.FormFactory.setMainFormStatus("Message not Sent from " + sCaption);
            }
        }

        /// <summary>
        /// This Function is for Mail Part.
        /// </summary>
        /// <param name="isSent"></param>
        /// <param name="sCaption"></param>
        /// <param name="ParentForm"></param>
        /// <returns></returns>
        public static DialogResult dispMailMessage(bool isSent, string sCaption, Form ParentForm)
        {
            if (isSent)
            {
                return UICommon.WinForm.showStatus("Mail sent successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, ParentForm);
            }
            else
            {
                return UICommon.WinForm.showStatus("Mail not sent", MessageBoxButtons.OK, MessageBoxIcon.Information, sCaption, ParentForm);
            }
        }

        /// <summary>
        /// This function is used when we click on a LinkButton and we want to open a nw Form after Clicking. Like for eg. FeesPayment Screen(Add Account LinkButton(Create Account Screen opens)). This function is especially for AddAccount LinkButton.
        /// </summary>
        /// <param name="objForm"></param>
        /// <param name="objCombo"></param>
        public static void openForm(Form objForm, ComboBox objCombo)
        {
            try
            {
                objForm.ShowDialog();
                objForm.Close();
                objCombo.DataSource = BLL.AccountHandller.getAccounts(Program.LoggedInUser.BranchId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Following Function will be used when Button Event is performed by User. So before triggering click event of button it should check the following ListBox that it contains Items or not.
        /// </summary>
        /// <param name="objListBox"></param>
        /// <param name="objButton"></param>
        public static void enableButtonOnItemCount(ListBox objListBox, Button objButton)
        {
            try
            {
                if (objListBox.Items.Count > 0)
                {
                    objButton.Enabled = true;
                }
                else
                {
                    objButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void LinkFaclty(Form objForm, ComboBox objCombobox)
        {
            try
            {
                //objForm.ShowDialog();

                UICommon.FormFactory.GetForm(UICommon.Forms.FrmFaculty).Visible = true;
                // objForm.Close();

                objCombobox.DisplayMember = "Name";
                objCombobox.ValueMember = "FacultyID";


                //objCombobox.DataSource = 
                objCombobox.Items.Clear();
                foreach (DataRow singleRow in BLL.FacultyHandler.getFaculties(Program.LoggedInUser.BranchId.ToString()).Rows)
                {
                    objCombobox.Items.Add(new ComboItem(Convert.ToInt32(singleRow[0]), singleRow[1].ToString()));
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void adjustComboWidth(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (ComboItem s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s.name, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
            senderComboBox.Width = width + 15;
        }

        public static void clearTextBoxes(System.Windows.Forms.Control containerControl, bool clearComboboxes)
        {
            foreach (System.Windows.Forms.Control control in containerControl.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    control.Text = "";
                }
                if (clearComboboxes)
                {
                    if (control is System.Windows.Forms.ComboBox)
                    {
                        control.Text = "";
                    }
                }
            }
        }

        public static void clearTextBoxes(System.Windows.Forms.Control containerControl)
        {
            foreach (System.Windows.Forms.Control control in containerControl.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    control.Text = "";
                }
            }
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            if (items == null)
            {
                return null;
            }
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            {
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names                
                    dataTable.Columns.Add(new DataColumn(prop.Name, prop.PropertyType));
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    try
                    {
                        dataTable.Rows.Add(values);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        ///Sets the From and To Date.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public static void setDate(DateTimePicker from, DateTimePicker to)
        {
            try
            {

                 from.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
               
                    
                //from.Value = new DateTime(DateTime.Now.AddMonths(-6));
                //to.Value = from.Value.AddMonths(1).AddDays(-1);
                to.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void setDateForAttendance(DateTimePicker from, DateTimePicker to)
        {
            try
            {

                from.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
               
                    DateTime today = DateTime.Now;
                    from.Value = today.AddMonths(-6);
              

                //from.Value = new DateTime(DateTime.Now.AddMonths(-6));
                //to.Value = from.Value.AddMonths(1).AddDays(-1);
                to.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void setDateb(DateTimePicker from, DateTimePicker to)
        {
            try
            {
                to.Value = DateTime.Today.AddDays(15);
                //to.Value = from.Value.AddMonths(1).AddDays(-1);
                from.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void setDateE(DateTimePicker from, DateTimePicker to)
        {
            try
            {
                from.Value = DateTime.Today.AddDays(-30);
                //to.Value = from.Value.AddMonths(1).AddDays(-1);
                to.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void setDatem(DateTimePicker from, DateTimePicker to)
        {
            try
            {
                DateTime dCalcDate = DateTime.Now;
                from.Value = DateTime.Now.Date;
                to.Value = new DateTime(dCalcDate.Year, dCalcDate.Month, DateTime.DaysInMonth(dCalcDate.Year, dCalcDate.Month));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void setDatea(DateTimePicker from, DateTimePicker to)
        {
            try
            {
                from.Value = DateTime.Now.AddDays(-15);
                //to.Value = from.Value.AddMonths(1).AddDays(-1);
                to.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void setDateforactive(DateTimePicker from, DateTimePicker to)
        {
            try
            {
                to.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 15);
                //to.Value = from.Value.AddMonths(1).AddDays(-1);
                from.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static void formatDateTimePicker(DateTimePicker dtpDate, string dateFormat = Common.Formatter.DateFormat)
        {
            try
            {
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = dateFormat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //internal static void formatDTP(DateTimePicker[] obj, string dateFormat = Common.Formatter.DateFormat)
        //{
        //    try
        //    {
        //        foreach (DateTimePicker format in obj)
        //        {
        //            format.Format = DateTimePickerFormat.Custom;
        //            format.CustomFormat = dateFormat;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Provide Serial No. to GridView.
        /// </summary>
        /// <param name="Adgv"></param>
        /// <param name="e"></param>
        public static void ADGVSerialNo(ADGV.AdvancedDataGridView Adgv, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                using (SolidBrush b = new SolidBrush(Adgv.RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void ADGVSerialNo(SuperGrid Adgv, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                Font font = new Font(e.InheritedRowStyle.Font.FontFamily, 8);
                using (SolidBrush b = new SolidBrush(Adgv.RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString((Adgv.bs.Position * Adgv.PageSize + (e.RowIndex + 1)).ToString(), font, b, e.RowBounds.Location.X + 1, e.RowBounds.Location.Y + 4);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static void checkInternetConnection(Exception ex, string sCaption, FrmParentForm form)
        {

            UICommon.WinForm.showError(ex, "Error Occured, Please check if you hav a working internet connection, Please Contact Support if problem persists.", MessageBoxButtons.OK, MessageBoxIcon.Error, sCaption, form);


        }
        //public static void ApplyPrivileges(int functionId, RolePrivilege objRolePrivileges, Control[] objControls, Form objForm)
        //{
        //    try
        //    {
        //        functionId = Convert.ToInt32(objForm.Tag.ToString());
        //        objRolePrivileges = BLL.UserHandler.loggedInUser.privileges.Where(p => p.FunctionId == functionId).FirstOrDefault();
        //        if (objRolePrivileges != null)
        //        {
        //            if (objRolePrivileges.AllBranches == false)
        //            {
        //                chkShowAllBranch.Visible = false;
        //            }

        //            if (objRolePrivileges.Modify == false)
        //            {
        //                btnUpdatePaidExp.Visible = false;
        //            }

        //            if (objRolePrivileges.Create == false)
        //            {
        //                cmdCreateExpence.Visible = false;
        //                cmdAddExpense.Visible = false;
        //                tabPCreateExpense.Hide();
        //            }

        //            if (objRolePrivileges.Delete == false)
        //            {

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        //Common Function to Assign Sort and Filter Events.Mohan(28-July-2017).
        public static void AssignFilterEvent(ADGV.AdvancedDataGridView ADGVGridView)
        {
            ADGVGridView.SortStringChanged += new System.EventHandler(Common.Events.sortGridView);
            ADGVGridView.FilterStringChanged += new System.EventHandler(Common.Events.filterGridView);
        }

        //Converting DataTable to List.Mohan(29-July-2017).
        public static List<T> ToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        //Converts Binding Source To DataTable.Mohan(31-July-2017).
        public static DataTable FromBindingSourceToDataTable(BindingSource bs)
        {
            var bsFirst = bs;
            while (bsFirst.DataSource is BindingSource)
                bsFirst = (BindingSource)bsFirst.DataSource;

            DataTable dt;
            if (bsFirst.DataSource is DataSet)
                dt = ((DataSet)bsFirst.DataSource).Tables[bsFirst.DataMember];
            else if (bsFirst.DataSource is DataTable)
                dt = (DataTable)bsFirst.DataSource;
            else
                return null;

            if (bsFirst != bs)
            {
                if (dt.DataSet == null) return null;
                dt = dt.DataSet.Relations[bs.DataMember].ChildTable;
            }

            return dt;
        }


        public static string getAppName()
        {
            String appName = SysParam.getValue<String>(SysParam.Parameters.APPLICATION_NAME);

            if (appName == Common.Constants.ASSET_APP_TYPE || appName == Common.Constants.CLASS_APP_TYPE)
            {
                return "ClassWise";
            }
            else if (appName == Common.Constants.DANCE_APP_TYPE)
            {
                return "DanceWise";
            }
            else if (appName == Common.Constants.GYM_APP_TYPE)
            {
                return "GymWise";
            }
            else
            {
                return "Accunity Services";
            }
        }

        public static void formatDateColumn(DataGridView grid,string column)
        {
            if (grid.Columns.Contains(column))
            {
                grid.Columns[column].DefaultCellStyle.Format = Common.Formatter.DateFormat;
            }
        }
    }
}
