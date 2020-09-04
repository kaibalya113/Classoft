using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Info
{
    [Serializable]
    public class MarkSheet
    {
        public int Id { get; set; }
        public int MarksObtain { get; set; }
        public TestMaster TestMaster { get; set; }
        public StudentMaster Student { get; set; }
        




    }
}
