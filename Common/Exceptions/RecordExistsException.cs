using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Common.Exceptions
{
    public class RecordAlreadyExistsException : Exception
    {
        public RecordAlreadyExistsException(string message)
            : base(message)
        {

        }
    }
}
