using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Vikekh.Citronol.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountController : ControllerBase
    {
        private readonly ILogger<CountController> _logger;

        public CountController(ILogger<CountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Count()
        {
            return 94;
        }
    }
}
