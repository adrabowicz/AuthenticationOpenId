
namespace Configuration
{
    public static class ConfigSSL
    {
        public static string IdentityServerBaseIP = "https://localhost:44319/";
        public static string IdentityServerIdentityIP = IdentityServerBaseIP + "identity/";
        public static string IdentityServerTokenIP = IdentityServerIdentityIP + "connect/token";
        public static string IdentityServerUserInfoIP = IdentityServerIdentityIP + "connect/userinfo";

        public static string MvcAppBaseIP = "https://localhost:44320/";

        public static string MvcHybridAppBaseIP = "https://localhost:44300/";
    }
}
