using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace ClassManager.Common
{
    public class ClsCommon
    {
        public static int branchId;
        public  const string DefaultSACCode = "999293";

        public static void ClearSpace(Control control)
        {
            try
            {
                foreach (Control c in control.Controls)
                {
                    var textBox = c as TextBox;
                    var comboBox = c as ComboBox;

                    if (textBox != null)
                        (textBox).Clear();

                    if (comboBox != null)
                        comboBox.SelectedIndex = -1;

                    if (c.HasChildren)
                        ClearSpace(c);
                }
            }
            catch { }
        }
    }
}
