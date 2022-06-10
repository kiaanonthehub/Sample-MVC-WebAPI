using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MVCWebApp
{
    public static class Global
    {
        public static HttpClient httpClient = new HttpClient();

        static Global()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000/api/");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
