using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ClassManager.Common
{
    public class Events
    {
        private const string stringRegx = "[abcdefghijklmnopqrstuvwxyz]*";

        public static void charOnly(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < 65 || e.KeyChar > 90) && (e.KeyChar < 97 || e.KeyChar > 122) && e.KeyChar != 8 && e.KeyChar != 32)
                {
                    e.Handled = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void filterGridView(object sender, EventArgs e)
        {
            try
            {
                ADGV.AdvancedDataGridView gridView = (ADGV.AdvancedDataGridView)sender;
                BindingSource bs = new BindingSource();
                bs.DataSource = gridView.DataSource;
                string s = gridView.FilterString;

                bs.Filter = s;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void sortGridView(object sender, EventArgs e)
        {
            try
            {
                ADGV.AdvancedDataGridView gridView = (ADGV.AdvancedDataGridView)sender;
                BindingSource bs = new BindingSource();
                bs.DataSource = gridView.DataSource;
                bs.Sort = gridView.SortString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void numOnly(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                {
                    e.Handled = true;
                }
                //else if(!(char.IsNumber(e.KeyChar)&&char.IsControl(e.KeyChar)))
                //{
                //    e.Handled = true;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void decimalOnly(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                else
                {
                    // only allow one decimal point
                    if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void upperCharOnly(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < 65 || e.KeyChar > 90) && (e.KeyChar < 97 || e.KeyChar > 122) && e.KeyChar != 8 && e.KeyChar != 32)
                {
                    e.Handled = true;
                }
                else
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool validateString(string strToValidate)
        {
            if (strToValidate.Length != 0 && Regex.Match(strToValidate, stringRegx).Success)
                return true;
            return false;
        }

        public static void valPercentageValue(object sender, System.EventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if ((txtBox.Text.Length > 0))
            {
                if (Convert.ToSingle(txtBox.Text) > 100)
                {
                    txtBox.Text = "";

                }
            }


        }
        public static void valYearValue(object sender, System.EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text.Length > 0)
            {

                if (Convert.ToInt32(txtBox.Text) > 2020)
                {
                    txtBox.Text = "";

                }
            }
        }

        public static void feesGriedview(object sender, EventArgs e)
        {
           
        }
    }
}