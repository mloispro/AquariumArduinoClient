using Chart.Mvc.ComplexChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquariumArduinoWeb.Models
{

    public class PHModel
    {
        public SampleFrequency Frequency { get; set; }
        public List<double> PHVal { get; set; }
        public List<string> SampleDate { get; set; }
        public double CurrentPH { get; set; }
        public double DailyAvgPH { get; set; }

        //daily
        public List<double> PHDailyVal { get; set; }
        public List<string> SampleDay { get; set; }

        //hourly daily
        public List<double> PHHourlyDailyVal { get; set; }

    }
}