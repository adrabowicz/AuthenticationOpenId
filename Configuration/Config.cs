
namespace Configuration
{
    public static class Config
    {
        public const string IdentityServerBaseIp = "http://localhost:5000";
        public static string IdentityServerConnectTokenIp = IdentityServerBaseIp + "/connect/token";
        public static string IdentityServerIdentityIp = IdentityServerBaseIp + "/identity";

        public const string KpMvcAppBaseIp = "https://localhost:44375/";

        public const string MkpApiBaseIp = "https://localhost:44379/";
        public static string MkpApiTestIp = MkpApiBaseIp + "/test";

        public const string CidmApiBaseIp = "https://localhost:44351";
        public static string CidmApiTestIp = CidmApiBaseIp + "/test";
    }
}
