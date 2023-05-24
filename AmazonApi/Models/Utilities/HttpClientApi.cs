using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AmazonApi.Models.Utilities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AmazonApi.Utilities
{
    public static class HttpClientApi
    {
        private static HttpClient client;
        public static HttpClient HttpSetHost()
        {
            try
            {
                client = new();
                client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("SageApi"));
                MediaTypeWithQualityHeaderValue contentType = new("application/json");
                client.Timeout = TimeSpan.FromMinutes(3);
                client.DefaultRequestHeaders.Accept.Add(contentType);
                return client;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public  static string HttpGet(string requestUri)
        {
            try
            {
                HttpSetHost();
                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                return stringData;
            }
            catch (Exception)
            {
                return null;
            }
           
        }
        public static HttpResponseMessage HttpPost(object obj, string requestUri)
        {
            try
            {
                HttpSetHost();
                string stringData = JsonConvert.SerializeObject(obj);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(requestUri, contentData).Result;
                return response;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static HttpResponseMessage HttpPut(object obj, string requestUri)
        {
            try
            {
                HttpSetHost();
                string stringData = JsonConvert.SerializeObject(obj);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(requestUri, contentData).Result;
                return response;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static HttpResponseMessage HttpDelete(string requestUri)
        {
            try
            {
                HttpSetHost();
                HttpResponseMessage response = client.DeleteAsync(requestUri).Result;
                return response;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
