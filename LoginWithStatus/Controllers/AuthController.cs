using LoginWithStatus.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginWithStatus.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost,Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user request");
            }
            if(user.UserName == "sanjesh" && user.Password == "nep@123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));
                var signingCredentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken
                (issuer: "https://localhost:7153",
                audience: "https://localhost:7153",
                claims : new List<Claim>(),
                expires:DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
                );
                  
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new  AuthenticatedResponse{Token = tokenString});
                

            }
            return Unauthorized();
        }
    }
}
