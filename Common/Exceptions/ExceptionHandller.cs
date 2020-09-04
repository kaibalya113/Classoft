using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ClassManager.Common.Exceptions
{
    public class ExceptionHandller
    {
        static Dictionary<Int32, string> ErrorMessages = new Dictionary<int, string>();

        static ExceptionHandller()
        {
            ErrorMessages.Add(101, "Error code message");
        }

        public static string getErrorMessage(int ErrorCode)
        {
            try
            {
                   return ErrorMessages[ErrorCode];
            }
            catch (Exception)
            {

                return "Error has Occured";
            }
            
        }

        public static bool HandleDBError(ErrorCodes returnedCode,SqlCommand command)
        {
            try
            {
                switch(returnedCode)
                {
                    case ErrorCodes.SUCCESS: return true; 
                    case ErrorCodes.DUPLICATE_RECORD: throw new RecordAlreadyExistsException("Record Already Exists from SP "+command.CommandText);
                    case ErrorCodes.RECORD_IN_USER: throw new  RecordInUseException("Can not delete record as it is used in child tables " + command.CommandText);
                    case ErrorCodes.FATAL : throw new Exception("Fatal code from backend "+ command.CommandText);
                    case ErrorCodes.DUPLICATE_ROLLNO:throw new Exception("Roll No already exist.");
                    case ErrorCodes.DUPLICATE_MEMSHIP_N: throw new DuplicateMembershipNoException("Membership No already exist.");
                    case ErrorCodes.RECORD_NOT_EXIST:throw new Exception("Income Entry of Fees is not available");
                       
                    default: throw new CustomErrorException(Convert.ToInt32(command.Parameters[Constants.RETURN_CODE_VARIABLE].Value));
                }
            }
            catch (Exception)
            {   
                throw;
            }
        }

        public static bool HandleDBError(SqlCommand com)
        {
            try
            {   
                ErrorCodes returnCode = ErrorCodes.FATAL;
                if (Enum.TryParse<ErrorCodes>(com.Parameters[Constants.RETURN_CODE_VARIABLE].Value.ToString(), out returnCode))
                {
                    return HandleDBError(returnCode, com);
                }
                else
                {
                    throw new Exception("Invalid return code from backend");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
