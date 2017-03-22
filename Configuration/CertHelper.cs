using System.Security.Cryptography.X509Certificates;

namespace Configuration
{
    public static class CertHelper
    {
        public static X509Certificate2 LoadCertificate(string path)
        {
            var fileName = $@"{path}idsrv3test.pfx";
            return new X509Certificate2(fileName, "idsrv3test");
        }
    }
}
