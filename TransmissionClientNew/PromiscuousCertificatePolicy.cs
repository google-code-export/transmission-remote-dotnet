#if MONO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace TransmissionRemoteDotnet
{
    class PromiscuousCertificatePolicy : ICertificatePolicy
    {
        #region ICertificatePolicy Members

        public bool CheckValidationResult(ServicePoint srvPoint, System.Security.Cryptography.X509Certificates.X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return true;
        }

        #endregion
    }
}
#endif