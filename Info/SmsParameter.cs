using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassManager.Info;

namespace ClassManager.Info
{
    [Serializable]
    public class SmsParameter
    {
     
        public int SmsID { get; set; }

     
        public string ToSMS { get; set; }

        
        public string ToEmail { get; set; }

        public string Body { get; set; }

        
        public string Type { get; set; }

 
        public DateTime SendTime { get; set; }

       
        public string ResponseID { get; set; }

    
        public string Status { get; set; }


        public string Template { get; set; }

    }
}
