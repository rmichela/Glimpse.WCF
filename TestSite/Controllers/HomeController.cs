using System;
using System.Threading;
using System.Web.Mvc;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Thread.Sleep(new Random().Next(3000));
            return View();
        }
    }
}
