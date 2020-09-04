using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class Student : StudentMaster
    {
        public List<Cheque> PDCs;

        public string checkinMachine { get; set; }

        public int dailyAttendanceCount { get; set; }

        public Stream Stream { get; set; }
        public List<Course> Courses { get; set; }
        public Course Course { get; set; }
        public Fees Fees { get; set; }
        public FeeStructure FeesPackage { get; set; }
        public Batch Batch { get; set; }
        public int AcadYear { get; set; }
        public string RollNo { get; set; }
        public List<StudentFacility> Facilities { get; set; }
        public string NewCourse { get; set; }
        public string SchoolName { get; set; }

        public Student()
            : base()
        {
            Stream = new Stream();
            Courses = new List<Course>();
            Fees = new Fees();
            FeesPackage = new FeeStructure();
            Batch = new Batch();
            Facilities = new List<StudentFacility>();

        }

        public Student(Info.Fees fees, int admissionNo)
        {
            // TODO: Complete member initialization
            this.Fees = fees;
            this.AdmissionNo = admissionNo;
        }

        enum ColumnName
        {
            STMT_ID,
            STMT_ADMISSION_NO,
            STMT_FNAME,
            STMT_MNAME,
            STMT_LNAME,
            STMT_ADDRESS,
            STMT_CONTACT_NO,
            STMT_GENDER,
            STMT_DOB,
            STMT_FATHER_NAME,
            STMT_MOTHER_NAME,
            STMT_FATHER_OCCUPATION,
            STMT_MOTHER_OCCUPATION,
            STMT_MOTHER_CONTACT,
            STMT_FATHER_CONTACT,
            STMT_ADMISSION_DATE,
            STMT_ADMISSION_STND,
            STMT_PHOTO_URL,
            STMT_ENQUIRY_ID,
            STMT_ACADEMIC_INFO,
            STMT_EMAIL_ID,
            STMT_BRANCH_ID,
            STMT_MEMSHIP_NO,
            STMT_DEACTIVATED,
            STMT_CRTD_AT,
            STMT_UPDT_AT,
            STMT_DLTD_AT,
            STMT_CRTD_BY,
            STMT_UPDAT_BY,
            STMT_DLTD_BY,
            ID,
            BIOM_BIOMETRIC_ID,
            STMT_BLOODGROUP,
            STMT_WEIGHT,
            STMT_BMI,
            STMT_HEIGHT,
            STMT_REMARK,
            STMT_COUNSELOR,
            STMT_REFERENCE,
            STMT_CATEGORY,
            STMT_ADHARCARD_NO,
            STMT_GST_NO,
            STMT_HEATH_ISSUE,
            STMT_SOURCE,
            STMT_SCHOOL_NAME

        }

        public override string ToString()
        {
            return this.Fname + " " + this.Lname + " (" + this.AdmissionNo + ")";
        }
        public static Student getStudent(System.Data.DataRow drStudent)

        {
            try
            {
                Student objStudent = new Student();


                objStudent.AdmissionNo = EntityManager.getValue<Int32>(drStudent, ColumnName.STMT_ADMISSION_NO.ToString());
                objStudent.ContactNo = EntityManager.getValue<string>(drStudent, ColumnName.STMT_CONTACT_NO.ToString());
                objStudent.AdmissionDate = EntityManager.getValue<DateTime>(drStudent, ColumnName.STMT_ADMISSION_DATE.ToString());
                objStudent.Fname = EntityManager.getValue<string>(drStudent, ColumnName.STMT_FNAME.ToString());
                objStudent.Lname = EntityManager.getValue<string>(drStudent, ColumnName.STMT_LNAME.ToString());
                objStudent.Mname = EntityManager.getValue<string>(drStudent, ColumnName.STMT_MNAME.ToString());
                objStudent.Gender = EntityManager.getValue<string>(drStudent, ColumnName.STMT_GENDER.ToString());
                objStudent.BiometricId = EntityManager.getValue<Int32>(drStudent, ColumnName.BIOM_BIOMETRIC_ID.ToString());
                objStudent.Dob = EntityManager.getValue<DateTime>(drStudent, ColumnName.STMT_DOB.ToString());
                objStudent.FatherContactNo = EntityManager.getValue<string>(drStudent, ColumnName.STMT_FATHER_CONTACT.ToString());
                objStudent.FatherName = EntityManager.getValue<string>(drStudent, ColumnName.STMT_FATHER_NAME.ToString());
                objStudent.EmailID = EntityManager.getValue<string>(drStudent, ColumnName.STMT_EMAIL_ID.ToString());
                objStudent.PhotoURL = EntityManager.getValue<string>(drStudent, ColumnName.STMT_PHOTO_URL.ToString());
                objStudent.Address = EntityManager.getValue<string>(drStudent, ColumnName.STMT_ADDRESS.ToString());
                objStudent.isDeactivated = EntityManager.getValue<string>(drStudent, ColumnName.STMT_DEACTIVATED.ToString());
                objStudent.MembershipNo = EntityManager.getValue<string>(drStudent, ColumnName.STMT_MEMSHIP_NO.ToString());
                objStudent.Branch = Branch.getBranch(drStudent);
                objStudent.Batch = Batch.GetBatch(drStudent);
                objStudent.Fees = Fees.getFees(drStudent);
                objStudent.Enquiry = Info.Enquiry.getEnquiry(drStudent);
                objStudent.BloodGroup = EntityManager.getValue<string>(drStudent, ColumnName.STMT_BLOODGROUP.ToString());
                objStudent.BMI = EntityManager.getValue<string>(drStudent, ColumnName.STMT_BMI.ToString());
                objStudent.Height = EntityManager.getValue<string>(drStudent, ColumnName.STMT_HEIGHT.ToString());
                objStudent.Remark = EntityManager.getValue<string>(drStudent, ColumnName.STMT_REMARK.ToString());
                objStudent.Weight = EntityManager.getValue<string>(drStudent, ColumnName.STMT_WEIGHT.ToString());
                objStudent.Reference = EntityManager.getValue<string>(drStudent, ColumnName.STMT_REFERENCE.ToString());
                objStudent.counselor = EntityManager.getValue<string>(drStudent, ColumnName.STMT_COUNSELOR.ToString());
                objStudent.Category = EntityManager.getValue<string>(drStudent, ColumnName.STMT_CATEGORY.ToString());
                objStudent.AdharCard = EntityManager.getValue<string>(drStudent, ColumnName.STMT_ADHARCARD_NO.ToString());
                objStudent.GSTNo = EntityManager.getValue<string>(drStudent, ColumnName.STMT_GST_NO.ToString());
                objStudent.HeathIssue = EntityManager.getValue<string>(drStudent, ColumnName.STMT_HEATH_ISSUE.ToString());
                objStudent.Source = EntityManager.getValue<string>(drStudent, ColumnName.STMT_SOURCE.ToString());
                objStudent.SchoolName = EntityManager.getValue<string>(drStudent, ColumnName.STMT_SCHOOL_NAME.ToString());
                if (objStudent.Courses != null && objStudent.Courses.Count > 0)
                {
                    //objStudent.Course = objStudent.Courses[objStudent.Courses.Count-1];
                    objStudent.Course = objStudent.Courses[0];
                }

                return objStudent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Student> getStudents(DataTable dtStudents)
        {
            try
            {
                List<Student> lstStudents = new List<Student>();

                foreach (DataRow drStudent in dtStudents.Rows)
                {
                    lstStudents.Add(getStudent(drStudent));
                }

                return lstStudents;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public enum MemberData
        {
            // public class Constants
            //  public const string FirstName = "FirstName",
            //   MiddleName = "MiddleName";
            FirstName,
            MiddleName,
            LastName,
            ContactNo,
            EmailID,
            DOB,
            Gender,
            Address,
            AdharNo,
            MembershipNo,
            BiometricID,
            TrainerName,
            AdmissionDate,
            Course,
            TotalFees,
            FeesPaid,
            Discount,
            PaymentDate,
            PaymentBankCash,
            GymBranch,
            PackageName,
            Amount,
            PaymentTerm,
            Stream,
            Batch,
            ReceiptNo,
            PaymentAccount,
            HeathIssue,
            Source
        }



    }
}