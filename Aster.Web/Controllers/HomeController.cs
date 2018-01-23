using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aster.Web.Models;
using Aster.Data;

namespace Aster.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            var message = "";
            var dataSettingManager = new DataSettingsManager();
            var dataSettings = dataSettingManager.LoadSettings();
            
            message += dataSettings.DataConnectionString + Environment.NewLine;
            message += dataSettings.DataProvider + Environment.NewLine;

            message += "This is really coool to work with command line. Eacth change is tracked";


            ViewData["Message"] = "Your application description page." + Environment.NewLine + message;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
