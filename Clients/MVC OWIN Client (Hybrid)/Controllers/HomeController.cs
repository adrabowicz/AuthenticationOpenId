﻿using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json.Linq;
using Configuration;

namespace MVC_OWIN_Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Claims()
        {
            ViewBag.Message = "Claims";

            var cp = (ClaimsPrincipal)User;

            return View();
        }

        [Authorize]
        public ActionResult Authorization() {

            var cp = (ClaimsPrincipal)User;
            var accessToken = cp.FindFirst("access_token").Value;

            var client = new HttpClient();
            client.SetBearerToken(accessToken);

            var url = Config.CommonApiBaseIP + "/menu/ma_app";
            ViewBag.MenuData = client.GetStringAsync(url).Result;


            ViewBag.UserData = "user data";
            ViewBag.MedData = "med data";

            return View();
        }

        public ActionResult Signout()
        {
            // also possible to pass post logout redirect url via properties
            //var properties = new AuthenticationProperties
            //{
            //    RedirectUri = "http://localhost:2672/"
            //};

            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        [AllowAnonymous]
        public void OidcSignOut(string sid)
        {
            var cp = (ClaimsPrincipal)User;
            var sidClaim = cp.FindFirst("sid");
            if (sidClaim != null && sidClaim.Value == sid)
            {
                Request.GetOwinContext().Authentication.SignOut("Cookies");
            }
        }
    }
}
