
namespace Configuration
{
    public static class ConfigSSL
    {
        public const string Protocol = "https://";

        public static string IdentityServerBaseIP = Protocol + "localhost:44319/";
        public static string IdentityServerIdentityIP = IdentityServerBaseIP + "/identity";
        public static string IdentityServerConnectTokenIP = IdentityServerBaseIP + "/connect/token";

        public static string MvcAppBaseIP = Protocol + "localhost:44320/";
    }
}
