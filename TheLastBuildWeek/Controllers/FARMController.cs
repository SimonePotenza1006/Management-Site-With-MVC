using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TheLastBuildWeek.Controllers
{
    [Authorize(Roles = "Farmacista")]
    public class FARMController : Controller
    {
    
        // GET: FARM
        public ActionResult Index()
        {
            return View();
        }
    }
}