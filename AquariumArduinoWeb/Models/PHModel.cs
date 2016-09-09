using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquariumArduinoWeb.Models
{
    public enum PHSampleFrequency
    {
        Raw,
        Hourly,
        Daily,
        Weekly
    }
    public class PHModel
    {
        public PHSampleFrequency Frequency { get; set; }
        public List<double> PHVal { get; set; }
        public List<string> SampleDate { get; set; }

    }
}