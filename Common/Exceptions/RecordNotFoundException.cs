using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Common.Exceptions
{
    public class RecordNotFoundException : Exception
    {     

        public RecordNotFoundException(String message)
            : base(message)
        {
        }

    }
}
