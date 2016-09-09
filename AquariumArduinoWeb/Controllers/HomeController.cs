
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
            List<PHLog> phLogs = PHLogController.GetLogs();

            PHModel model = new PHModel();
            model.Frequency = PHSampleFrequency.Raw;
            model.SampleDate = phLogs.Select(x => x.LogDate.ToShortTimeString()).ToList();
            model.PHVal = phLogs.Select(x => x.PhVal).ToList();

            return View(model);
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