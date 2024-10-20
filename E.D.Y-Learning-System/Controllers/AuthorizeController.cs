using BusinessObject.Entities;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E.D.Y_Learning_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IUserService _userServices;

        //private readonly IRefreshHandler refresh;

        public AuthorizeController(IUserService userServices)
        {
            _userServices = userServices;
        }
        #region GenerateToken
        /// <summary>
        /// Which will generating token accessible for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [NonAction]
        public TokenViewModel GenerateToken(User user, String? RT)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("UserName", user.FullName),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role.ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("c2VydmVwZXJmZWN0bHljaGVlc2VxdWlja2NvYWNoY29sbGVjdHNsb3Bld2lzZWNhbWU="));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            if (RT != null)
            {
                return new TokenViewModel()
                {
                    AccessTokenToken = accessToken
                };
            }
            return new TokenViewModel()
            {
                AccessTokenToken = accessToken
            };
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userServices.GetUserByEmail(email);
            if (user != null)
            {
                // Hash the input password with MD5
                var hashedInputPasswordString = _userServices.HashAndTruncatePassword(password);

                // Compare the hashed input password with the stored hashed password
                if (hashedInputPasswordString == user.Password)
                {
                    var token = GenerateToken(user, null);
                    return Ok(new APIResponse
                    {
                        Success = true,
                        Message = "Status Code:200 Login Successfully",
                        data = token
                    });
                }
            }
            return BadRequest(new APIResponse
            {
                Success = false,
                Message = "Status Code:401 Unauthorized | Invalid email or password",
                data = null
            });
        }
        #endregion

        #region Logout
        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                token = token.Split(' ')[1];
                var tokenHandler = new JwtSecurityTokenHandler();
                var TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("c2VydmVwZXJmZWN0bHljaGVlc2VxdWlja2NvYWNoY29sbGVjdHNsb3Bld2lzZWNhbWU=")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = false
                };
                SecurityToken validatedToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, TokenValidationParameters, out validatedToken);
                var userIdClaim = claimsPrincipal.FindFirst("UserId");
                if (HttpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    HttpContext.Request.Headers.Remove("Authorization");
                }
                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Logout succesfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = "Something go wrong" + ex.Message
                });
            }

        }
        #endregion
    }
}
