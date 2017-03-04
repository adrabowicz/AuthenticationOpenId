
namespace Configuration
{
    public static class ConfigSSL
    {
        public const string Protocol = "https://";

        public static string EmbeddedMvcBaseIP = Protocol + "localhost:44319/";

        public static string MvcAppBaseIP = Protocol + "localhost:44320/";
    }
}
