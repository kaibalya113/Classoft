using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace ClassManager.Info
{
    [Serializable]
    public class Faculty
    {
       
        public string Name { get; set; }
     
        public int FacultyID { get; set; }

        public string ContactNo { get; set; }

        public string EmailId { get; set; }

        public string Address { get; set; }

        public string SpecializationIn { get; set; }

        public string StreamName { get; set; }

        public string CourseList { get; set; }
        public Int64 BiometricId { get; set; }
     
       public DateTime DOb { get; set; }
        public string[] Courses { get; set; }
        public string Pancard { get; set;}
        public Image ImgPhoto { get; set; }
        public string AdharCard { get; set;}
        public string Resume { get; set; }
        public string Qualification { get; set;}
        public string PhotoURL { get; set; }
        public string AddressProof { get; set; }
        public string IDPROOF { get; set; }
        public static List<Faculty> getFaculties(DataTable dtFaculty)
        {
            try
            {
                List<Faculty> lstFaculty = new List<Faculty>();

                foreach (DataRow drFaculty in dtFaculty.Rows)
                {
                    lstFaculty.Add(getFaculty(drFaculty));
                }

                return lstFaculty;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        

        enum ColumnName
        {
            FCLT_ID,
            FCLT_NAME,
            FCLT_CONTACT_NO,
            FCLT_EMAIL_ID,
            FCLT_ADDRESS,
            FCLT_SPECIALIZATION,
            FCLT_BRANCH_ID,
            FCLT_BIOMETRIC_ID,
            FCLT_DOB,
            FCLT_PANCARD_NO,
            FCLT_ADHARCARD_NO,
            FCLT_RESUME,
            FCLT_QUALIFICATION,
            FCLT_PHOTO_PATH,
            FCLT_IDPROOF,
            FCLT_ADDRESSPROOF


        }

        public static Faculty getFaculty(DataRow drFaculties)
        {
            try
                {

                    Faculty objFaculty = new Faculty();
                
                objFaculty.FacultyID = EntityManager.getValue<Int32>(drFaculties, ColumnName.FCLT_ID.ToString());

                if (drFaculties.Table.Columns.Contains("NAME") && drFaculties["NAME"] != DBNull.Value)
                {
                    objFaculty.Name = drFaculties["NAME"].ToString();
                }
                objFaculty.Name = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_NAME.ToString());
                
                objFaculty.Address = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_ADDRESS.ToString());
                
                objFaculty.ContactNo= EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_CONTACT_NO.ToString());
               
                objFaculty.EmailId = EntityManager.getValue<String>(drFaculties, ColumnName.FCLT_EMAIL_ID.ToString());
                objFaculty.branchId = EntityManager.getValue<Int32>(drFaculties, ColumnName.FCLT_BRANCH_ID.ToString());
                objFaculty.BiometricId= EntityManager.getValue<Int32>(drFaculties, ColumnName.FCLT_BIOMETRIC_ID.ToString());
                objFaculty.Pancard = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_PANCARD_NO.ToString());
                objFaculty.AdharCard = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_ADHARCARD_NO.ToString());
                objFaculty.Resume = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_RESUME.ToString());
                objFaculty.Qualification = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_QUALIFICATION.ToString());
                objFaculty.PhotoURL = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_PHOTO_PATH.ToString());
                objFaculty.DOb = EntityManager.getValue<DateTime>(drFaculties, ColumnName.FCLT_DOB.ToString());
                objFaculty.AddressProof = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_ADDRESSPROOF.ToString());
                objFaculty.IDPROOF = EntityManager.getValue<string>(drFaculties, ColumnName.FCLT_IDPROOF.ToString());
                return objFaculty;
                
                }

            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public Int32 branchId { get; set; }

        public Int64 biometricId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
