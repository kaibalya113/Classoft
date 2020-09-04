using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Common.Exceptions
{
     public class CustomErrorException : Exception
    {
        public CustomErrorException(int errorCode):
            base(ExceptionHandller.getErrorMessage(errorCode))   
        {
            
        }
    }
}
