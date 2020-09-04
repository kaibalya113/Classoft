using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassManager.Info;

namespace ClassManager.Info
{
    [Serializable]
    public class TestSubject
    {
        public decimal Marks { get; set; }
        public DateTime Datetime { get; set; }
        public SubjectMaster subjectmaster { get; set; }


        public TestSubject()
        {
            //this.subjectmaster = new SubjectMaster(this.subjectmaster.SubjName, this.subjectmaster.SubjId);
            //this.subjectmaster = new SubjectMaster();
        }

        enum ColumnName
        {
            TSUB_ID,
            TSUB_TEST_ID,
            TSUB_SUBJECT_ID,
            TSUB_BRANCH_ID,
            TSUB_CRTD_AT,
            TSUB_UPDT_AT,
            TSUB_DLTD_AT,
            TSUB_CRTD_BY,
            TSUB_UPDT_BY,
            TSUB_DLTD_BY,
            ID,
            TSUB_MARKS,
            TSUB_DATETIME

        }
        /*  public static List<TestSubject> getlstofTestSubject (DataTable dtTestsub)
          {
              try
              {
                  List<TestSubject> lstsubject = new List<TestSubject>();

                  foreach (DataRow drTestsub in dtTestsub.Rows)
                  {
                      lstsubject.Add(lstofTestSubject(drTestsub));
                  }

                  return lstsubject;
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
          public static TestSubject lstsubject(DataRow drTestsub)
          {
              try
              {
                  TestSubject objtestsubject = new TestSubject();
                  objtestsubject.Marks = EntityManager.getValue<Int32>(drTestsub, ColumnName.TSUB_MARKS.ToString());
              }*/



        public override string ToString()
        {
            return subjectmaster.SubjName;
        }

        public static List<TestSubject> getSubjects(DataTable dtSubjects)
        {
            try
            {
                List<TestSubject> lstsubjects = new List<TestSubject>();

                foreach (DataRow drStreams in dtSubjects.Rows)
                {
                    lstsubjects.Add(getSubjects(drStreams));
                } 
                return lstsubjects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static TestSubject getSubjects(DataRow drsubjects)
        {
            try
            {
                TestSubject objtestSubject = new TestSubject();
                objtestSubject.subjectmaster = SubjectMaster.getSubject(drsubjects);
              
                return objtestSubject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}