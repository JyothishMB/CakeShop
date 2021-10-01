using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CakeShop.Application.DTOs;
using CakeShop.Application.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CakeShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(ILogger<AuthController> logger
            , UserManager<IdentityUser> userManager
            , SignInManager<IdentityUser> signInManager
            , RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, isPersistent: false, false);
                if(result.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("asjdklhasjkdhasjkhdsjkahdjksahdjksahdsjad");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(ClaimTypes.Name, user.UserName)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
                
            }
            return Unauthorized("User is unauthorised to access this page");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = new IdentityUser(){ UserName = registerDto.UserName, Email = registerDto.Email };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if(result.Succeeded)
            {
                return Ok(new { Status = "Success", Message = "User Added successfully" });
            }
            string errors = string.Empty;
            
            foreach(var error in result.Errors)
            {
                errors = errors + error.Description;
            }

            return Ok(new { Status = "Failure", Message = "User registration failed.", Error = errors });
        }
    }
}
