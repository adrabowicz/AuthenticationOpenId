
namespace Configuration
{
    public static class Config
    {
        public const string Protocol = "http://";

        public static string IdentityServerBaseIP = Protocol + "localhost:5000";
        public static string IdentityServerIdentityIp = IdentityServerBaseIP + "/identity";
        public static string IdentityServerConnectTokenIP = IdentityServerBaseIP + "/connect/token";

        public static string CidmApiBaseIP = Protocol + "localhost:42001";
        public static string CidmApiTestIp = CidmApiBaseIP + "/test";

        public static string CommonApiBaseIP = Protocol + "localhost:42002";
        public static string CommonApiTestIP = CommonApiBaseIP + "/test";

        public static string KpApiBaseIP = Protocol + "localhost:42003/";
        public static string KpApiTestIP = KpApiBaseIP + "/test";

        public const string KpMvcAppBaseIp = "https://localhost:44375/";
    }
}
