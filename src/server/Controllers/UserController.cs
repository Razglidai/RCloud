using Microsoft.AspNetCore.Mvc;
using RCloud.Contracts;
using RCloud.Services;

namespace RCloud.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger, UserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn([FromQuery] SignInRequest request, CancellationToken ct)
        {
            var token = await _userService.Login(request.username, request.password);
            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request,CancellationToken ct)
        {
            Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "/" + request.username);
            await _userService.Register(request.username, request.password, request.email);
            return Ok();
        }
    }
