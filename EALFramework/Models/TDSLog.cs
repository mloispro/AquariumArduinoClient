using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{
    public class TDSLog : SensorValLog
    {
        public double TdsVal
        {
            get { return base.Val; }
            set { base.Val = value; }
        }
        public TDSLog() : base() { }
    }

    //public class TDSLog<T> : SensorValLog<T> where T : SensorValLog, new()
    //{
    //    public double TdsVal
    //    {
    //        get { return base.Val; }
    //        set { base.Val = value; }
    //    }
    //    public TDSLog() : base() { }
    //}
    //public class TDSLog : TDSLog<TDSLog>
    //{
    //    public TDSLog() : base() { }
    //}
}
