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
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, UserDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetJWT([FromQuery] GetJWTRequest request, CancellationToken ct)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == request.username && u.Password == request.password);
            if (user == null)return Unauthorized();
            var claims = new List<Claim>{new Claim(ClaimTypes.Name, request.username, request.password)};
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );
            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request,CancellationToken ct)
        {

            User? User = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == request.username || u.Email == request.email);
            if (User != null)return BadRequest("This username or email already taken!");

            Match isMatch = Regex.Match(request.email, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}", RegexOptions.IgnoreCase);
            if(!isMatch.Success)return BadRequest("Email is not valid!");

            if(request.password.Length < 6)return BadRequest("Password is small!");

            var user = new User(
                username: request.username,
                email: request.email, 
                password: request.password);
            
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            
            return Ok();
        }
    }
