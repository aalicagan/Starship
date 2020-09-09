using Newtonsoft.Json;
using Star_Wars.Helper;
using System;
using System.Net.Http;

namespace Star_Wars
{
    public class RequestBase<T> : IRequestBase<T>
    {
        T Deserialize(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
        /// <summary>
        /// Get data given url in the dynamic object list. 
        /// </summary>
        /// <param name="url"></param>
        /// <returns> </returns>
        public T CallApi(string url)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "identity");

            HttpResponseMessage response = new HttpResponseMessage();
            response = httpClient.GetAsync(url).Result;

            if (!response.IsSuccessStatusCode) throw new Exception($"{url} return unsuccessfull");
            return Deserialize(response.Content.ReadAsStringAsync().Result);
        }
    }
}
