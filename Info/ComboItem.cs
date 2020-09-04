using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassManager.Info
{
    public class ComboItem : Object
    {
        public int key; 
        public string strKey { get; set; }
        public string name { get; set; }
        public object objectValue { get; set; }

        public ComboItem(int key, string name)
        {
            this.key = key;
            this.name = name;
            this.strKey = key.ToString();
        }

        public ComboItem(int key, string name,object objectValue)
        {
            this.key = key;
            this.name = name;
            this.objectValue = objectValue;
            this.strKey = key.ToString();
        }

        public ComboItem(string strKey, string name,object objectValue=null)
        {
            this.strKey = strKey;
            this.name = name;
            this.objectValue = objectValue;
            Int32.TryParse(strKey,out this.key); 
        }
        
        public override string ToString()
        {
            return name;
        }

    }
}
