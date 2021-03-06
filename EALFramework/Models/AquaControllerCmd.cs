﻿using EALFramework.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Models
{


    public class AquaControllerCmd
    {
        public enum AccType
        {
            WaterPump,
            MicrosDoser,
            MacrosDoser,
            DryDoser
        }

        public AccType TheAccType { get; set; }
        public int AccTypeMap { get; set; }
        public string Name { get; set; }
        public string CheckCmd { get; set; }
        public string SetCmd { get; set; }


        public static string SetUrlTemplate = "/<enabled>/<runDurration>/<runEvery>/<runNow>/<nextRun>";
        //.../SetMicrosDose/1/2/1209600/0/0 (../enabled/duration/runEvery/runNow/nextRun)

        public static List<string> MicrosMacrosRunDur = new List<string> { "2", "5", "10", "20" };
        public static List<string> PumpRunDur = new List<string> { "30", "60", "90", "120" };

        public static List<NameValue<string, int>> MicrosMacrosRunEveryInHrs = new List<NameValue<string, int>> {
            new NameValue<string, int> {Name= "Daily", Value =86400 },
            new NameValue<string, int> {Name= "Every Other Day", Value =172800 }

        };
        public static List<NameValue<string, int>> PumpRunEveryInHrs = new List<NameValue<string, int>> {
            new NameValue<string, int> {Name= "Weekly", Value =604800 },
            new NameValue<string, int> {Name= "Every Other Week", Value =1209600 },
            new NameValue<string, int> {Name= "Every Three Weeks", Value =1814400 },
            new NameValue<string, int> {Name= "Monthly", Value =2419200 }

        };

        public static List<AquaControllerCmd> Cmds = new List<AquaControllerCmd>() {
                new Models.AquaControllerCmd { TheAccType=AccType.WaterPump, Name="Water Pump",CheckCmd= "/CheckWaterChange",SetCmd= "/SetWaterChange", AccTypeMap=5 },
                new Models.AquaControllerCmd { TheAccType=AccType.MicrosDoser, Name="Micros Doser",CheckCmd= "/CheckMicrosDose",SetCmd= "/SetMicrosDose",AccTypeMap=3 },
                new Models.AquaControllerCmd { TheAccType=AccType.MacrosDoser, Name="Macros Doser",CheckCmd= "/CheckMacrosDose",SetCmd= "", AccTypeMap=0 },
                new Models.AquaControllerCmd { TheAccType=AccType.DryDoser, Name="Dry Doser",CheckCmd= "/CheckDryDose",SetCmd= "", AccTypeMap=4 },

            };

        /// <summary>
        /// "/<enabled>/<duration>/<runEvery>/<runNow>/<nextRun>"
        /// </summary>
        public static string FillTemplate(string url, RunData data, bool runNow = false)
        {
            string cmd = Cmds.Find(x => x.AccTypeMap == data.accType).SetCmd;
            string parms = SetUrlTemplate.ReplaceUrlTokens(data);

            string rn = Convert.ToInt32(runNow).ToString();
            parms = parms.Replace("runNow", rn);

            string fullUrl = "http://" + url + cmd + parms;

            return fullUrl;
        }





    }
   
}
