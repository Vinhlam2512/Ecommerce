using System.Net.Http;

using BusinessObject.Models;

using Newtonsoft.Json;

namespace EcommerceClient {
    public class HttpClientWrapper {

        private static readonly Lazy<HttpClient> LazyInstance = new Lazy<HttpClient>(() =>
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7004");
            return httpClient;
        });

        public static HttpClient Instance => LazyInstance.Value;

        public static async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await Instance.GetAsync(endpoint);

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(responseBody);
                    return data;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static async Task<T> PostAsync<T, K>(string endpoint, K body)
        {
            try
            {
                // Send the POST request
                HttpResponseMessage response = await Instance.PostAsJsonAsync(endpoint, body);

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(responseBody);
                    return data;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static async Task<T> DeleteAsync<T>(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await Instance.DeleteAsync(endpoint);

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(responseBody);
                    return data;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
