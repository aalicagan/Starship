using Newtonsoft.Json;
using Star_Wars.Helper;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Star_Wars
{
    public class RequestBase<T> : IRequestBase<T>
    {
        async Task<T> Deserialize(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
        /// <summary>
        /// Get data given url in the dynamic object list. 
        /// </summary>
        /// <param name="url"></param>
        /// <returns> </returns>
        public async Task<T> CallApiAsync(string url)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "identity");

            HttpResponseMessage response = new HttpResponseMessage();
            response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) throw new Exception($"{url} return unsuccessfull");
            return await Deserialize(response.Content.ReadAsStringAsync().Result);
        }
    }
}
