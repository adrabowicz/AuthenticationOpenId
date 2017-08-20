using System.Web.Mvc;

namespace AngularMvcClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}