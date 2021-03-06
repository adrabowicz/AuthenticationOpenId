﻿
namespace Configuration
{
    public static class ConfigSSL
    {
        public static string IdentityServerBaseIP = "https://localhost:44319/";
        public static string IdentityServerIdentityIP = "https://localhost:44319/identity/";
        public static string IdentityServerTokenIP = "https://localhost:44319/identity/connect/token";
        public static string IdentityServerUserInfoIP = "https://localhost:44319/identity/connect/userinfo";
        public static string IdentityServerAuthorizeIP = "https://localhost:44319/identity/connect/authorize";
        public static string IdentityServerWellKnownIP = "https://localhost:44319/identity/.well-known/openid-configuration";

        public static string MvcAppBaseIP = "https://localhost:44320/";

        public static string MvcHybridAppBaseIP = "https://localhost:44300/";
    }
}
