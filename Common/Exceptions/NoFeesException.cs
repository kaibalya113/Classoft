using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Common.Exceptions
{
    public class NoFeesException : Exception
    {

        public NoFeesException(string message)
            : base(message)
        {

        }

    }
}
