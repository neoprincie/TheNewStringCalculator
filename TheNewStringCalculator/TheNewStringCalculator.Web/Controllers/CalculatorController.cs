using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheNewStringCalculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Calculator()
        {
            return View();
        }

    }
}
