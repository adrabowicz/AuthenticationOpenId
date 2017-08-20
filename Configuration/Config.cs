
namespace Configuration
{
    public static class Config
    {
        public static string IdentityServerBaseIP = "http://localhost:5000";
        public static string IdentityServerIdentityIP = "http://localhost:5000/identity";
        public static string IdentityServerTokenIP = "http://localhost:5000/identity/connect/token";
        public static string IdentityServerUserInfoIP = "http://localhost:5000/identity/connect/userinfo";
        public static string IdentityServerWellKnownIP = "http://localhost:5000/identity/.well-known/openid-configuration";

        public static string CidmApiBaseIP = "http://localhost:42001";
        public static string CidmApiTestIP = CidmApiBaseIP + "/test";

        public static string CommonApiBaseIP = "http://localhost:42002";
        public static string CommonApiTestIP = CommonApiBaseIP + "/test";

        public static string KpApiBaseIP = "http://localhost:42003";
        public static string KpApiTestIP = KpApiBaseIP + "/test";

        public static string MvcHybridAppBaseIP = "http://localhost:42020/";

        public static string AngularJsBaseIP = "http://localhost:42030/";
        public static string AngularMvcBaseIP = "http://localhost:42040/";

        public static string XOneRedirectUri = AngularMvcBaseIP + "callback.html";
    }
}
