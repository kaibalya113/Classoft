
//added by ashvini for measurement on 21-01-2019

using ClassManager.Info;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Info
{
    [Serializable]
    public class Measurement
    {

        public int AdmissionNo { get; set; }

        public DateTime Date { get; set; }

        public Decimal Weight { get; set; }
        public Decimal height { get; set; }
        public Decimal BMI { get; set; }
        public Decimal FAT { get; set; }
        public Decimal neck { get; set; }
        public Decimal shoulder { get; set; }
        public Decimal chest { get; set; }
        public Decimal arms { get; set; }
        public Decimal hips { get; set; }
        public Decimal thigh { get; set; }
        public Decimal calves { get; set; }
        public Decimal forearms { get; set; }
        public Decimal upper_abd { get; set; }
        public Decimal lower_abd { get; set; }
        public Decimal waist { get; set; }


        enum ColumnName
        {
            MM_ID,
            MM_DATE,
            MM_ADMISSION_NO,
            MM_WEIGHT,
            MM_BMI,
            MM_HEIGHT,
            MM_FAT,
            MM_NECK,
            MM_SHOULDER,
            MM_CHEST,
            MM_ARMS,
            MM_HIPS,
            MM_THIGH,
            MM_CALVES,
            MM_FOREARMS,
            MM_UPPER_ABD,
            MM_LOWER_ABD,
            MM_WAIST

        }

       
        public static Measurement getMeasurements(System.Data.DataRow drStudent)

        {
            try
            {
                Measurement objMeasure = new Measurement();
                objMeasure.AdmissionNo = EntityManager.getValue<Int32>(drStudent, ColumnName.MM_ADMISSION_NO.ToString());           
                objMeasure.Date = EntityManager.getValue<DateTime>(drStudent, ColumnName.MM_DATE.ToString());           
                objMeasure.BMI = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_BMI.ToString());
                objMeasure.height = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_HEIGHT.ToString());
                objMeasure.Weight = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_WEIGHT.ToString());
                objMeasure.FAT = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_FAT.ToString());
                objMeasure.neck = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_NECK.ToString());
                objMeasure.shoulder = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_SHOULDER.ToString());
                objMeasure.chest = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_CHEST.ToString());
                objMeasure.arms = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_ARMS.ToString());
                objMeasure.hips = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_HIPS.ToString());
                objMeasure.thigh = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_THIGH.ToString());
                objMeasure.calves = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_CALVES.ToString());
                objMeasure.forearms = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_FOREARMS.ToString());
                objMeasure.upper_abd = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_UPPER_ABD.ToString());
                objMeasure.lower_abd = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_LOWER_ABD.ToString());
                objMeasure.waist = EntityManager.getValue<decimal>(drStudent, ColumnName.MM_WAIST.ToString());
                return objMeasure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Measurement> getMeasurements(DataTable dtStudents)
        {
            try
            {
                List<Measurement> lstStudents = new List<Measurement>();

                foreach (DataRow drStudent in dtStudents.Rows)
                {
                    lstStudents.Add(getMeasurements(drStudent));
                }

                return lstStudents;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AdmisionNo
        {
            get
            {
                return AdmissionNo;
            }
        }

    }
}
//end by ashvini 21-01-019