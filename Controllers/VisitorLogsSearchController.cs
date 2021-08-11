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
    public class VisitorLogsSearchController : ControllerBase
    {
        private readonly ILogger<VisitorLogsSearchController> _logger;
        private readonly IVisitorLogsSearchService _visitorLogsSearchService;

        public VisitorLogsSearchController(ILogger<VisitorLogsSearchController> logger, IVisitorLogsSearchService visitorLogsSearchService)
        {
            _logger = logger;
            _visitorLogsSearchService = visitorLogsSearchService;
        }

        [HttpGet]
        public async Task<string> Get(string siteId, string searchKey, string token)
        {
            return await _visitorLogsSearchService.Get(siteId, searchKey, token);
        }
    }
}