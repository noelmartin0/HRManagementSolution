using HRManagement;
using HRManagement.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConfigurationManager = HRManagement.ConfigurationManager;

namespace HRManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IAdminLoginRepo _repo;
        public AuthenticationController(IAdminLoginRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("AdminLogin")]
        public ActionResult AdminLogin([FromBody] AdminLogin login)
        {
            if (login is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            if (_repo.validateuser(login.Username, login.Password, login.Role))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                    audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                    claims: new List<Claim>(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,login.Username),
                        new Claim(ClaimTypes.Role,login.Role)
                    }),

                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                CookieOptions cookieOptions = new CookieOptions
                {
                    Domain = "localhost",
                    Path = "/",
                    Secure = true,
                    Expires = DateTime.Now.AddMinutes(6),
                    HttpOnly = true,
                    IsEssential = true


                };
             //   HttpContext.Session.SetString("username", login.Username);
           //     Response.Cookies.Append(login.Username, tokenString);
                return Ok(new JWTTokenResponse { Token = tokenString });
            }
            return Unauthorized();
        }
        [Route("AdminLogin")]
        [Authorize(Roles = "Admin")]
        [HttpGet]

            public ContentResult Get()
            {

                return Content("You are an authorised user");

            }
        
    }
}