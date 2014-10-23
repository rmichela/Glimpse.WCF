using System.Linq;
using System.Web.Mvc;
using TestSite.CompositeService;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new CompositeServiceClient())
            {
                ViewData["number"] = string.Join( ", ", client.DoWork());
            }
            return View();
        }
    }
}
