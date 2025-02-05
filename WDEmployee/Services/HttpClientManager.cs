using System.Net;
using System.Net.Http.Headers;



namespace WDEmployee.Services
{
    public class HttpClientManager 
    {


        public async Task<HttpResponseMessage> GetApiResponseAsync(string uri, string creds)
        {
            var client = GetClient(creds, new Uri(uri));
            HttpResponseMessage responseMessage;
            try
            {
                responseMessage = await client.GetAsync(client.BaseAddress);
            }
            catch (HttpRequestException ex)
            {
                LogException(ex);                               // Log the exception details

                if (IsTimeoutException(ex))                     // Determine response based on the type of error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
                }
            }
            return responseMessage;
        }


        private HttpClient GetClient(string creds, Uri uri)
        {

            var _proxy = new ProxyManager();


            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            handler.Proxy = _proxy.GetProxy();
            var client = new HttpClient(handler, true);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", creds);
            client.BaseAddress = uri;
            return client;
        }


        // Placeholder till we get Serilog installed.
        private void LogException(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}, StackTrace: {ex.StackTrace}");
            // some comment
        }



        private bool IsTimeoutException(HttpRequestException ex)
        {
            return ex.Message.Contains("timeout", StringComparison.OrdinalIgnoreCase);  // if timeout via exception/inner exceptions
        }

    }
}
