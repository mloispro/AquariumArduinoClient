using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{

    public class PHLog : SensorValLog
    {
        public double PhVal
        {
            get { return base.Val; }
            set { base.Val = value; }
        }
        public PHLog() : base() { }

    }

    //public class PHLog : PHLog<PHLog>
    //{
    //    public PHLog() : base() { }
    //}


    //public class PHLog<T> : SensorValLog<T> where T : SensorValLog, new()
    //{
    //    public double PhVal
    //    {
    //        get { return base.Val; }
    //        set { base.Val = value; }
    //    }
    //    public PHLog() : base() { }

    //    //public PHLog(double phVal, DateTime logDate)
    //    //{
    //    //    this.PhVal = phVal;
    //    //    this.LogDate = logDate;
    //    //}

    //}
}
