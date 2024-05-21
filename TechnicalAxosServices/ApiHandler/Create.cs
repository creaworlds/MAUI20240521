using System.Net.Http;
using System.Net.Http.Headers;

namespace TechnicalAxosServices
{
    public static partial class ApiHandler
    {
        public static HttpClient Create()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            return httpClient;
        }
    }
}
