using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Common.Exceptions
{
    public class FeesPackageExistsException : Exception
    {
        public FeesPackageExistsException(string message)
            : base(message)
        {
            
        }
    }
}
