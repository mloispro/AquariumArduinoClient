
using EALFramework.Models;
using EALFramework.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EALFramework.Controllers
{


    public class AquaController
    {
        private static DateTime _lastRunDataSave;

        public static RunData MicrosDoserRunData;
        public static RunData MacrosDoserRunData;
        public static RunData WaterPumpRunData;
        public static RunData DryDoserRunData;

        public static void SaveRunData()
        {

            List<RunData> data = GetAllRunData(false);
            FileIO.SaveJson(data, Globals.RunDataFileName);


            //SaveRunData(MicrosDoserRunData);
            //SaveRunData(MacrosDoserRunData);
            //SaveRunData(WaterPumpRunData);
            //SaveRunData(DryDoserRunData);

            //if (DateTime.Now > _lastRunDataSave.AddMinutes(Globals.SaveRunDataEveryMin))
            //{
            //    await FileIO.SaveJsonObject(MicrosDoserRunData, Globals.RunDataFileName);
            //    _lastRunDataSave = DateTime.Now;
            //}
        }
        //public static async void SaveRunData(RunData data)
        //{
        //    await FileIO.SaveJsonObject(data, Globals.RunDataFileName);
        //}
        public static void LoadRunData()
        {
            var runData = FileIO.GetJson<RunData>(Globals.RunDataFileName);

            foreach (var data in runData)
            {
                var cmd = AquaControllerCmd.Cmds.Find(x => x.AccTypeMap == data.accType);
                if (cmd.TheAccType == AquaControllerCmd.AccType.MicrosDoser)
                    MicrosDoserRunData = data;
                else if (cmd.TheAccType == AquaControllerCmd.AccType.WaterPump)
                    WaterPumpRunData = data;
                else if (cmd.TheAccType == AquaControllerCmd.AccType.DryDoser)
                    DryDoserRunData = data;
                else if (cmd.TheAccType == AquaControllerCmd.AccType.MacrosDoser)
                    MacrosDoserRunData = data;
            }
        }
        public static void ParseRunData(string json)
        {
            RunData data = Deserialize(json);
            if (data == null) return;
            var cmd = AquaControllerCmd.Cmds.Find(x => x.AccTypeMap == data.accType);
            if (cmd.TheAccType == AquaControllerCmd.AccType.MicrosDoser)
                MicrosDoserRunData = data;
            else if (cmd.TheAccType == AquaControllerCmd.AccType.WaterPump)
                WaterPumpRunData = data;
            else if (cmd.TheAccType == AquaControllerCmd.AccType.DryDoser)
                DryDoserRunData = data;
            else if (cmd.TheAccType == AquaControllerCmd.AccType.MacrosDoser)
                MacrosDoserRunData = data;
            else
                throw new Exception("Aquarium Accessory Not Found! accType: " + data.accType);

            SaveRunData();
        }

        public static List<RunData> GetAllRunData(bool loadFromFile = true)
        {
            //load from file
            if (loadFromFile)
                LoadRunData();

            List<RunData> data = new List<RunData>();
            if (MicrosDoserRunData != null)
                data.Add(MicrosDoserRunData);
            if (WaterPumpRunData != null)
                data.Add(WaterPumpRunData);
            if (DryDoserRunData != null)
                data.Add(DryDoserRunData);
            if (MacrosDoserRunData != null)
                data.Add(MacrosDoserRunData);

            return data;
        }

        public static RunData Deserialize(string json)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Error = HandleDeserializationError
            };

            RunData obj = JsonConvert.DeserializeObject<RunData>(json, settings);
            return obj;
        }
        public static void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }
    }
}
