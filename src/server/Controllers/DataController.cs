using Microsoft.AspNetCore.Mvc;
using RCloud.DataAccess;
using RCloud.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace RCloud.Controllers;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetData([FromQuery] GetDataRequest request, CancellationToken ct)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UploadData([FromBody] UploadDataRequest request,CancellationToken ct)
        {

            return Ok();
        }
    }
