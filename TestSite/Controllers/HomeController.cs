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
            using (var client = new CompositeServiceClient())
//            using (var client = new SimpleServiceClient())
            {
                ViewData["number"] = string.Join( ", ", client.DoWork());
            }
            return View();
        }
    }
}
