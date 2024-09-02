using Microsoft.AspNetCore.Mvc;
using RCloud.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using RCloud.Services;

namespace RCloud.Controllers;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly DataService _dataService;
        public DataController(ILogger<DataController> logger, DataService dataService)
        {
            _dataService = dataService;
            _logger = logger;
        }

        [HttpGet]
        [Route("File")]
        public FileStreamResult GetFile([FromQuery] GetFileRequest request, CancellationToken ct)
        {
            var path = HttpContext.User.Identity.Name + @"\"+ request.path;
            var file = _dataService.GetFile(path);
            var fileResult = File(file.OpenRead(), "application/octet-stream");
            return fileResult;
        }

        [HttpPost]
        [Route("File")]
        public async Task<IActionResult> UploadFile([FromQuery] UploadFileRequest request,CancellationToken ct)
        {
            var path = HttpContext.User.Identity.Name + @"\" + request.path;
            await _dataService.UploadData(request.file, path);
            return Ok();
        }
        
        [HttpGet]
        [Route("Dir")]
        public IActionResult GetDirData([FromQuery] GetDirDataRequest request, CancellationToken ct)
        {
            var path = HttpContext.User.Identity.Name +@"\"+ request.path;
            var dirData = _dataService.GetDirData(path);

            return Ok(dirData);
        }

        [HttpPost]
        [Route("Dir")]
        public IActionResult CreateDir([FromQuery] CreateDirRequest request, CancellationToken ct)
        {
            var path = HttpContext.User.Identity.Name +@"\"+ request.path;
            _dataService.CreateDir(path);
            return Ok();
        }
        
    }
