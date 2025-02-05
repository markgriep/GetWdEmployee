
using System.Net;

namespace WDEmployee.Services
{

    public class ProxyManager
    {

        public WebProxy GetProxy()
        {

            var proxy = new WebProxy
            {
                Address = new Uri(SecretsManager.GetSecret("ProxyUri")),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = true
            };

            return proxy;
        }

    }

}