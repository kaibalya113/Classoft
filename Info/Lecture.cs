using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public  class Lecture
    {
        public Stream Stream { get; set; }
        
        public Standard Standard { get; set; }

        public Batch Batch { get; set; }

        public int BranchID { get; set; }

        public int LectureID { get; set; }
        
        public Faculty Faculty{  get; set; }
       
        public DateTime Date { get; set; }

        public SubjectMaster Subject { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }
        public string ExpectedPortion { get; set; }
        public string ActualDone { get; set; }

        public Lecture()
        {
            this.Stream = new Stream();
            this.Standard = new Standard();
            this.Batch = new Batch();
            this.Faculty = new Faculty();
            this.Subject = new SubjectMaster();
           // this.expectedPortion = expectedPortion; 
        }

        //public string SubjName { get; set; }

        //public int SubjId { get; set; }

        //public string Location { get; set; }

        //public Faculty LectureFaculty {get;set;}

        public static List<Lecture> getLecture(System.Data.DataTable dtLec)
        {
            try
            {
                List<Lecture> objLec = new List<Lecture>();

                foreach (DataRow drLect in dtLec.Rows)
                {

                    objLec.Add(Lecture.getLecture(drLect));
                }

                return objLec;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        enum ColumnName
        {
            TMTL_ID,
            TMTL_STANDARD_ID,
            TMTL_BATCH_ID,
            TMTL_DATE,
            TMTL_FACULTY_ID,
            TMTL_FROM_TIME,
            TMTL_TO_TIME,
            TMTL_SUBJECT_ID,
            TMTL_LOCATION,
            TMTL_BRANCH_ID,
            TMTL_CRTD_AT,
            TMTL_UPDT_AT,
            TMTL_DLTD_AT,
            TMTL_CRTD_BY,
            TMTL_UPDAT_BY,
            TMTL_DLTD_BY,
            ID,
            TMTL_EXPECTED_PORTION,
            TMTL_ACTUAL_DONE, 
          //  TMTL_ID,
          //  TMTL_FACULTY_ID
        }

        public static Lecture getLecture(DataRow drLect)
        {
            try
            {
                Lecture objLec = new Lecture();
            
            objLec.FromTime = EntityManager.getValue<DateTime>(drLect, ColumnName.TMTL_FROM_TIME.ToString());
                if (objLec.FromTime != null)
                {
                    objLec.FromTime = Convert.ToDateTime(objLec.FromTime.ToShortTimeString());
                }
           
                objLec.ToTime = EntityManager.getValue<DateTime>(drLect, ColumnName.TMTL_TO_TIME.ToString());
                if (objLec.ToTime != null)
                {
                    objLec.ToTime = Convert.ToDateTime(objLec.ToTime.ToShortTimeString());
                }
                objLec.ExpectedPortion = EntityManager.getValue<string>(drLect, ColumnName.TMTL_EXPECTED_PORTION.ToString());
                objLec.ActualDone = EntityManager.getValue<string>(drLect, ColumnName.TMTL_ACTUAL_DONE.ToString());
                objLec.LectureID = EntityManager.getValue<int>(drLect, ColumnName.TMTL_ID.ToString());

                objLec.BranchID = EntityManager.getValue<int>(drLect, ColumnName.TMTL_BRANCH_ID.ToString());
              
                objLec.Date = EntityManager.getValue<DateTime>(drLect, ColumnName.TMTL_DATE.ToString());
                

            objLec.Faculty = Faculty.getFaculty(drLect);
            objLec.Stream = Stream.getStream(drLect);
            objLec.Standard=Standard.getStandard(drLect);
            objLec.Batch = Batch.GetBatch(drLect);
            objLec.Subject = SubjectMaster.getSubject(drLect);

            return objLec;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Lecture> getLectures(DataTable dtLec)
        {
            try
            {
                List<Lecture> lstLectures = new List<Lecture>();

                foreach(DataRow dr in dtLec.Rows)
                {
                    lstLectures.Add(getLecture(dr));
                }

                return lstLectures;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<Lecture>GetFacLec(DataTable dtLec)
        {
            try
            {
                List<Lecture> lstFacLect = new List<Lecture>();

                foreach(DataRow dr in dtLec.Rows)
                {
                    lstFacLect.Add(getLecture(dr));
                }
                return lstFacLect;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
