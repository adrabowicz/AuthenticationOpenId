using System;
using System.Security.Cryptography.X509Certificates;

namespace Configuration
{
    public static class CertHelper
    {
        public static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\idsrv3test.pfx", "idsrv3test");
        }
    }
}
