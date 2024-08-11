using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCloud.DataAccess;
using RCloud.Contracts;
using RCloud.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace RCloud.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly UserDbContext _dbContext;
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger, UserDbContext dbContext)
        {
            _dbContext = dbContext;
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
