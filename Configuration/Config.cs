
namespace Configuration
{
    public static class Config
    {
        public const string Protocol = "http://";

        public static string IdentityServerBaseIp = Protocol + "localhost:5000";
        public static string IdentityServerIdentityIp = IdentityServerBaseIp + "/identity";
        public static string IdentityServerConnectTokenIp = IdentityServerBaseIp + "/connect/token";

        public static string CidmApiBaseIp = Protocol + "localhost:42001";
        public static string CidmApiTestIp = CidmApiBaseIp + "/test";

        public static string CommonApiBaseIp = Protocol + "localhost:42002";
        public static string CommonApiTestIp = CommonApiBaseIp + "/test";

        public static string KpApiBaseIp = Protocol + "localhost:42003";
        public static string KpApiTestIp = KpApiBaseIp + "/test";
    }
}
