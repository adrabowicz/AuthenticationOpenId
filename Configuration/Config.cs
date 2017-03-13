
namespace Configuration
{
    public static class Config
    {
        public static string IdentityServerBaseIp = "http://localhost:5000";
        public static string IdentityServerIdentityIp = IdentityServerBaseIp + "/identity";
        public static string IdentityServerConnectTokenIp = IdentityServerBaseIp + "/connect/token";

        public static string CidmApiBaseIp = "http://localhost:42001";
        public static string CidmApiTestIp = CidmApiBaseIp + "/test";

        public static string CommonApiBaseIp = "http://localhost:42002";
        public static string CommonApiTestIp = CommonApiBaseIp + "/test";

        public static string KpApiBaseIp = "http://localhost:42003";
        public static string KpApiTestIp = KpApiBaseIp + "/test";

        public static string MvcAppBaseIp = "http://localhost:42020/";
    }
}
