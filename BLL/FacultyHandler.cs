using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ClassManager.DAL;
using ClassManager.Common.Exceptions;
using ClassManager.Info;

namespace ClassManager.BLL
{
    public class FacultyHandler
    {
        static SqlTransaction objTrans;
        static SqlCommand objSqlCmd;
        
        public static bool saveFaculty(Info.Faculty objFaculty)
        {
            try
            {
                objSqlCmd = new SqlCommand("s_pr_create_faculty");
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.Parameters.Add("@F_NAME", SqlDbType.VarChar).Value = objFaculty.Name;
                objSqlCmd.Parameters.Add("@F_ADDRESS", SqlDbType.VarChar).Value = objFaculty.Address;
                objSqlCmd.Parameters.Add("@F_CONTACT_NO", SqlDbType.VarChar).Value = objFaculty.ContactNo;
                objSqlCmd.Parameters.Add("@F_EMAILID", SqlDbType.VarChar).Value = objFaculty.EmailId;
                objSqlCmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = objFaculty.branchId;
                objSqlCmd.Parameters.Add("@biometric_id", SqlDbType.Int).Value = objFaculty.biometricId;
                objSqlCmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = objFaculty.DOb;
                objSqlCmd.Parameters.Add("@PANCARD", SqlDbType.VarChar).Value = objFaculty.Pancard;
                objSqlCmd.Parameters.Add("@ADHARCARD", SqlDbType.VarChar).Value = objFaculty.AdharCard;
                objSqlCmd.Parameters.Add("@QUALIFICATION", SqlDbType.VarChar).Value = objFaculty.Qualification;
                objSqlCmd.Parameters.Add("@RESUME", SqlDbType.VarChar).Value = objFaculty.Resume;
                objSqlCmd.Parameters.Add("@PhotoURL", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                objSqlCmd.Parameters.Add("@F_ROLL_NO", SqlDbType.Int).Direction = ParameterDirection.Output;
                objSqlCmd.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                objTrans = Sqlhelper.getConnection().BeginTransaction();
                objSqlCmd.Transaction = objTrans;

                Sqlhelper.ExecuteNonQuery(objSqlCmd, true);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objSqlCmd))
                {
                    objTrans.Commit();
                    objFaculty.FacultyID = (int)objSqlCmd.Parameters["@F_ROLL_NO"].Value;
                    try
                    {
                        string photoPath = Info.SysParam.getValue<String>(Info.SysParam.Parameters.PHOTO_PATH);
                        objFaculty.ImgPhoto.Save(photoPath + objSqlCmd.Parameters["@PhotoURL"].Value.ToString());
                    }
                    catch (Exception ex)
                    {

                    }
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }

            }
            catch (Exception ex)
            {

                if (objTrans != null)
                {
                    objTrans.Rollback();
                }

                objTrans = null;

                throw ex;
            }
            }

        public static List<Info.Student> getMembers(int id)
        {
            string query = "select distinct(STMT_ADMISSION_NO), STMT_FNAME ,STMT_MNAME, STMT_LNAME from STUDENT_FACILITIES inner join STUDENT_MASTER on STFL_ADMISSION_NO = STMT_ADMISSION_NO where STFL_INSTRUCTIR_ID=" + id + "";
            DataTable dtStandards = Sqlhelper.GetDatatable(query);



            return Info.Student.getStudents(dtStandards); ;
        }

        //}
        //public static Student GetStudent(int? AdmissionNo, String contactNo, String RollNo, int? BiometricId, int branchId, int? membershipId = null)
        //{
        //    try
        //    {
        //        com = new SqlCommand("s_pr_get_student");
        //        com.CommandType = CommandType.StoredProcedure;

        //        com.Parameters.Add("@RollNo", SqlDbType.VarChar).Value = (RollNo == null) ? (object)DBNull.Value : (object)RollNo;
        //        com.Parameters.Add("@AdmissionNo", SqlDbType.VarChar).Value = (AdmissionNo == null) ? (object)DBNull.Value : (object)AdmissionNo;
        //        com.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = (contactNo == null) ? (object)DBNull.Value : (object)contactNo;
        //        com.Parameters.Add("@MembershipId", SqlDbType.VarChar).Value = (membershipId == null) ? (object)DBNull.Value : (object)membershipId;
        //        com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchId;



        //        com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

        //        DataTable dtStudent = Sqlhelper.GetDatatable(com);
        //        if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
        //        {
        //            if (dtStudent.Rows.Count > 0)
        //            {
        //                Student objStudent = Student.getStudent(dtStudent.Rows[0]);
        //                objStudent.Fees = FeesHandller.getFeesDetails(objStudent.AdmissionNo);
        //                objStudent.Facilities = StudentHandller.getFacilities(objStudent.AdmissionNo);
        //                objStudent.Courses = StudentHandller.getCourses(objStudent.AdmissionNo);
        //                //objStudent.Facilities = StudentHandller.getFacilities(objStudent.Facilities);
        //                if (objStudent.Courses != null && objStudent.Courses.Count > 0)
        //                {
        //                    objStudent.Course = objStudent.Courses.OrderByDescending(c => c.AdmissinoDate).FirstOrDefault<Course>();
        //                }
        //                return objStudent;
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
        //        Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
        //        throw ex;
        //    }
        //}
        public static List<ComboItem> getFacultList(string branchId)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_disp_faculties");
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchId;

                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                DataTable dtStudents = Sqlhelper.GetDatatable(com);
                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(com))
                {
                    List<ComboItem> lstStudents = new List<ComboItem>();
                    foreach (DataRow dr in dtStudents.Rows)
                    {
                        lstStudents.Add(new ComboItem(Convert.ToInt32(dr["FCLT_ID"]), dr["NAME"].ToString()));
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
        public static DataTable getFacultyProgram(string id)
        {
            try
            {
                // string query = "select distinct STFL_ADMISSION_NO as ID, STFL_FACILITY_NAME as FacilityName, STFL_FROM_DATE as FromDate, STFL_TO_DATE as ToDate , FCLT_MARK_SESSION from STUDENT_FACILITIES where STFL_INSTRUCTIR_ID = " + id+"";
                //  string query = "select DISTINCT(STFL_ADMISSION_NO), STFL_FACILITY_NAME as FacilityName, STFL_FROM_DATE as FromDate, STFL_TO_DATE as ToDate, FCLT_MARK_SESSION, ATTD_IN_TIME, STFL_PACKAGE_ID from STUDENT_FACILITIES inner join ATTENDANCE on ATTD_ADMISSION_NO = STFL_ADMISSION_NO where STFL_INSTRUCTIR_ID = " + id + " and   CAST(ATTD_IN_TIME AS DATE) = CAST(GETDATE() AS DATE)";
                string query = "select STMT_FNAME, STFL_ADMISSION_NO, STFL_FACILITY_NAME as FacilityName, STFL_FROM_DATE as FromDate, STFL_TO_DATE as ToDate, " 
                                +" ATTD_IN_TIME, STFL_PACKAGE_ID from STUDENT_FACILITIES inner join ATTENDANCE on ATTD_ADMISSION_NO = STFL_ADMISSION_NO  inner "
                                +"join STUDENT_MASTER on STMT_ADMISSION_NO = STFL_ADMISSION_NO "
                                +"where STFL_INSTRUCTIR_ID = "+id+"";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);



                return dtStandards;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public static DataTable checkFacultyStatus(string packageID, int instructureID, string studentID, string date, DateTime dateTIme, string remark, bool mark)
        {
            try
            {
                // string query = "select distinct STFL_ADMISSION_NO as ID, STFL_FACILITY_NAME as FacilityName, STFL_FROM_DATE as FromDate, STFL_TO_DATE as ToDate , FCLT_MARK_SESSION from STUDENT_FACILITIES where STFL_INSTRUCTIR_ID = " + id+"";
                //  string query = "select DISTINCT(STFL_ADMISSION_NO), STFL_FACILITY_NAME as FacilityName, STFL_FROM_DATE as FromDate, STFL_TO_DATE as ToDate, FCLT_MARK_SESSION, ATTD_IN_TIME, STFL_PACKAGE_ID from STUDENT_FACILITIES inner join ATTENDANCE on ATTD_ADMISSION_NO = STFL_ADMISSION_NO where STFL_INSTRUCTIR_ID = " + id + " and   CAST(ATTD_IN_TIME AS DATE) = CAST(GETDATE() AS DATE)";
                string query = "select * from session where DATE=CAST(GETDATE() AS DATE) and PACKAGE_ID=" + packageID + " and MEMBER_ID=" + studentID + "";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);



                return dtStandards;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //getFacultyAttendance
        public static DataTable getFacultySalary(string name)
        {
            try
            {
                string query = "select pdex_date as Date, PDEX_AMOUNT as Amount, PDEX_PAYMENT_MODE as Mode, ACT_NAME as PaymentMode, PDEX_DESC as Description  from PAID_EXPENSES inner join GLB_ACCOUNTS on PDEX_ACCNT_ID = ACT_ID where PDEX_PAID_TO= '" + name + "'";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);
                return dtStandards;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataTable getFacultyAttendance(string id)
        {
            try
            {
                string query = "select ATTD_DATE, ATTD_STATUS, ATTD_BIOMETRIC_ID , cast(ATTD_IN_TIME as time)[time], cast(ATTD_OUT_TIME as time)[time], DATEDIFF(HOUR, ATTD_IN_TIME, ATTD_OUT_TIME) TotalTime from ATTENDANCE where ATTD_ADMISSION_NO = " + id + " order by 1 desc";
                DataTable dtStandards = Sqlhelper.GetDatatable(query);
                return dtStandards;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataTable showAllFaculties(string branchID) // from  faculty table
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_disp_faculties");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFaculty = Sqlhelper.GetDatatable(com);

                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    return dtFaculty;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }

        public static DataTable getFaculties(string branchID) //from faculty table
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_disp_faculties");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFaculty = DAL.Sqlhelper.GetDatatable(com);
                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    return dtFaculty;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static bool updateFacultyStatus(string packageID, int instructureID, string studentID, string date, DateTime dateTIme, string remark, bool mark)
        {
            try
            {
                objSqlCmd = new SqlCommand("s_pr_insert_session");
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.Parameters.Add("@packageID", SqlDbType.VarChar).Value = packageID;
              //  objSqlCmd.Parameters.Add("@inTime", SqlDbType.VarChar).Value = inTime;
                objSqlCmd.Parameters.Add("@instructureID", SqlDbType.Int).Value = instructureID;
                objSqlCmd.Parameters.Add("@studentID", SqlDbType.VarChar).Value = studentID;
                //objSqlCmd.Parameters.Add("@BRANHC_ID", SqlDbType.Int).Value = branchId;
                objSqlCmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
                objSqlCmd.Parameters.Add("@remark", SqlDbType.VarChar).Value = remark;
                 objSqlCmd.Parameters.Add("@dateTIme", SqlDbType.DateTime).Value = dateTIme;
                objSqlCmd.Parameters.Add("@mark", SqlDbType.Bit).Value = mark;
                objSqlCmd.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteQuery(objSqlCmd);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objSqlCmd))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static bool updatefacultyPersnlDtl(Info.Faculty objFaculty)
        {
            try
            {
                objTrans = Sqlhelper.getConnection().BeginTransaction();
                objSqlCmd = new SqlCommand("s_pr_update_faculty");
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.Transaction = objTrans;
                objSqlCmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = objFaculty.Name;
                objSqlCmd.Parameters.Add("@ADMISSIN_NO", SqlDbType.Int).Value = objFaculty.FacultyID;
                objSqlCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = objFaculty.Address;
                objSqlCmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = objFaculty.ContactNo;
                objSqlCmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = objFaculty.EmailId;
                objSqlCmd.Parameters.Add("@branchId", SqlDbType.Int).Value = objFaculty.branchId;
                objSqlCmd.Parameters.Add("@biometricId", SqlDbType.Int).Value = objFaculty.BiometricId;
                objSqlCmd.Parameters.Add("@DOB", SqlDbType.Date).Value = objFaculty.DOb;
                objSqlCmd.Parameters.Add("@Resume", SqlDbType.VarChar).Value = objFaculty.Resume;
                objSqlCmd.Parameters.Add("@AddressProof", SqlDbType.VarChar).Value = objFaculty.AddressProof;
                objSqlCmd.Parameters.Add("@IdProof", SqlDbType.VarChar).Value = objFaculty.IDPROOF;
                objSqlCmd.Parameters.Add("@AdharCard", SqlDbType.VarChar).Value = objFaculty.AdharCard;
                objSqlCmd.Parameters.Add("@Pancard", SqlDbType.VarChar).Value = objFaculty.Pancard;
                objSqlCmd.Parameters.Add("@Qualification", SqlDbType.VarChar).Value = objFaculty.Qualification;
                objSqlCmd.Parameters.Add("@PhotoURL", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                objSqlCmd.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                Sqlhelper.ExecuteNonQuery(objSqlCmd, true);

                if (objSqlCmd.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objSqlCmd))
                    {

                        try
                        {
                            string pathToSave = Info.SysParam.getValue<string>(Info.SysParam.Parameters.PHOTO_PATH);

                            objFaculty.ImgPhoto.Save(pathToSave + objSqlCmd.Parameters["@PhotoURL"].Value.ToString());
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    objTrans.Commit();
                    return true;
                }

                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }


            }
            catch (Exception ex)
            {

                if (objTrans != null)
                {
                    objTrans.Rollback();
                }

                objTrans = null;

                throw ex;
            }

        }


        public static bool Deletefaculty(Int32 admissionNo, string Name, string Contact, int Branch)
        {

            try
            {

                objSqlCmd = new SqlCommand("s_pr_delete_faculty");
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.Parameters.Add("@ADMISSIN_NO", SqlDbType.Int).Value = admissionNo;
                objSqlCmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                objSqlCmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = Contact;
                objSqlCmd.Parameters.Add("@branchId", SqlDbType.Int).Value = Branch;
                objSqlCmd.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;

                Sqlhelper.ExecuteQuery(objSqlCmd);

                if (ClassManager.Common.Exceptions.ExceptionHandller.HandleDBError(objSqlCmd))
                {
                    return true;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }

        }
        public static Info.Faculty getFacultiesByID(int facID, int branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_faculty");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@FacultyId", SqlDbType.Int).Value = facID;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                DataTable dtFaculty = Sqlhelper.GetDatatable(com);

                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    if (dtFaculty.Rows.Count > 0)
                    {
                        return Info.Faculty.getFaculty(dtFaculty.Rows[0]);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static List<Info.Faculty> getFacultyList(int branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_faculties");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                DataTable dtFaculty = Sqlhelper.GetDatatable(com);

                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    if (dtFaculty.Rows.Count > 0)
                    {
                        return Info.Faculty.getFaculties (dtFaculty);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }


        public static Info.Faculty getFacultiesByBiomID(int facID, int branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_get_faculty_by_biometricID");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@FacultyId", SqlDbType.Int).Value = facID;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;
                DataTable dtFaculty = Sqlhelper.GetDatatable(com);

                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    if (dtFaculty.Rows.Count > 0)
                    {
                        return Info.Faculty.getFaculty(dtFaculty.Rows[0]);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
        public static DataTable GetAllSubjects(int Crse, string branchID)
        {
            try
            {
                SqlCommand com = new SqlCommand("s_pr_disp_subjects");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@stdId", SqlDbType.Int).Value = Crse;
                com.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;
                com.Parameters.Add(Common.Constants.RETURN_CODE_VARIABLE, SqlDbType.Int).Direction = ParameterDirection.Output;


                DataTable dtSub = Sqlhelper.GetDatatable(com);

                if (com.Parameters[Common.Constants.RETURN_CODE_VARIABLE].Value.ToString().Equals("1"))
                {
                    return dtSub;
                }
                else
                {
                    throw new Common.Exceptions.InvalidReturnCodeException(objSqlCmd);
                }

            }
            catch (Exception ex)
            {
                Common.Log.LogError(ex, new System.Diagnostics.StackFrame(0).GetMethod().Name);
                throw ex;
            }
        }
    }
}
