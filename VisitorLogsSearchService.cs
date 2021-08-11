using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MakingHttpRequest
{
    public interface IVisitorLogsSearchService
    {
        Task<string> Get(string siteId, string searchKey, string token);
    }

    public class VisitorLogsSearchService : IVisitorLogsSearchService
    {
        private HttpClient _httpClient;

        public VisitorLogsSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get(string siteId, string searchKey, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
            string APIURL = $"/api/v3/visitors/search?siteId={siteId}&searchKey={searchKey}";
            var response = await _httpClient.GetAsync(APIURL);
            return await response.Content.ReadAsStringAsync();
        }
    }
}