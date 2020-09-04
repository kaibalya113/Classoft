using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class SubjectMaster
    {
        public int SubjId { get; set; }

        public string SubjName { get; set; }

        public Faculty Faculty { get; set; }

        public Standard Standard { get; set; }

        public List<Faculty> teachingFaculties { get; set; }

        public int BranchID { get; set; }

        public string lstfclty;
        private DataTable dtSubject;

        public SubjectMaster()
        {
            this.Standard = new Standard();
            this.Faculty = new Faculty();
        }


        public SubjectMaster(string sname,int id)
        {
            this.SubjName = sname;
            this.SubjId = id;
        }

        public static SubjectMaster getSubject(DataTable dtSubject)
        {
            SubjectMaster subject = getSubject(dtSubject.Rows[0]);
            subject.teachingFaculties = Faculty.getFaculties(dtSubject);
            return subject;
        }

        public static List<Info.SubjectMaster> getSubjects(System.Data.DataTable dtSubjects)
        {
            try
            {
                List<Info.SubjectMaster> lstSubjects = new List<Info.SubjectMaster>();

                foreach (DataRow drSubject in dtSubjects.Rows)
                {
                    lstSubjects.Add(getSubject(drSubject));
                }

                return lstSubjects;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        enum ColumnName
        {
            SUBM_ID,
            SUBM_NAME,
            SUBM_STANDARD_ID,
            SUBM_BRANCH_ID,
            SUBM_CRTD_AT,
            SUBM_UPDT_AT,
            SUBM_DLTD_AT,
            SUBM_CRTD_BY,
            SUBM_UPDAT_BY,
            SUBM_DLTD_BY,
            ID

        }
        public static Info.SubjectMaster getSubject(DataRow drSubject)
        {
            try
            {
                Info.SubjectMaster objSubj = new Info.SubjectMaster();
                objSubj.SubjId = EntityManager.getValue<Int32>(drSubject, ColumnName.SUBM_ID.ToString());
                objSubj.SubjName = EntityManager.getValue<string>(drSubject, ColumnName.SUBM_NAME.ToString());
                objSubj.Standard = Standard.getStandard(drSubject);
                objSubj.Faculty = Faculty.getFaculty(drSubject);

                return objSubj;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return SubjName;
        }
    }
}
