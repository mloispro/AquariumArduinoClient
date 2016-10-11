using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    public class TDSLog
    {
        
        public DateTime LogDate { get; set; }
        public double TdsVal { get; set; }

        public TDSLog()
        {
        }
        public TDSLog(double phVal, DateTime logDate)
        {
            this.TdsVal = phVal;
            this.LogDate = logDate;
        }


    }
}
