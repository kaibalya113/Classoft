using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Info
{
    [Serializable]
    public class FeesCollection
    {
        public int ReceiptNo { get; set; }

        public string RollNo { get; set; }
        
        public string StudName { get; set; }

        public string Stream { get; set; }
        
        public string Standard { get; set; }

        public string Batch { get; set; }
        
        public Decimal FeesPaid { get; set; }

        public DateTime LastPayDate { get; set; }

         public DateTime FromDate { get; set; }
    
          public DateTime ToDate { get; set; }

        //public int Day { get; set; }

    }
}
