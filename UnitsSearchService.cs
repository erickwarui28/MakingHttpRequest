using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MakingHttpRequest
{
    public interface IUnitsSearchService
    {
        Task<string> Get(string siteId, string communityId, string buildingId, string addressKey, string token);
    }

    public class UnitsSearchService : IUnitsSearchService
    {
        private HttpClient _httpClient;

        public UnitsSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get(string siteId, string communityId, string buildingId, string addressKey, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
            string APIURL = $"/api/v3/units/search?siteId={siteId}&communityId={communityId}&buildingId={buildingId}&addressKey={addressKey}";
            var response = await _httpClient.GetAsync(APIURL);
            return await response.Content.ReadAsStringAsync();
        }
    }
}