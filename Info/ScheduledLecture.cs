using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
   public class ScheduledLecture
    {
        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public string Day { get; set; }

        public string AdmissionNo { get; set; }

        public Int64 BiometricId { get; set;}

        public int Standard { get; set; }
    }
}
