using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ClassManager.Info
{
    [Serializable]
    public class StudentMaster
    {
        public Image ImgPhoto { get; set; }
        public int AdmissionNo { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FathersOccupation { get; set; }
        public string MothersOccupation { get; set; }
        public string FatherContactNo { get; set; }
        public string MotherContactNo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public Standard AdmissionStandard { get; set; }
        public string PhotoURL { get; set; }
        public Enquiry Enquiry { get; set; }
        public string AcadmicInfo { get; set; }
        public string ClgName { get; set; }
        public string EmailID { get; set; }
        public int BiometricId { get; set; }
        public Branch Branch { get; set; }
        public string SchoolName { get; set; }
        public string MembershipNo { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string isDeactivated { get; set; }
        public string AdharCard { get; set; }
        public string Remark {get; set;}
        public int batchID{get;set;}
        public string RollNo { get; set;}
        public string BloodGroup { get; set; }
         public string Weight { get; set; }
        public string BMI { get; set; }
        public string Height { get; set; }
        public string Reference { get; set; }
        public string Category { get; set; }
        public string counselor { get; set; }
        public string GSTNo { get; set; }
        public string HeathIssue{ get; set; }
        public string Source { get; set; }
        public StudentMaster()
        {
            Branch = new Branch();
            AdmissionStandard = new Standard();
        }

        public string DisplayName
        {
            get
            {
                return Fname + " " + Mname + " " + Lname;
            }            
        }
        public string ParentName
        {
            get
            {
                return Mname + " " + Lname;
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
