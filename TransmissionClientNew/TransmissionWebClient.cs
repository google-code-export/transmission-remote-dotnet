using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace TransmissionClientNew
{
    class TransmissionWebClient : WebClient
    {
        /* Some proxies may require a known user agent? */
        public const string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request.GetType() == typeof(HttpWebRequest))
            {
                SetupWebRequest((HttpWebRequest)request);
            }
            return request;
        }

        public static void SetupWebRequest(HttpWebRequest request)
        {
            /* Very important !!! Fixes bug in .NET (or shttpd?) */
            request.KeepAlive = false;
            //request.ProtocolVersion = HttpVersion.Version10;
            request.UserAgent = TransmissionWebClient.userAgent;
            LocalSettingsSingleton settings = LocalSettingsSingleton.Instance;

            if (settings.authEnabled)
            {
                request.Credentials = new NetworkCredential(settings.user, settings.pass);
                request.PreAuthenticate = Program.preAuthenticate;
            }
            if (settings.proxyEnabled == 1)
            {
                request.Proxy = new WebProxy(settings.proxyHost, settings.proxyPort);
                if (settings.proxyAuth)
                {
                    request.Proxy.Credentials = new NetworkCredential(settings.proxyUser, settings.proxyPass);
                }
            }
            else if (settings.proxyEnabled == 2)
            {
                request.Proxy = null;
            }
        }
    }
}