using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ClassManager.Common.Exceptions
{
    public class InvalidReturnCodeException : Exception
    {
        public InvalidReturnCodeException(string message)
            : base(message)
        {

        }

        public InvalidReturnCodeException(SqlCommand com)
            : base("Error verifying backend retrun error code " + com.Parameters[Constants.RETURN_CODE_VARIABLE].Value.ToString() +" from " + com.CommandText)
        {
            
        }
    }
}
