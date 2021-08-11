using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MakingHttpRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitsSearchController : ControllerBase
    {
        private readonly ILogger<UnitsSearchController> _logger;
        private readonly IUnitsSearchService _unitsSearchService;

        public UnitsSearchController(ILogger<UnitsSearchController> logger, IUnitsSearchService unitsSearchService)
        {
            _logger = logger;
            _unitsSearchService = unitsSearchService;
        }

        [HttpGet]
        public async Task<string> Get(string siteId, string communityId, string buildingId, string addressKey, string token)
        {
            return await _unitsSearchService.Get(siteId, communityId, buildingId, addressKey, token);
        }
    }
}