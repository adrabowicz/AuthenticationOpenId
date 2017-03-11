using System.Net.Http;
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
            var accessToken = cp.FindFirst("access_token").Value;

            var url = Config.CommonApiBaseIp + "/menu/ma_app";
            var result = MakeApiCallToGetData(accessToken, url);

            return View();
        }

        private static string MakeApiCallToGetData(string accessToken, string url)
        {
            var client = new HttpClient();
            //client.SetBearerToken(accessToken);
            return client.GetStringAsync(url).Result;
        }

        [Authorize]
        public async Task<ActionResult> CallApi()
        {
            var token = (User as ClaimsPrincipal).FindFirst("access_token").Value;

            var client = new HttpClient();
            client.SetBearerToken(token);

            var result = await client.GetStringAsync("Constants.AspNetWebApiSampleApi" + "identity");
            ViewBag.Json = JArray.Parse(result.ToString());

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
