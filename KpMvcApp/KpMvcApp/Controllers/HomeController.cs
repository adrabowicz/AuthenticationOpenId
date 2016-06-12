using System.Web.Mvc;
using System.Security.Claims;

namespace KpMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View((User as ClaimsPrincipal).Claims);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}