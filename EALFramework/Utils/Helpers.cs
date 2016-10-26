using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using EALFramework.Models;

namespace EALFramework.Utils
{
    public static class Helpers
    {
        public static DateTime ConvArduinoTimeToDT(this int time)
        {
            var newdt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(time);
      
            return newdt;
        }
        public static int ConvDTToArduinoTime(this DateTime time)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan span = (time - epoch);
            double unixTime = span.TotalSeconds;

            return (int)unixTime;
        }
        public static TimeSpan ConvArduinoTimeToTS(this int time)
        {
            var t = TimeSpan.FromSeconds(time);
            return t;
        }

        public static NameValue<string, int> FindClosest(this List<NameValue<string, int>> list, double val)
        {
            var closest = list.OrderBy(x => Math.Abs(x.Value - val)).First();
            return closest;
        }
        public static string FindClosest(this List<string> list, int val)
        {
            string closest = list.OrderBy(x => Math.Abs(int.Parse(x) - val)).First();
            return closest;
        }

        /// <summary>
        /// ex. "/<enabled>/<runDurration>/<runEvery>/<runNow>/<nextRun>"
        /// </summary>
        public static string ReplaceUrlTokens<T>(this string template, T data)
        {
            
            string temp = template.Replace("<", "").Replace(">","");
            List<string> parms = temp.Split('/').ToList();
            parms.Remove("");

            string url = temp;
            foreach (string parm in parms)
            {
               var prop = data.GetType().GetField(parm);
                if (prop != null)
                {
                    var propVal = prop.GetValue(data);
                    string val = "";
                    if(propVal is bool)
                    {
                        val = Convert.ToInt32(propVal).ToString();
                    }else
                    {
                        val = propVal.ToString();
                    }
                    url = url.Replace(parm, val);
                }
            }
            
            return url;
        }
    }
}
