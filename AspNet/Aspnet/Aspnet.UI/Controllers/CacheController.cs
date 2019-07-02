using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspnet.UI.Controllers
{
    public class CacheController : Controller
    {
        // GET: Cache]
        //[OutputCache(Duration = 120, VaryByParam = "Name", Location = "ServerAndClient")]
        public ActionResult Index()
        {
            return View();
        }
    }
}