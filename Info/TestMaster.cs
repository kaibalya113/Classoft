using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class TestMaster
    {
        public int Id;


       
        public Standard Standard;
        public Stream stream;
        public Batch Batch;
       // public SubjectMaster subjectmaster;

        public string TestName { get; set; }
        public int Marks { get; set; }
        public DateTime Date { get; set; }
        //public int BatchId;
        public int BranchId;
        public string Status { get; set; }
        public string description { get; set; }
        //public string BatchName { get; set; }

        public TestMaster()
        {
            this.stream = new Stream();
            this.Standard = new Standard();
            this.Batch = new Batch();
            //this.subjectmaster = new SubjectMaster();
        }

        public static List<TestMaster> getlstofTest(DataTable dtTest)
        {
            try
            {
                List<TestMaster> lstTest = new List<TestMaster>();

                foreach (DataRow drTest in dtTest.Rows)
                {
                    lstTest.Add(lstofTest(drTest));
                }

                return lstTest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        enum ColumnName
        {
            TEST_ID,
            TEST_STANDARD_ID,
           
            TEST_NAME,
            TEST_TTL_MARKS,
            TEST_DESC,
            TEST_DATE,
            TEST_BATCH_ID,
            TEST_BRANCH_ID,
            TEST_STATUS,
            TEST_CRTD_AT,
            TEST_UPDT_AT,
            TEST_DLTD_AT,
            TEST_CRTD_BY,
            TEST_UPDAT_BY,
            TEST_DLTD_BY,
            ID

        }
        public static TestMaster lstofTest(DataRow drTest)
        {
            try
            {
                TestMaster objTestMaster = new TestMaster();
          
            objTestMaster.Id = EntityManager.getValue<Int32>(drTest, ColumnName.TEST_ID.ToString());
           
            objTestMaster.TestName = EntityManager.getValue<string>(drTest, ColumnName.TEST_NAME.ToString());
           
            objTestMaster.Marks = EntityManager.getValue<Int32>(drTest, ColumnName.TEST_TTL_MARKS.ToString());
           
            objTestMaster.Date = EntityManager.getValue<DateTime>(drTest, ColumnName.TEST_DATE.ToString());
           
            objTestMaster.BranchId = EntityManager.getValue<Int32>(drTest, ColumnName.TEST_BRANCH_ID.ToString());


            if (drTest.Table.Columns.Contains("TEST_DESC") && drTest["TEST_DESC"] != DBNull.Value)
            {
                objTestMaster.description = Convert.ToString(drTest["TEST_DESC"]);
            }
            objTestMaster.Standard = Standard.getStandard(drTest);
            objTestMaster.stream = Stream.getStream(drTest);
            objTestMaster.Batch = Batch.GetBatch(drTest);
           // objTestMaster.subjectmaster = SubjectMaster.getSubjectList(drTest);

            return objTestMaster;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

