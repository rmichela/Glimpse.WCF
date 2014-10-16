using System.Threading;
using System.Web.Mvc;
using Glimpse.WCF;
using TestSite.SimpleService;

namespace TestSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TimeWaster.StartMasterWaste();
            var waster = new TimeWaster();
            waster.WasteTime();
            Thread.Sleep(500);
            waster.WasteTime();
            TimeWaster.EndMasterWaste();

            using (var client = new SimpleServiceClient())
            {
                ViewData["number"] = client.DoWork().ToString();
            }
            return View();
        }
    }
}
