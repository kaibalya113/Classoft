
//added by ashvini for getting measurement of a student on 21-01-2019
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManager.BLL;
using ClassManager.WinApp.UICommon;
using ClassManager.Info;

namespace ClassManager.WinApp.Gym
{
    public partial class FrmMeasurement : FrmParentForm
    {
        public static Info.Student objStudent;
        bool picture = false;
        public Info.Measurement objMeasure;

        public string sCaption = "Measurement";
        private Student objStuden;

        public FrmMeasurement()
        {
            InitializeComponent();
        }

        public void setValue(Student objStudent)
        {
            try
            {
                this.objStuden = objStudent;
                lbladno.Text = objStudent.AdmissionNo.ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            try
            {
                setValue(objStuden);
         
                objMeasure = new Info.Measurement();

                

                if (txtWght.Text == "")
                {
                    txtWght.Text = "0";
                }
                else
                {
                    objMeasure.Weight = Convert.ToDecimal(txtWght.Text);
                }

                if (txtHeight.Text == "")
                {
                    txtHeight.Text = "0";
                }
                else
                {
                    objMeasure.height = Convert.ToDecimal(txtHeight.Text);
                }
                if(txtHeight.Text=="0" ||txtWght.Text=="0")
                {
                    txtBMI.Text = "0";
                }
            
                else
                {
                    objMeasure.BMI = Convert.ToDecimal(txtBMI.Text);
                }



                if (txtarms.Text == "")
                {
                    txtarms.Text = "0";
                }
                else
                {
                    objMeasure.arms = Convert.ToDecimal(txtarms.Text);
                }
                if (txtcalves.Text == "")
                {
                    txtcalves.Text = "0";
                }
                else
                {
                    objMeasure.calves = Convert.ToDecimal(txtcalves.Text);
                }
                if (txtchest.Text == "")
                {
                    txtchest.Text = "0";
                }
                else
                {
                    objMeasure.chest = Convert.ToDecimal(txtchest.Text);
                }

                if (txtthigh.Text == "")
                {
                    txtthigh.Text = "0";
                }
                else
                {
                    objMeasure.thigh = Convert.ToDecimal(txtthigh.Text);
                }


                objMeasure.AdmissionNo =Convert.ToInt32( lbladno.Text);

                if (txtlower.Text == "")
                {
                    txtlower.Text = "0";
                }
                else
                {
                    objMeasure.lower_abd = Convert.ToDecimal(txtlower.Text);
                }
                if (txtfat.Text == "")
                {
                    txtfat.Text = "0";
                }
                else
                {
                    objMeasure.FAT = Convert.ToDecimal(txtfat.Text);
                }
                if (txtwaist.Text == "")
                {
                    txtwaist.Text = "0";
                }
                else
                {
                    objMeasure.waist = Convert.ToDecimal(txtwaist.Text);
                }
                if (txtsholder.Text == "")
                {
                    txtsholder.Text = "0";
                }
                else
                {
                    objMeasure.shoulder = Convert.ToDecimal(txtsholder.Text);
                }

                if (txtneck.Text == "")
                {
                    txtneck.Text = "0";
                }
                else
                {
                    objMeasure.neck = Convert.ToDecimal(txtneck.Text);

                }
                if (txtupper.Text == "")
                {
                    txtupper.Text = "0";
                }
                else
                {
                    objMeasure.upper_abd = Convert.ToDecimal(txtupper.Text);
                }

                objMeasure.Date = dtpDate.Value;

                if (txtWght.Text == "")
                {
                    txtWght.Text = "0";
                }
                else
                {
                    objMeasure.Weight = Convert.ToDecimal(txtWght.Text);
                }
                if (txtchest.Text == "")
                {
                    txtchest.Text = "0";
                }
                else
                {
                    objMeasure.chest = Convert.ToDecimal(txtchest.Text);
                }


                if (txtforearms.Text == "")
                {
                    txtforearms.Text = "0";
                }
                else
                {
                    objMeasure.forearms = Convert.ToDecimal(txtforearms.Text);
                }

              
                StudentHandller.getmeasurements(objMeasure, Program.LoggedInUser.BranchId);

                UICommon.WinForm.showStatus("Measurement added successfully ",null,null);
                clearForm();
                //  this.Close();
               



            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void AssignEvents()
        {

            txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtWght.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtarms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtBMI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtcalves.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtchest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtfat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtforearms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txthips.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtthigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtneck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtlower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtupper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtsholder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);
            txtwaist.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.Events.decimalOnly);

        }

        private void clearForm()
        {


            txtHeight.Clear();
            txtWght.Clear();
            txtarms.Text = "";
            txtBMI.Text = "";
            txtcalves.Text = "";
            txtchest.Text = "";
            txtfat.Text = "";
            txtforearms.Text = "";
            txthips.Text = "";
            txtneck.Text = "";
            txtthigh.Text = "";
            txtlower.Text = "";
            txtupper.Text = "";
            txthips.Text = "";
            txtsholder.Text = "";
            txtwaist.Text = "";



        }

        private void FrmMeasurement_Load(object sender, EventArgs e)
        {

            AssignEvents();

        }

        private void formatForm()
        {
            try
            {

                UICommon.WinForm.formatDateTimePicker(dtpDate, Common.Formatter.DateFormat);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmdPDReset_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void txtWght_TextChanged(object sender, EventArgs e)
        {

            try
            {
                double weight;
                double height;
                double BMI;
                if (txtHeight.Text == "")
                {
                    txtBMI.Text = "";
                }
                else if (txtHeight.Text.Length != 0 && txtWght.Text.Length != 0)
                {

                    weight = Convert.ToDouble(txtWght.Text);
                    height = Convert.ToDouble(txtHeight.Text);
                    BMI = Convert.ToDouble(weight / (height * height));
                    //String.Format("{0:0.00}", BMI.ToString());
                    BMI = System.Math.Round(BMI, 2);
                    txtBMI.Text = BMI.ToString();
                    txtBMI.Enabled = false;

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double weight;
                double height;
                double BMI;
                if (txtHeight.Text == "")
                {
                    txtBMI.Text = "";
                }
                else if (txtHeight.Text.Length != 0 && txtWght.Text.Length != 0)
                {

                    weight = Convert.ToDouble(txtWght.Text);
                    height = Convert.ToDouble(txtHeight.Text);
                    BMI = Convert.ToDouble(weight / (height * height));
                    //String.Format("{0:0.00}", BMI.ToString());
                    BMI = System.Math.Round(BMI, 2);
                    txtBMI.Text = BMI.ToString();
                    txtBMI.Enabled = false;

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}

//end by ashvini 21-01-2019
