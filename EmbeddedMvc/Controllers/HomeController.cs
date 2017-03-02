using System.Security.Claims;
using System.Web.Mvc;

namespace EmbeddedMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            var user = User as ClaimsPrincipal;
            var claims = user.Claims;
            return View(claims);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}