using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Common.Exceptions
{
    class RecordInUseException : Exception
    {
        private string p;

        public RecordInUseException(string message)
            : base(message)
        {

        }
    }
}
