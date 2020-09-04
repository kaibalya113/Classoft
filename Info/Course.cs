using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class Course
    {
        public Standard Standard { get; set; }
        public Batch Batch { get; set; }
        public DateTime AdmissinoDate { get; set; }
        public string RollNo { get; set; }
        public decimal OutstandingFees { get; set; }
        public decimal CourseFees { get; set; }
        public decimal Discount
        {
            get; set;
        }

        public Course()
        {
            Standard = new Standard();
            Batch = new Batch();
        }

        public Course(Standard standard, Batch batch)
        {
            this.Standard = standard;
            this.Batch = batch;
        }
        enum ColumnName
        {
            STAM_ROLL_NO,
            STAM_ADMISSION_DATE
        }
        public static List<Course> getCourse(DataTable dtCources)
        {
            List<Course> courses = new List<Course>();

            foreach (DataRow dr in dtCources.Rows)
            {
                Course course = new Course();
                course.Standard = Standard.getStandard(dr);
                course.Batch = Batch.GetBatch(dr);
               
                courses.Add(course);
                course.AdmissinoDate = EntityManager.getValue<DateTime>(dr, ColumnName.STAM_ADMISSION_DATE.ToString());
                course.RollNo = EntityManager.getValue<string>(dr, ColumnName.STAM_ROLL_NO.ToString());
            }

            return courses;
        }
    }
}
