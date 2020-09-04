using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassManager.Info;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using System.Configuration;
using ClassManager.Common;


namespace ClassManager.BLL
{
    public class StudentHandller
    {

        static SqlCommand com;
        static SqlTransaction objTrans;
        static List<Student> objstud = new List<Student>();
        public static void RegisterStudent(Student ObjStudent)
        {
            try
            {

                int feesId = 0;
                com = new SqlCommand("s_pr_register_student");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@AdmissionDate", SqlDbType.Date).Value = ObjStudent.AdmissionDate;
                com.Parameters.Add("@Fname", SqlDbType.VarChar).Value = ObjStudent.Fname;
                com.Parameters.Add("@Mname", SqlDbType.VarChar).Value = ObjStudent.Mname;
                com.Parameters.Add("@Lname", SqlDbType.VarChar).Value = ObjStudent.Lname;
                com.Parameters.Add("@Address", SqlDbType.VarChar).Value = ObjStudent.Address;
                com.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = ObjStudent.ContactNo;
                com.Parameters.Add("@Gender", SqlDbType.VarChar).Value = ObjStudent.Gender;
                string appName = Info.SysParam.getValue<string>(Info.SysParam.Parameters.APPLICATION_NAME);
                if(appName != "Gym")
                {
                    com.Parameters.Add("@SchoolName", SqlDbType.VarChar).Value = ObjStudent.SchoolName;
                }

                com.Parameters.Add("@ApplicationName", SqlDbType.VarChar).Value = appName;
                if (ObjStudent.Dob == DateTime.MinValue)
                {
                    com.Parameters.Add("@Dob", SqlDbType.Date).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Dob", SqlDbType.Date).Value = ObjStudent.Dob;
                }

                com.Parameters.Add("@FatherName", SqlDbType.VarChar).Value = ObjStudent.FatherName;
                com.Parameters.Add("@FathersOccupation", SqlDbType.VarChar).Value = ObjStudent.FathersOccupation;
                com.Parameters.Add("@MothersOccupation", SqlDbType.VarChar).Value = ObjStudent.MothersOccupation;
                com.Parameters.Add("@FatherContactNo", SqlDbType.VarChar).Value = ObjStudent.FatherContactNo;
                com.Parameters.Add("@MotherContactNo ", SqlDbType.VarChar).Value = ObjStudent.MotherContactNo;
                com.Parameters.Add("@EnquiryID", SqlDbType.Int).Value = ObjStudent.Enquiry.EnquiryID;
                com.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = ObjStudent.EmailID;
                com.Parameters.Add("@AcadmicInfo", SqlDbType.VarChar).Value = "";
                com.Parameters.Add("@BatchID", SqlDbType.VarChar).Value = ObjStudent.Batch.id;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = ObjStudent.Branch.BranchId;
                com.Parameters.Add("@PhotoURL", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@ACADEMIC_YEAR", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@RollNo", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.Parameters.Add("@feesId", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add("@biometric_id", SqlDbType.Int).Value = ObjStudent.BiometricId;
                com.Parameters.Add("@MemberShipNo", SqlDbType.VarChar).Value = ObjStudent.MembershipNo;
                com.Parameters.Add("@Adhar_no", SqlDbType.VarChar).Value = ObjStudent.AdharCard;
                com.Parameters.Add("@Remark", SqlDbType.VarChar).Value = ObjStudent.Remark;
                com.Parameters.Add("@BloodGroup", SqlDbType.VarChar).Value = ObjStudent.BloodGroup;
                com.Parameters.Add("@Weight", SqlDbType.VarChar).Value = ObjStudent.Weight;
                com.Parameters.Add("@BMI", SqlDbType.VarChar).Value = ObjStudent.BMI;
                com.Parameters.Add("@Height", SqlDbType.VarChar).Value = ObjStudent.Height;
                com.Parameters.Add("@Refer", SqlDbType.VarChar).Value = ObjStudent.Reference;
                com.Parameters.Add("@category", SqlDbType.VarChar).Value = ObjStudent.Category;
                com.Parameters.Add("@counselor", SqlDbType.VarChar).Value = ObjStudent.counselor;
                com.Parameters.Add("@GST", SqlDbType.VarChar).Value = ObjStudent.GSTNo;
                com.Parameters.Add("@HeathIssue", SqlDbType.VarChar).Value = ObjStudent.HeathIssue;
                com.Parameters.Add("@Source", SqlDbType.VarChar).Value = ObjStudent.Source;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                objTrans = Sqlhelper.getConnection().BeginTransaction();
                com.Transaction = objTrans;
                Sqlhelper.ExecuteNonQuery(com, true);
                if (com.Parameters["@NUM_ERROR_CODE"].Value.ToString().Equals("3"))
                {

                    ObjStudent.AdmissionNo = Convert.ToInt32(com.Parameters["@AdmissionNo"].Value);
                    ObjStudent.RollNo = (com.Parameters["@RollNo"].Value).ToString();

                }

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {


                    feesId = Convert.ToInt32(com.Parameters["@feesId"].Value);

                    ObjStudent.AdmissionNo = Convert.ToInt32(com.Parameters["@AdmissionNo"].Value);
                    ObjStudent.RollNo = (com.Parameters["@RollNo"].Value).ToString();
                    /*#TODO : Add check for file path */

                    try
                    {
                        string photoPath = Info.SysParam.getValue<String>(SysParam.Parameters.PHOTO_PATH);
                        ObjStudent.ImgPhoto.Save(photoPath + com.Parameters["@PhotoURL"].Value.ToString());
                    }
                    catch (Exception ex)
                    {

                    }

                    ObjStudent.AdmissionNo = ObjStudent.AdmissionNo;
                    ObjStudent.AcadYear = Convert.ToInt32(com.Parameters["@ACADEMIC_YEAR"].Value);
                    ObjStudent.RollNo = (com.Parameters["@RollNo"].Value).ToString();
                    ObjStudent.Fees = new Fees(feesId);

                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }

                objTrans.Commit();

            }

            catch (Exception ex)
            {
                if (objTrans != null)
                {
                    objTrans.Rollback();
                }

                objTrans = null;
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        //added by ashvini09-01-2019
        //for getting data of activity_log through procedure
        public static DataTable GetActivities(int AdmissionNo, string branchid)
        {
            try
            {
                com = new SqlCommand("s_pr_get_activities");

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@admissionNo", SqlDbType.Int).Value = AdmissionNo;
                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtUser1 = Sqlhelper.GetDatatable(com);

                ErrorCodes returnCode;

                Enum.TryParse<ErrorCodes>(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString(), out returnCode);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtUser1;
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
        //end by ashvini09-01-2019


        public static DataTable GetActivitityReport(DateTime fromdate, DateTime todate, string branchid)
        {
            try
            {
                com = new SqlCommand("s_pr_get_activitityReport");

                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = fromdate;
                com.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtUser1 = Sqlhelper.GetDatatable(com);

                ErrorCodes returnCode;

                Enum.TryParse<ErrorCodes>(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString(), out returnCode);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtUser1;
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
        //added by ashvini21-01-2019
        //for getting data of activity_log through procedure
        public static DataTable getmeasurementsOfStudent(DateTime frmdate, DateTime todate, int AdmissionNo, string branchid)
        {
            try
            {
                com = new SqlCommand("s_pr_get_all_measurements_of_student");

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@admissionNo", SqlDbType.Int).Value = AdmissionNo;
                com.Parameters.Add("@frmdate", SqlDbType.DateTime).Value = frmdate;
                com.Parameters.Add("@todate", SqlDbType.DateTime).Value = todate;
                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtUser1 = Sqlhelper.GetDatatable(com);

                ErrorCodes returnCode;

                Enum.TryParse<ErrorCodes>(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString(), out returnCode);


                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtUser1;
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
        //end by ashvini21-01-2019

        public static bool getmeasurements(Measurement objMeasure, int branchid)
        {
            try
            {


                com = new SqlCommand("s_pr_get_measurements_of_Student");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Date", SqlDbType.DateTime).Value = objMeasure.Date;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = objMeasure.AdmissionNo;
                com.Parameters.Add("@Weight", SqlDbType.Decimal).Value = objMeasure.Weight;
                com.Parameters.Add("@BMI", SqlDbType.Decimal).Value = objMeasure.BMI;
                com.Parameters.Add("@Height", SqlDbType.Decimal).Value = objMeasure.height;
                com.Parameters.Add("@fat", SqlDbType.Decimal).Value = objMeasure.FAT;
                com.Parameters.Add("@neck", SqlDbType.Decimal).Value = objMeasure.neck;
                com.Parameters.Add("@shoulder", SqlDbType.Decimal).Value = objMeasure.shoulder;
                com.Parameters.Add("@chest", SqlDbType.Decimal).Value = objMeasure.chest;
                com.Parameters.Add("@arms", SqlDbType.Decimal).Value = objMeasure.arms;
                com.Parameters.Add("@hips", SqlDbType.Decimal).Value = objMeasure.hips;
                com.Parameters.Add("@thigh", SqlDbType.Decimal).Value = objMeasure.thigh;
                com.Parameters.Add("@calves", SqlDbType.Decimal).Value = objMeasure.calves;
                com.Parameters.Add("@forearms", SqlDbType.Decimal).Value = objMeasure.forearms;
                com.Parameters.Add("@upperabd", SqlDbType.Decimal).Value = objMeasure.upper_abd;
                com.Parameters.Add("@lowerabd", SqlDbType.Decimal).Value = objMeasure.lower_abd;
                com.Parameters.Add("@waist", SqlDbType.Decimal).Value = objMeasure.waist;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchid;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                Sqlhelper.ExecuteNonQuery(com);


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


        public static Student GetStudent(int? AdmissionNo, String contactNo, String RollNo, int? BiometricId, int branchId,int? membershipId = null)
        {
            try
            {
                com = new SqlCommand("s_pr_get_student");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@RollNo", SqlDbType.VarChar).Value = (RollNo == null) ? (object)DBNull.Value : (object)RollNo;
                com.Parameters.Add("@AdmissionNo", SqlDbType.VarChar).Value = (AdmissionNo == null) ? (object)DBNull.Value : (object)AdmissionNo;
                com.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = (contactNo == null) ? (object)DBNull.Value : (object)contactNo;
                com.Parameters.Add("@MembershipId", SqlDbType.VarChar).Value = (membershipId == null) ? (object)DBNull.Value : (object)membershipId;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;



                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudent = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dtStudent.Rows.Count > 0)
                    {
                        Student objStudent = Student.getStudent(dtStudent.Rows[0]);
                        objStudent.Fees = FeesHandller.getFeesDetails(objStudent.AdmissionNo);
                        objStudent.Facilities = StudentHandller.getFacilities(objStudent.AdmissionNo);
                        objStudent.Courses = StudentHandller.getCourses(objStudent.AdmissionNo);
                        //objStudent.Facilities = StudentHandller.getFacilities(objStudent.Facilities);
                        if (objStudent.Courses != null && objStudent.Courses.Count > 0)
                        {
                            objStudent.Course = objStudent.Courses.OrderByDescending(c => c.AdmissinoDate).FirstOrDefault<Course>();
                        }
                        return objStudent;
                    }
                    else
                    {
                        return null;
                    }
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


        public static List<Student> AllRegistered(string branchID)
        {
            try
            {
                List<Student> lststd = new List<Student>();
                com = new SqlCommand("s_pr_disp_all_student");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudent = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dtStudent.Rows.Count > 0)
                    {
                        foreach (DataRow std in dtStudent.Rows)
                        {
                            lststd.Add(Info.Student.getStudent(std));

                        }
                        return lststd;
                    }
                    else
                    {
                        return null;
                    }
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

        public static DataTable getAllStudents(string branchID, DateTime from = default(DateTime), DateTime? to = null)
        {
            try
            {

                List<Student> lststd = new List<Student>();
                com = new SqlCommand("s_pr_disp_all_student");
                com.CommandType = CommandType.StoredProcedure;
                if (to == null)
                {
                    to = DateTime.Now;
                }
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add("@from", SqlDbType.Date).Value = from;
                com.Parameters.Add("@to", SqlDbType.Date).Value = to;

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
        //public static DataTable getAllStudentsExpired(string branchID, DateTime from = default(DateTime), DateTime? to = null)
        //{
        //    try
        //    {

        //        List<Student> lststd = new List<Student>();
        //        com = new SqlCommand("s_pr_disp_all_Exp_student");
        //        com.CommandType = CommandType.StoredProcedure;
        //        if (to == null)
        //        {
        //            to = DateTime.Now;
        //        }
        //        com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
        //        com.Parameters.Add("@from", SqlDbType.Date).Value = from;
        //        com.Parameters.Add("@to", SqlDbType.Date).Value = to;

        //        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

        //        DataTable dtStudent = Sqlhelper.GetDatatable(com);
        //        if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
        //        {
        //            return dtStudent;
        //        }
        //        else
        //        {
        //            throw new Common.Exceptions.InvalidReturnCodeException(com);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
        //        throw ex;
        //    }

        //}
        public static DataTable getActiveStudents(string StreamId, string CourseId, string BatchId, string BranchId)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_active_students");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Stream", SqlDbType.VarChar).Value = StreamId;
                com.Parameters.Add("@Course", SqlDbType.VarChar).Value = CourseId;
                com.Parameters.Add("@Batch", SqlDbType.VarChar).Value = BatchId;
                com.Parameters.Add("@Branch_id", SqlDbType.VarChar).Value = BranchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtdeletestudent = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtdeletestudent;
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

        public static DataTable GetExpiredPackageCount(string BranchId, int identifire)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_Count_Expire_Package");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@identifire", SqlDbType.Int).Value = identifire;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = BranchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable ExpiredPackage = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return ExpiredPackage;
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

        public static void updateStudPersnlDtl(StudentMaster objStud)
        {
            try
            {
                objTrans = Sqlhelper.getConnection().BeginTransaction();
                com = new SqlCommand("s_pr_update_student_details");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;
                com.Parameters.Add("@AdmisionNo", SqlDbType.Int).Value = objStud.AdmissionNo;
                com.Parameters.Add("@Fname", SqlDbType.VarChar).Value = objStud.Fname;
                com.Parameters.Add("@Mname", SqlDbType.VarChar).Value = objStud.Mname;
                com.Parameters.Add("@Lname", SqlDbType.VarChar).Value = objStud.Lname;
                com.Parameters.Add("@Address", SqlDbType.VarChar).Value = objStud.Address;
                com.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = objStud.ContactNo;
                com.Parameters.Add("@Gender", SqlDbType.VarChar).Value = objStud.Gender;
                com.Parameters.Add("@Dob", SqlDbType.Date).Value = objStud.Dob;
                com.Parameters.Add("@FatherName", SqlDbType.VarChar).Value = objStud.FatherName;
                com.Parameters.Add("@FContactNo", SqlDbType.VarChar).Value = objStud.FatherContactNo;
                com.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = objStud.EmailID;
                com.Parameters.Add("@biometricId", SqlDbType.Int).Value = objStud.BiometricId;
                com.Parameters.Add("@MembershipNo", SqlDbType.VarChar).Value = objStud.MembershipNo;
                com.Parameters.Add("@BatchID", SqlDbType.VarChar).Value = objStud.batchID;
                com.Parameters.Add("@Bloodgroup", SqlDbType.VarChar).Value = objStud.BloodGroup;
                com.Parameters.Add("@BMI", SqlDbType.VarChar).Value = objStud.BMI;
                com.Parameters.Add("@HealthIssue", SqlDbType.VarChar).Value = objStud.HeathIssue;
                com.Parameters.Add("@Weight", SqlDbType.VarChar).Value = objStud.Weight;
                com.Parameters.Add("@Height", SqlDbType.VarChar).Value = objStud.Height;
                com.Parameters.Add("@remark", SqlDbType.VarChar).Value = objStud.Remark;
                com.Parameters.Add("@category", SqlDbType.VarChar).Value = objStud.Category;
                com.Parameters.Add("@counselor", SqlDbType.VarChar).Value = objStud.counselor;
               //  com.Parameters.Add("@school", SqlDbType.VarChar).Value = objStud.AdharCard;
                com.Parameters.Add("@schoolName", SqlDbType.VarChar).Value = objStud.SchoolName;
                com.Parameters.Add("@Source", SqlDbType.VarChar).Value = objStud.Source;
                // com.Parameters.Add("@RollNo", SqlDbType.VarChar).Value = (objStud.RollNo== null) ? "" : objStud.RollNo ;
                com.Parameters.Add("@PhotoURL", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com, true);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    objTrans.Commit();
                    try
                    {
                        string pathToSave = SysParam.getValue<string>(SysParam.Parameters.PHOTO_PATH);

                        objStud.ImgPhoto.Save(pathToSave + com.Parameters["@PhotoURL"].Value.ToString());
                    }
                    catch (Exception ex)
                    {

                    }

                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("A generic error occurred in GDI+."))
                {
                    throw ex;
                }
                if (objTrans != null)
                {
                    objTrans.Rollback();
                }
                objTrans = null;

                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static bool enableRenewDiscount(int studfacilityID, bool isRenewDiscount)
        {
            try
            {
                com = new SqlCommand("s_pr_update_renew_discount");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@studfacilityID", SqlDbType.Int).Value = studfacilityID;
                com.Parameters.Add("@isRenewDiscount", SqlDbType.Bit).Value = isRenewDiscount;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);


                if (Common.Exceptions.ExceptionHandller.HandleDBError(com))
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

        public static DataTable getStudForMigration(Info.StudMigration objStudMigrt)
        {
            try
            {

                com = new SqlCommand("s_pr_get_stud_for_migrartion");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@stream", SqlDbType.VarChar).Value = objStudMigrt.Stream;
                com.Parameters.Add("@course", SqlDbType.VarChar).Value = objStudMigrt.Course;
                com.Parameters.Add("@batch", SqlDbType.VarChar).Value = objStudMigrt.Batch;
                com.Parameters.Add("@branchID", SqlDbType.VarChar).Value = objStudMigrt.BrachId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;
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
        public static void migrateSelectedStud(int AdmsnNo, string tostream, string tocourse, string tobatch, string branchId, DateTime startDate)
        {
            try
            {

                objTrans = Sqlhelper.getConnection().BeginTransaction();

                com = new SqlCommand("s_pr_misgrateStudentBackUp");
                com.CommandType = CommandType.StoredProcedure;

                com.Transaction = objTrans;

                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = AdmsnNo;

                com.Parameters.Add("@StreamID", SqlDbType.VarChar).Value = tostream;
                com.Parameters.Add("@StdID", SqlDbType.VarChar).Value = tocourse;
                com.Parameters.Add("@BatchID", SqlDbType.VarChar).Value = tobatch;
                com.Parameters.Add("@Branch_ID", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add("@AdmissionDate", SqlDbType.Date).Value = startDate;
                com.Parameters.Add("@feeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Common.Log.LogError("in Student handller register", ErrorLevel.INFORMATION);
                Sqlhelper.ExecuteNonQuery(com, true);
                int id = 0;
                Common.Log.LogError(com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString(), ErrorLevel.INFORMATION);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    id = Convert.ToInt32(com.Parameters["@feeID"].Value);
                }

                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = AdmsnNo;

                com = new SqlCommand("s_pr_addInstForMigrateStud");
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = objTrans;
                com.Parameters.Add("@FeesID", SqlDbType.Int).Value = id;
                com.Parameters.Add("@StreamID", SqlDbType.VarChar).Value = tostream;
                com.Parameters.Add("@StdID", SqlDbType.VarChar).Value = tocourse;
                com.Parameters.Add("@BatchID", SqlDbType.VarChar).Value = tobatch;
                com.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                com.Parameters.Add("@Branch_ID", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com, true);
                // com.Parameters.Clear();
                objTrans.Commit();


            }
            catch (Exception ex)
            {
                if (objTrans != null)
                {
                    objTrans.Rollback();
                }

                objTrans = null;
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }

        public static Batch getFacilityBatch(int admissionNo, int facilityId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_student_package_batch");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Admission_No", SqlDbType.Int).Value = admissionNo;
                com.Parameters.Add("@facility_id", SqlDbType.Int).Value = facilityId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Batch.GetBatch(dt.Rows[0]);
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

        public static bool deletestudent(Int32 admissionNo)
        {

            try
            {

                com = new SqlCommand("s_pr_delete_student");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Admission_No", SqlDbType.Int).Value = admissionNo;
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



        public static DataTable showAllRegistered(string branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand(" s_pr_show_all_registered");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                DataTable dtStud = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dtStud;
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

        public static Info.Student getStudentByBioMetric(int iUserID, string branchId)
        //public static List<Student> getStudentByBioMetric(int iUserID)
        {
            try
            {
                com = new SqlCommand("s_pr_get_student_by_bioMetric_id");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@biometricID", SqlDbType.VarChar).Value = iUserID;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudent = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dtStudent.Rows.Count > 0)
                    {
                        return Student.getStudent(dtStudent.Rows[0]);
                        //  return Student.getStudents(dtStudent);
                    }
                    else
                    {
                        return null;
                    }
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



        public static List<Student> getStudentByBioMetricID(int iUserID)
        {
            try
            {
                // List<Student> objstud = ;
                com = new SqlCommand("s_pr_get_student_by_bioMetric_id");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@biometricID", SqlDbType.VarChar).Value = iUserID;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudent = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dtStudent.Rows.Count > 0)
                    {
                        foreach (DataRow std in dtStudent.Rows)
                        {
                            objstud.Add(Info.Student.getStudent(std));
                        }
                        return objstud;
                    }
                    else
                    {
                        return null;
                    }
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
        /// <summary>
        /// Deactivates the expired facilities
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        /// 
        public static bool deactivateFacilities(DateTime currentDate, string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_deactivate_facilities");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@date", SqlDbType.Date).Value = currentDate;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = (branchId == "-1") ? "%" : branchId.ToString();
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                //DataTable dt= Sqlhelper.GetDatatable(com);
                Sqlhelper.ExecuteNonQuery(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return true;
                    //return dt;
                }
                else
                {


                    return false;

                    //return null;
                    throw new Common.Exceptions.InvalidReturnCodeException(com);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable GetExpiringFacilities(DateTime todate, string branchid)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_deactivated_facilties");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@date", SqlDbType.DateTime).Value = todate;
                com.Parameters.Add("@branchid", SqlDbType.VarChar).Value = branchid;
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

        public static DataTable getStudentsInBatch(String streamId, String courceId, String batchId, String branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_disp_student_in_batch");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Stream", SqlDbType.VarChar).Value = streamId;
                com.Parameters.Add("@Course", SqlDbType.VarChar).Value = courceId;
                com.Parameters.Add("@Batch", SqlDbType.VarChar).Value = batchId;
                com.Parameters.Add("@Branch_id", SqlDbType.VarChar).Value = branchId;

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

        //public static Student GetStudentByContactNo(int BranchId, string ContactNo = "%", string AdmissionNo = "0")
        //{
        //    try
        //    {

        //        com = new SqlCommand("s_pr_get_student");
        //        com.CommandType = CommandType.StoredProcedure;

        //        com.Parameters.Add("@AdmissionNo", SqlDbType.VarChar).Value = AdmissionNo;

        //        com.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;

        //        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

        //        DataTable dtStudent = Sqlhelper.GetDatatable(com);
        //        if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
        //        {
        //            if (dtStudent.Rows.Count > 0)
        //            {
        //                return Student.getStudent(dtStudent.Rows[0]);
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //        else
        //        {
        //            throw new Common.Exceptions.InvalidReturnCodeException(com);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public static void AddStudentFacility(StudentFacility facility, int instNo, int branchId, int biomId, int Count, SqlTransaction objTrans, string oldStflID = null)
        {
            try
            {
                if (facility.Package.IsMainPackage)
                {
                    facility.FromDate = facility.FromDate;
                    //facility.ToDate = facility.FromDate.AddMonths(facility.Package.PackageDuration);
                    facility.ToDate = facility.ToDate;
                }

                FeesPackageHandller.InsertFacility(instNo, facility, branchId, biomId, Count, oldStflID, objTrans);

            }

            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }



        public static List<Course> getCourses(int admissionNo)
        {
            try
            {

                com = new SqlCommand("s_pr_get_student_courses");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Admission_no", SqlDbType.VarChar).Value = admissionNo;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStandard = Sqlhelper.GetDatatable(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    if (dtStandard.Rows.Count > 0)
                    {
                        return Info.Course.getCourse(dtStandard);
                    }
                    else
                    {
                        return new List<Course>();
                    }
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

        public static void addStudentFacilities(Student student, List<StudentFacility> facilities, int biomId, int Count, string stflId = null)
        {
            try
            {

                List<InstallmentDetail> lstStudentInstallment = BLL.FeesHandller.orderInstallments(facilities);
                List<InstallmentDetail> lstInst = BLL.InstallmentHandler.getInstallmentDetails(student.Fees.FeesId);
                int instNo = lstInst.Count();

                objTrans = Sqlhelper.getConnection().BeginTransaction();

                foreach (Info.StudentFacility objFacility in facilities)
                {
                    StudentHandller.AddStudentFacility(objFacility, instNo, student.Branch.BranchId, biomId, Count, objTrans, stflId);
                    instNo = instNo + lstStudentInstallment.Count;
                    student.NewCourse += " " + objFacility.Package.Standard.StandardName + "-" + objFacility.Package.Standard.Stream.Name;
                }

                objTrans.Commit();
            }
            catch (Exception ex)
            {
                if (objTrans != null)
                {
                    objTrans.Rollback();
                }

                objTrans = null;
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static int deleteFacility(int studFaciltyID, int branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_delete_facility");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@stud_faciltyID", SqlDbType.Int).Value = studFaciltyID;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
               // com.Parameters.Add("@creditAmount", SqlDbType.Decimal).Value = creditAmount;

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

        public static int deleteFacility1(int studFaciltyID, int branchId, decimal creditAmount)
        {
            try
            {
                com = new SqlCommand("s_pr_delete_facility");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@stud_faciltyID", SqlDbType.Int).Value = studFaciltyID;
                com.Parameters.Add("@branchId", SqlDbType.Int).Value = branchId;
                com.Parameters.Add("@creditAmount", SqlDbType.Decimal).Value = creditAmount;

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

        public static DataTable getExpiredFacilities(DateTime notificationDate, string branchid)
        {
            try
            {
                com = new SqlCommand("s_pr_get_expired_facilities");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@To_Date", SqlDbType.Date).Value = notificationDate;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = (branchid == "-1") ? "%" : branchid.ToString();
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


        public static bool renewStudPackageOrFacility(int studfacilityID, bool isAutoRenew, bool isMainpack)
        {
            try
            {
                com = new SqlCommand("s_pr_enable_disable_autorenew");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@studfacilityID", SqlDbType.Int).Value = studfacilityID;

                com.Parameters.Add("@auto_renew", SqlDbType.Bit).Value = isAutoRenew;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);


                if (Common.Exceptions.ExceptionHandller.HandleDBError(com))
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

        public static List<StudentFacility> getFacilities(int admissionNo)
        {

            try
            {
                com = new SqlCommand("s_pr_get_student_facilities");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@AdmissionNo", SqlDbType.VarChar).Value = admissionNo;
                com.Parameters.Add("@Applicationname", SqlDbType.VarChar).Value = SysParam.getValue<string>(SysParam.Parameters.APPLICATION_NAME).ToLower();
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataSet dsFacilities = Sqlhelper.GetDataset(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return Info.StudentFacility.getStudentFacilities(dsFacilities);
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

        public static List<ComboItem> getStudentList(string branchId)
        {
            try
            {
                com = new SqlCommand("s_pr_get_Student_list");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudents = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    List<ComboItem> lstStudents = new List<ComboItem>();
                    foreach (DataRow dr in dtStudents.Rows)
                    {
                        lstStudents.Add(new ComboItem(Convert.ToInt32(dr["STMT_ADMISSION_NO"]), dr["NAME"].ToString()));
                    }
                    return lstStudents;
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


        public static List<Student> getStudents(DataTable dtStud)
        {
            try
            {
                List<Student> objStudents = new List<Student>();

                foreach (DataRow drStudent in dtStud.Rows)
                {
                    objStudents.Add(Student.getStudent(drStudent));
                }

                return objStudents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable getAbsentStudentDetails(DateTime toDate, string branchId)
        {
            try
            {
                try
                {
                    int noOfDaysCheck = SysParam.getValue<Int32>(SysParam.Parameters.DAYS_FOR_ABSENT_MSG);

                    DateTime fromDate = DateTime.Now.AddDays(noOfDaysCheck * -1);
                    SqlCommand com = new SqlCommand("s_pr_get_absent_students");
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    com.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    com.Parameters.Add("@noOfDays", SqlDbType.Int).Value = noOfDaysCheck;
                    com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = (branchId == "-1") ? "%" : branchId.ToString();
                    com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                    DataTable absentStudents = new DataTable();
                    absentStudents = Sqlhelper.GetDatatable(com);
                    if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                    {
                        return absentStudents;
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
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Info.Student> getStudents(string stdid, string batchID, string branchId)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_students_batch");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Std_Id", SqlDbType.VarChar).Value = stdid;
                com.Parameters.Add("@batchID", SqlDbType.VarChar).Value = batchID;
                com.Parameters.Add("@branchId", SqlDbType.VarChar).Value = branchId;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dt = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return StudentHandller.getStudents(dt);
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

        public static DataTable getFacility(int admissionNo)

        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_facilities");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@AdmissionNo", SqlDbType.Int).Value = admissionNo;
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

        public static DataTable getScheduledLect(int admissionNo)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_view_schedule_lect");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Admission", SqlDbType.Int).Value = admissionNo;
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
        public static bool facilityManualRenewal(StudentFacility objFacility, DateTime from, DateTime to, string amount, decimal discount, int InstructorId)
        {
            try
            {
                com = new SqlCommand("s_pr_manual_renewal");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@facilityid", SqlDbType.Int).Value = objFacility.Id;
                com.Parameters.Add("@InstructorId", SqlDbType.Int).Value = InstructorId;
                com.Parameters.Add("@from", SqlDbType.Date).Value = from;
                com.Parameters.Add("@to", SqlDbType.Date).Value = to;
                com.Parameters.Add("@amount", SqlDbType.Decimal).Value = Convert.ToDecimal(amount);
                com.Parameters.Add("@discount", SqlDbType.Decimal).Value = discount;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(com);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
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

        public static DataTable getStudentsByGroupBy(int identifier, string branchID, string strmid = "%", string stdid = "%", string batchid = "%", string packageId = "%")
        {
            try
            {
                com = new SqlCommand("s_pr_get_student_by_group");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@strm_id", SqlDbType.VarChar).Value = strmid;
                com.Parameters.Add("@std_id", SqlDbType.VarChar).Value = stdid;
                com.Parameters.Add("@btch_id", SqlDbType.VarChar).Value = batchid;
                com.Parameters.Add("@package_id", SqlDbType.VarChar).Value = packageId;
                com.Parameters.Add("@identifier", SqlDbType.VarChar).Value = identifier;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable getStudentsByGroupByofEnquiry(int identifier, string con, string status, string branchID)
        {
            try
            {
                com = new SqlCommand("s_pr_get_student_by_group_of_Enquiry");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@identifier", SqlDbType.VarChar).Value = identifier;
                com.Parameters.Add("@counceller", SqlDbType.VarChar).Value = con;
                com.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable getStudentsByGroupBycouncellor(int identifier, string con, string status)
        {
            try
            {
                com = new SqlCommand("s_pr_get_student_by_group_of_Councellor");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@identifier", SqlDbType.Int).Value = identifier;
                com.Parameters.Add("@counceller", SqlDbType.VarChar).Value = con;
                com.Parameters.Add("@status", SqlDbType.VarChar).Value = status;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable getStudents_pending(int identifier, string con, string enq_registered, string branchID)
        {
            try
            {
                com = new SqlCommand("s_pr_get_student_by_group_of_pending");
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@identifier", SqlDbType.VarChar).Value = identifier;
                com.Parameters.Add("@counceller", SqlDbType.VarChar).Value = con;
                com.Parameters.Add("@enq_status", SqlDbType.VarChar).Value = enq_registered;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;


                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dt = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static bool DeactivateStudent(int admision)
        {
            try
            {
                SqlCommand objSqlCmd = new SqlCommand();
                objSqlCmd = new SqlCommand("update STUDENT_ADMISSION set STAM_IS_ACTIVE = 0 where STAM_ADMISSION_NO =" + admision);
                objSqlCmd.CommandType = CommandType.Text;

                return Sqlhelper.ExecuteQuery(objSqlCmd);
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        /// <summary>
        /// This function is to check the type of the package while Renewal. If it is of INSTALLMENT type then package is not suppose to renew.
        /// </summary>
        /// <param name="objFacility"></param>
        /// <returns></returns>
        //public static bool checkPackageType(StudentFacility objFacility)
        //{
        //    try
        //    {
        //        if (objFacility.Package.PackageType != PackageType.INSTALLMENT)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            UICommon.WinForm.showStatus("Package Type is Installment, Cannot Renew this Package.", "Renewal", null);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }


}


