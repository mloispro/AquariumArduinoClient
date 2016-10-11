
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chart.Mvc.ComplexChart;
using EALFramework.Models;
using AquariumArduinoWeb.Models;

namespace EALFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _SensorCharts()
        {
            return PartialView("_SensorCharts",PopulateModel());
        }

        private WaterSensorModel PopulateModel()
        {
            WaterSensorModel model = new WaterSensorModel();

            List<PHLog> phLogs = WaterSensorController.GetHourlySummaryPHLogs();

            model.PHModel.Frequency = SampleFrequency.Hourly;
            model.PHModel.SampleDate = phLogs.Select(x => string.Format("{0:htt}", x.LogDate)).ToList();
            model.PHModel.PHVal = phLogs.Select(x => Math.Round(x.PhVal, 2)).ToList();
            model.PHModel.CurrentPH = WaterSensorController.CurrentPH;
            model.PHModel.DailyPH = WaterSensorController.GetDailyPh();

            List<TDSLog> tdsLogs = WaterSensorController.GetHourlySummaryTdsLogs();

            model.TDSModel.Frequency = SampleFrequency.Hourly;
            model.TDSModel.SampleDate = tdsLogs.Select(x => string.Format("{0:htt}", x.LogDate)).ToList();
            model.TDSModel.TDSVal = tdsLogs.Select(x => Math.Round(x.TdsVal, 0)).ToList();
            model.TDSModel.CurrentTDS = WaterSensorController.CurrentTDS;
            model.TDSModel.DailyTDS = WaterSensorController.GetDailyTds();

            return model;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}