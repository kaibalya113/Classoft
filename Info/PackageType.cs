using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Info
{
    public enum PackageType
    {
        MONTHLY = 1, 
        HALF_YEARLY=6, 
        QUARTERLY=3, 
        LUMPSUM=2, 
        C=4, 
        O=5, 
        INSTALLMENT=8,
        ONE_TIME=7,
        YEARLY = 9
    }
}
