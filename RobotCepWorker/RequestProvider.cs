using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class RequestProvider
{
    
        private readonly Lazy<HttpClient> _httpClient =
        new(() =>
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        },LazyThreadSafetyMode.ExecutionAndPublication);
        
        public async Task<TResult?> GetAsync<TResult>(string url)
        {
            var httpClient = _httpClient.Value;
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
        //if(response.StatusCode != System.Net.HttpStatusCode.OK) { return default; }
        
        return await response.Content.ReadFromJsonAsync<TResult>();
        
    }
    /* public async Task<TResult?> PutAsync<TResult>(string url, TResult data)
     {
         var httpClient = _httpClient.Value;
         var content = new  StringContent(JsonSerializer.Serialize(data));
         var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);
         content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
         return await response.Content.ReadFromJsonAsync<TResult>();
     }*/
    public async Task<TResult?> PutAsync<TResult>(string url, TResult data)
    {
        var httpClient = _httpClient.Value;
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PutAsync(url, content).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResult>();
    }

}