using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using ClassManager.Info;
namespace ClassManager.BLL
{
    public class TestHandler
    {
        static SqlCommand com;
        public static bool saveTest(Info.TestMaster objTest, List<Info.TestSubject> lstTestsubject)
        {
            try
            {
                com = new SqlCommand("s_pr_create_TestMaster");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@StdId", SqlDbType.Int).Value = objTest.Standard.Standardid;
                com.Parameters.Add("@BatchId", SqlDbType.Int).Value = objTest.Batch.id;
                com.Parameters.Add("@TestName", SqlDbType.VarChar).Value = objTest.TestName;
                com.Parameters.Add("@Marks", SqlDbType.Int).Value = objTest.Marks;
                com.Parameters.Add("@description", SqlDbType.Text).Value = objTest.description;
                com.Parameters.Add("@Date", SqlDbType.Date).Value = objTest.Date;
                com.Parameters.Add("@BranchId", SqlDbType.Int).Value = objTest.BranchId;

                com.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    objTest.Id = (int)com.Parameters["@Id"].Value;

                    com = new SqlCommand("s_pr_create_Testsubject");
                    com.CommandType = CommandType.StoredProcedure;
                    foreach (TestSubject objtestsubject in lstTestsubject)
                    {
                        com.Parameters.Clear();
                        com.Parameters.Add("@SubId", SqlDbType.Int).Value = objtestsubject.subjectmaster.SubjId;
                        com.Parameters.Add("@Marks", SqlDbType.Decimal).Value = objtestsubject.Marks;
                        com.Parameters.Add("@DateTime", SqlDbType.Date).Value = objtestsubject.Datetime;
                        com.Parameters.Add("@branchId", SqlDbType.Int).Value = objTest.BranchId;
                        com.Parameters.Add("@TestId", SqlDbType.Int).Value = objTest.Id;

                        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                        Sqlhelper.ExecuteNonQuery(com);

                        if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com) == false)
                        {
                            throw new Common.Exceptions.InvalidReturnCodeException(com);
                        }
                    }
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

                return true;
            }

            catch (Exception ex)

             {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable getAllTests(string branchID, DateTime testdate, bool isShowallcheck)
        {
            try
            {
                Info.TestMaster objtestmaster = new Info.TestMaster();
                com = new SqlCommand("s_pr_get_Tests");
                com.CommandType = CommandType.StoredProcedure;



                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add("@test_date", SqlDbType.DateTime).Value = testdate;
                com.Parameters.Add("@ischeck", SqlDbType.Bit).Value = isShowallcheck;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static List<TestMaster> getOnlyTests(string branchID, int identifier,int stream,string courseId,string batchId)
        {
            try
            {
                Info.TestMaster objtestmaster = new Info.TestMaster();
                com = new SqlCommand("s_pr_get_Testname");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add("@identifier", SqlDbType.Int).Value = identifier;
                com.Parameters.Add("@streamId", SqlDbType.Int).Value = stream;
                com.Parameters.Add("@standardId", SqlDbType.VarChar).Value = (courseId == "-1")?"%": courseId.ToString();
                com.Parameters.Add("@batchId", SqlDbType.VarChar).Value = (batchId == "-1") ? "%" : batchId.ToString();

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return TestMaster.getlstofTest(dt);
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static List<ComboItem> loadTest()
        {
            try
            {
                // TestMaster objtest = new TestMaster();
                List<ComboItem> lstofaddedtest = new List<ComboItem>();
                StringBuilder query = new StringBuilder("SELECT TEST_NAME ,TEST_TTL_MARKS,TSUB_MARKS,TSUB_DATETIME,SUBM_NAME from TEST_MASTER,TEST_SUBJECTS, SUBJECT_MASTER");


                DataTable dt = DAL.Sqlhelper.GetDatatable(new SqlCommand(query.ToString()));

                foreach (DataRow dr in dt.Rows)
                {
                    lstofaddedtest.Add(new ComboItem(Convert.ToInt32(dr["TEST_TTL_MARKS"].ToString()), dr["TEST_NAME"].ToString()));
                }
                return lstofaddedtest;
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }



        public static DataTable getStudentTestDetails(int testID)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Student_Test_Details");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@TestID", SqlDbType.Int).Value = testID;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudent = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {

                    return dtStudent;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
           
        }

        public static int UpdateTestMarks(int TestId, int AdmsnNo, string Marks, string branchID,string Remark)
        {
            try
            {

                com = new SqlCommand("s_pr_update_Marks");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@TestID", SqlDbType.Int).Value = TestId;
                com.Parameters.Add("@AdmsNo", SqlDbType.Int).Value = AdmsnNo;
                com.Parameters.Add("@testmarks", SqlDbType.VarChar).Value = Marks;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchID;
                com.Parameters.Add("@Remark", SqlDbType.VarChar).Value = Remark;

                //Added this Parameter.Mohan(14-Aug-2017).
                //com.Parameters.Add("@SubName", SqlDbType.VarChar).Value = subName;
                //Mohan(14-Aug-2017).

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return 1;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }


        public static DataTable getStudentForTest(int testid)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Student_For_Test");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@testId", SqlDbType.Int).Value = testid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                    
                }

                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }


        public static DataTable getStudentForSubject(int testid)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Student_For_Subjects");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@testId", SqlDbType.Int).Value = testid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                    
                }

                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }




        public static DataTable getSelectedStudentForTest(string testid,String list)
        {
            try
            {
                com = new SqlCommand("s_pr_get_listedStudent_For_Subjects");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@testId", SqlDbType.VarChar).Value = testid;
                com.Parameters.Add("@listStud", SqlDbType.VarChar).Value = list;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;

                }

                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }




        public static bool updateTest(Info.TestMaster objtestmaster, bool isdelete)
        {
            try
            {
                com = new SqlCommand("s_pr_update_test_master");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@testid", SqlDbType.Int).Value = objtestmaster.Id;
                com.Parameters.Add("@testdate", SqlDbType.DateTime).Value = objtestmaster.Date;
                com.Parameters.Add("@testmarks", SqlDbType.Int).Value = objtestmaster.Marks;
                com.Parameters.Add("@testname", SqlDbType.VarChar).Value = objtestmaster.TestName;
                com.Parameters.Add("@isdelete", SqlDbType.Bit).Value = isdelete;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static bool deleteTest(int TestId, int branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_delete_test_master");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@testid", SqlDbType.Int).Value = TestId;
                com.Parameters.Add("@branch_id", SqlDbType.Int).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static bool updateStatus(int testid)
        {
            try
            {
                if (testid.ToString() != null)
                {
                    com = new SqlCommand("Update TEST_MASTER set Status = 'Test Completed' where TestId =" + testid + ";");
                    Sqlhelper.ExecuteNonQuery(com);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }


        }


        //public static bool loadTestMaster()
        //{
        //    com = new SqlCommand("Select * from TEST_MASTER");

        //}

        //public static bool getTestaccrdngtodate(bool istodaycheck, bool istmrwcheck)
        //{
        //    try
        //    {
        //        com = new SqlCommand("s_pr_get_test_accrdng_to_date");
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.Add("@istoday", SqlDbType.Bit).Value = istodaycheck;
        //        com.Parameters.Add("@istomorrow", SqlDbType.Bit).Value = istmrwcheck;
        //        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

        //        Sqlhelper.ExecuteQuery(com);
        //        if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
        //        {
        //            return true;

        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        /*   public static Info.TestMaster getTest(int TestID)
           {
               try
               {
                   objcom = new SqlCommand("s_pr_get_cheque");
                   objcom.CommandType = CommandType.StoredProcedure;
                   objcom.Parameters.Add("@chequeID", SqlDbType.Int).Value = TestID;
                   objcom.Parameters.Add("@NUM_ERROR_CODE", SqlDbType.Int).Direction = ParameterDirection.Output;

                   DataTable dt = Sqlhelper.GetDatatable(objcom);
                   if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objcom))
                   {
                       return Info.TestMaster.getTest(dt.Rows[0]);
                   }
                   else
                   {
                       return null;
                   }
               }
               catch (Exception ex)
               {

                   throw ex;
               }
           }
           */
        /*    public static DataTable getStudentExamDetails(string admissioNO)
            {
                try
                {
                    com = new SqlCommand("select STUDENT_MASTER.STMT_FNAME,STREAM.STRM_NAME,STANDARD.STD_NAME,TEST_MASTER.TEST_NAME,TEST_MASTER.TEST_DATE,SUBJECT_MASTER.SUBM_NAME,TEST_MASTER.TEST_TTL_MARKS, STUDENT_TEST_DETAILS.STTD_MARKS_OPTAINED from STUDENT_TEST_DETAILSinner join TEST_SUBJECTS on TEST_SUBJECTS.TSUB_ID = STUDENT_TEST_DETAILS.STTD_TEST_SUB_ID inner join TEST_MASTER on TEST_SUBJECTS.TSUB_TEST_ID = TEST_MASTER.TEST_ID inner join STUDENT_MASTER on STUDENT_TEST_DETAILS.STTD_ADMISSION_NO = STUDENT_MASTER.STMT_ADMISSION_NO inner join SUBJECT_MASTER on TEST_SUBJECTS.TSUB_SUBJECT_ID = SUBJECT_MASTER.SUBM_ID inner join STANDARD on TEST_MASTER.TEST_STANDARD_ID = STANDARD.STD_ID inner join STREAM on STREAM.STRM_ID = STANDARD.STD_STREAM_ID where STUDENT_TEST_DETAILS.STTD_ADMISSION_NO like '" + admissioNO + "'");
                    DataTable dt = Sqlhelper.GetDatatable(com);
                    return dt;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }*/
        public static DataTable getStudentExamDetails(string admissioNO, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                com = new SqlCommand("s_pr_get_student_marks");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@admissionNo", SqlDbType.Int).Value = admissioNO;
                com.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                com.Parameters.Add("ToDate", SqlDbType.DateTime).Value = ToDate;
                // com.Parameters.Add("@branch_id", SqlDbType.Int).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = Sqlhelper.GetDatatable(com);
                Sqlhelper.ExecuteQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable getTestForstudent(string AdmissionNo, string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_student_tests");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@admissionNo", SqlDbType.VarChar).Value = AdmissionNo;
                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchId;  
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = Sqlhelper.GetDatatable(com);
                Sqlhelper.ExecuteQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }
        public static DataTable getTestDetails(string AdmissionNo, string TestId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Exam_Details");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@admissionNo", SqlDbType.VarChar).Value = AdmissionNo;
                com.Parameters.Add("@Test_Id", SqlDbType.VarChar).Value = TestId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = Sqlhelper.GetDatatable(com);
                Sqlhelper.ExecuteQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static bool updateTestMaster(int TestID, int branchId)
        {
            try
            {
                com = new SqlCommand("update TEST_MASTER set TEST_ARCHIEVE = 1 where TEST_MASTER.TEST_ID = " + TestID + "and TEST_BRANCH_ID =" + branchId );
                com.CommandType = CommandType.Text;

                return Sqlhelper.ExecuteQuery(com);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
    }
}


