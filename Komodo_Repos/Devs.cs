using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    public enum DevType
    {
        Web = 1,
        Software = 2
    }
    //POCO
    public class Devs
    {
        //Devs Properties 
        public string Name { get; set; }
        public string Dev_ID { get; set; }
        public bool HasAccessToPlural { get; set; }

        public DevType TypeOfDev { get; set; }

        public Devs(){ }
        
        public Devs(string name, string dev_ID, bool hasAccessToPlural, DevType dev)
        {
            Name = name;    
            Dev_ID = dev_ID;    
            HasAccessToPlural = hasAccessToPlural;
            TypeOfDev = dev;

        }
    }
}
