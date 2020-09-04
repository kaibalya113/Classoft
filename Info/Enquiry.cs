using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class Enquiry
    {

        public Enquiry(int EnquiryId)
        {
            this.EnquiryID = EnquiryId;
        }

        public Enquiry()
        {
            this.Standard = new Standard();
            Branch = new Branch();
            this.Batch = new Batch();
        }

        public string motherContact { get; set; }
        public string parentContact { get; set; }
        public int EnquiryID { get; set; }

        public string Fullname { get; set; }
        public string State { get; set; }
        public string FName { get; set; }

        public string MName { get; set; }

        public string LName { get; set; }

        public string Addres { get; set; }

        public string ContactNo { get; set; }

        public Standard Standard { get; set; }
        public Batch Batch { get; set; }
        public string ClgName { get; set; }

        public float LstYerMarks { get; set; }

        public DateTime EnquiryDate { get; set; }

        public DateTime DOB { get; set; }

        public string EmailID { get; set; }

        public bool IsRegistered { get; set; }

        public string ReferenceBy { get; set; }
        public string Status { get; set; }
        public Followup LatestFollowUp { get; set; }
        public Branch Branch { get; set; }
        public string SchoolName { get; set; }
        public string Qualification { get; set; }
        public string Fees { get; set; }       
        public string Field { get; set; }
        public string Subjects { get; set; }
       //public string School { get; set; }

        public static List<Enquiry> getEnquiries(DataTable dtEnquiries)
        {
            try
            {
                List<Enquiry> lstEnquiry = new List<Enquiry>();

                foreach (DataRow drEnquiry in dtEnquiries.Rows)
                {
                    lstEnquiry.Add(getEnquiry(drEnquiry));
                }

                return lstEnquiry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        enum ColumnName
        {
            ENQ_ID,
            ENQ_FNAME,
            ENQ_MNAME,
            ENQ_LNAME,
            ENQ_ADDRESS,
            ENQ_CONTACT_NO,
            ENQ_STANDARD_ID,
            ENQ_COLLEGE_NAME,
            ENQ_LAST_YEAR_MARKS,
            ENQ_STREAM_ID,
            ENQ_DATE,
            ENQ_EMAIL,
            ENQ_REFERER,
            ENQ_IS_REGISTERED,
            ENQ_BRANCH_ID,
            ENQ_LAST_FOLLOWUP,
            ENQ_DOB,
            ENQ_CRTD_AT,
            ENQ_UPDT_AT,
            ENQ_DLTD_AT,
            ENQ_CRTD_BY,
            ENQ_UPDAT_BY,
            ENQ_DLTD_BY,
            ID,
            ENQ_STATUS,
            ENQ_PARENT_CONTACT,
            ENQ_MOTHER_CONTACT,
            ENQ_QUALIFICATION,
            ENQ_BATCH_ID,
            ENQ_COUNSELOR,
            ENQ_STATE,
            ENQ_SCHOOL_NAME

        }

        public static Enquiry getEnquiry(DataRow drEnquiry)
        {
            try
            {

                Enquiry objEnquiry = new Enquiry();
                
                objEnquiry.EnquiryID = EntityManager.getValue<Int32>(drEnquiry, ColumnName.ENQ_ID.ToString());
               
                objEnquiry.FName = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_FNAME.ToString());
                objEnquiry.parentContact = EntityManager.getValue<String>(drEnquiry,ColumnName.ENQ_PARENT_CONTACT.ToString());
                objEnquiry.motherContact = EntityManager.getValue<String>(drEnquiry, ColumnName.ENQ_MOTHER_CONTACT.ToString());
                objEnquiry.Addres = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_ADDRESS.ToString());
                
                objEnquiry.DOB = EntityManager.getValue<DateTime>(drEnquiry, ColumnName.ENQ_DOB.ToString());
               
                objEnquiry.ClgName = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_COLLEGE_NAME.ToString());
               
                objEnquiry.ContactNo = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_CONTACT_NO.ToString());
               
                objEnquiry.EnquiryDate = EntityManager.getValue<DateTime>(drEnquiry, ColumnName.ENQ_DATE.ToString());

                objEnquiry.LName = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_LNAME.ToString());
                
                objEnquiry.MName = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_MNAME.ToString());
                objEnquiry.Status = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_STATUS.ToString());
                objEnquiry.SchoolName = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_SCHOOL_NAME.ToString());

                objEnquiry.EmailID = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_EMAIL.ToString());
               // objEnquiry.School = EntityManager.getValue<string>(drEnquiry, ColumnName.txtSchool.ToString());
                objEnquiry.ReferenceBy = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_REFERER.ToString());
               
                objEnquiry.IsRegistered = EntityManager.getValue<bool>(drEnquiry, ColumnName.ENQ_IS_REGISTERED.ToString());
                objEnquiry.State= EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_STATE.ToString());
                objEnquiry.Fullname = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_FNAME.ToString()) + " " + EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_LNAME.ToString());
                objEnquiry.Qualification = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_QUALIFICATION.ToString()) + " " + EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_LNAME.ToString());

                objEnquiry.Branch = Branch.getBranch(drEnquiry);
                objEnquiry.Standard = Standard.getStandard(drEnquiry);
                objEnquiry.Batch = Batch.GetBatch(drEnquiry);
                objEnquiry.LatestFollowUp = Followup.getFollowUp(drEnquiry);
                objEnquiry.Field = EntityManager.getValue<string>(drEnquiry, ColumnName.ENQ_COUNSELOR.ToString());
                return objEnquiry;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public override string ToString()
        {
            return FName + " " + MName + " " + LName;
        }

    }
}
