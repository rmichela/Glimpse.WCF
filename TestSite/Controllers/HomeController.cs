using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestSite.CompositeService;
using TestSite.SimpleService;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ints = new List<int>();
            using (var client = new SimpleServiceClient())
            {
                ints.Add(client.DoWork());
            }
            using (var client = new CompositeServiceClient())
            {
                ints.AddRange(client.DoWork());
            }

            ViewData["number"] = string.Join(", ", ints);
            return View();
        }
    }
}
