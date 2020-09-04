using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassManager.Info
{
    [Serializable]
    public class StudMigration
    { 
        public Stream Stream { get; set; }

        public Standard Course { get; set; }

        public string Batch { get; set; }

        public int BrachId { get; set; }
    }
}
