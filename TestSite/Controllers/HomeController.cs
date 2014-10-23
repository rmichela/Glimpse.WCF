using System.Web.Mvc;
using TestSite.SimpleService;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new SimpleServiceClient())
            {
                ViewData["number"] = client.DoWork().ToString();
            }
            return View();
        }
    }
}
