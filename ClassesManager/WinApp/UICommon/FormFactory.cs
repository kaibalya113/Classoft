using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MaterialSkin;


namespace ClassManager.WinApp.UICommon
{

    static class FormFactory
    {
        public static List<Info.FunctionMaster> functionMaster;
        static Dictionary<Forms, Form> FormCollection;
        static MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        public static System.Windows.Forms.Form GetForm(Forms formName, System.Windows.Forms.Form Parent = null, bool showModal = false,string[] assemblyName=null,string isFree= null)
        {
            Form requestedForm = null;

            if (FormCollection == null || FormCollection.Count == 0){
                FormCollection = new Dictionary<Forms, Form>();
                functionMaster = BLL.FunctionHandller.getFunctionMaster();
            }

            if (FormCollection.ContainsKey(formName) == true)
            {
                requestedForm = FormCollection[formName];
            }
           
            if (requestedForm == null || requestedForm.IsDisposed)
            {   
                StringBuilder assemblyToLoad =  new StringBuilder("ClassManager.WinApp.");

                Info.FunctionMaster formFunctionMaster = functionMaster.Find(f => f.FormClass!=null && f.FormClass.Trim()== formName.ToString());
                String appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);

                if (formFunctionMaster != null && (appName.Equals("Dance") || appName.Equals("Asset") || appName.Equals("Gym")) && !formFunctionMaster.FormAssembly.Equals("ClassesManager.WinApp"))
                {
                    assemblyToLoad.Append(formFunctionMaster.FormAssembly).Append(".");
                }

                Type CAType = Type.GetType(assemblyToLoad + formName.ToString());
                requestedForm = (Form)Activator.CreateInstance(CAType);
                formatForm(requestedForm);
                requestedForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainForm_FormClosing);

               
                //materialSkinManager.AddFormToManage(requestedForm as MaterialSkin.Controls.MaterialForm);
                //materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                //materialSkinManager.ColorScheme = new ColorScheme(Primary.Amber800, Primary.Amber800, Primary.Amber800, Accent.LightBlue200, TextShade.WHITE);
                
                if (FormCollection.ContainsKey(formName))
                {
                    FormCollection[formName] = requestedForm;
                }
                else
                {
                    FormCollection.Add(formName, requestedForm);
                }
            }

            if (!requestedForm.IsMdiContainer && showModal == false)
            {
                requestedForm.MdiParent = (Parent == null) ? FormCollection[Forms.FrmMainForm] : Parent;
            }
            else
            {
                requestedForm.MdiParent = null;
            }

            requestedForm.Tag = functionMaster.Where(fm => fm.FormClass == formName.ToString()).Select(f => f.ID).FirstOrDefault();

            //requestedForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           
            return requestedForm; 
        }

        public static void formatForm(Form objForm)
        {
            //objForm.BackColor = Color.FromArgb(52, 75, 104);

            //foreach (Control objCntr in AllSubControls(objForm))
            //{
            //    if (objCntr is DateTimePicker)
            //    {
            //        DateTimePicker dateTimePicker = objCntr as DateTimePicker;
            //        dateTimePicker.Format = DateTimePickerFormat.Custom;
            //        if (dateTimePicker.CustomFormat == null)
            //        {
            //            dateTimePicker.CustomFormat = "dd-MMM-yy";
            //        }
            //    }
            //}

        }

        private static List<Control> AllSubControls(Control control)
        {
            var list = control.Controls.OfType<Control>().ToList();
            var deep = list.Where(o => o.Controls.Count > 0).SelectMany(AllSubControls).ToList();
            list.AddRange(deep);
            return list;
        }

        public static void MakeNull(Forms form)
        {
            Form requestedForm = FormCollection[form];
            requestedForm.Dispose();
            requestedForm = null;
        }

        public static void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {   
            MakeNull((Forms) Enum.Parse(typeof(Forms), ((Form)(sender)).GetType().Name));
        }

        internal static void setMainFormStatus(string statusMessage)
        {
            FrmMainForm objMainForm = FormCollection[Forms.FrmMainForm] as FrmMainForm;
            objMainForm.setStatus(statusMessage);
        }
    }

}
