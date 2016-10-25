using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumArduinoClient.Models
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
        public string Name { get; set; }
        public string CheckCmd { get; set; }
        public string SetCmd { get; set; }
        public string SetArgs = "/<enabled>/<duration>/<runEvery>/<runNow>/<nextRun>";
        //.../SetMicrosDose/1/2/1209600/0/0 (../enabled/duration/runEvery/runNow/nextRun)

        public static List<string> MicrosMacrosRunDur = new List<string> { "2","5","10","20"};
        public static List<string> PumpRunDur = new List<string> { "30", "60", "90", "120" };

        public static List<NameValue<string,int>> MicrosMacrosRunEveryInHrs = new List<NameValue<string, int>> {
            new NameValue<string, int> {Name= "Daily", Value =24 },
            new NameValue<string, int> {Name= "Every Other Day", Value =49 }
                
        };
        public static List<NameValue<string, int>> PumpRunEveryInHrs = new List<NameValue<string, int>> {
            new NameValue<string, int> {Name= "Weekly", Value =168 },
            new NameValue<string, int> {Name= "Every Other Week", Value =336 },
            new NameValue<string, int> {Name= "Every Three Weeks", Value =504 },
            new NameValue<string, int> {Name= "Monthly", Value =672 }

        };

        public static List<AquaControllerCmd> GetCmds()
        {
            //List<string> acc = new List<string>() { "Water Pump", "Micro Doser", "Macro Doser", "Dry Doser" };
            //return acc;
            List<AquaControllerCmd> cmds = new List<AquaControllerCmd>() {
                new Models.AquaControllerCmd { TheAccType=AccType.WaterPump, Name="Water Pump",CheckCmd= "/CheckWaterChange",SetCmd= "/SetWaterChange" },
                new Models.AquaControllerCmd { TheAccType=AccType.MicrosDoser, Name="Micro Doser",CheckCmd= "/CheckMicrosDose",SetCmd= "/SetMicrosDose" },
                new Models.AquaControllerCmd { TheAccType=AccType.MacrosDoser, Name="Macro Doser",CheckCmd= "/CheckMacrosDose",SetCmd= "" },
                new Models.AquaControllerCmd { TheAccType=AccType.DryDoser, Name="Dry Doser",CheckCmd= "/CheckDryDose",SetCmd= "" },

            };

            return cmds;
        }
    }

   
}
