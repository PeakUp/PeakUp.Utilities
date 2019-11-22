using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PeakUp.Utilities.Helpers
{
    public class HttpHelper
    {
        private static HttpHelper _instance;
        public static HttpHelper Instance
        {
            get { return _instance ?? (_instance = new HttpHelper()); }
        }

        /// <summary>
        /// HttpGet
        /// </summary>
        /// <param name="uriString">Request url</param>
        /// <param name="headers">Request headers</param>
        /// <returns></returns>
        public async Task<string> GetAsync(string uriString, Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                if (headers != null && headers?.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                var response = await client.GetAsync(new Uri(uriString.ToString()));
                return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync()
                                                    : null;

            }

        }

        /// <summary>
        /// HttpPost
        /// </summary>
        /// <param name="uriString">Request url</param>
        /// <param name="postData">Request body as json</param>
        /// <param name="headers">Request headers</param>
        /// <returns></returns>
        public async Task<string> PostAsync(string uriString, string postData, Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                if (headers != null && headers?.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                var httpResponse = await client.PostAsync(new Uri(uriString.ToString()), new StringContent(postData, Encoding.UTF8, "application/json"));

                return httpResponse.IsSuccessStatusCode ? await httpResponse.Content.ReadAsStringAsync()
                                                        : string.Empty;
            }
        }

    }
}
