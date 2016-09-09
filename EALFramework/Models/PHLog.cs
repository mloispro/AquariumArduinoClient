using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    public class PHLog
    {
        
        public DateTime LogDate { get; set; }
        public double PhVal { get; set; }

        public PHLog()
        {
        }
        public PHLog(double phVal, DateTime logDate)
        {
            this.PhVal = phVal;
            this.LogDate = logDate;
        }


    }
}
