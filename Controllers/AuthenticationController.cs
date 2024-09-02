using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPISecure.Models;

namespace WebAPISecure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Login user)
        {
            if (user == null)
            {
                return BadRequest("Invalid Request: Please provide usernamae and password both");

            }
            else
            {
                if((user.UserName=="sam")&&(user.Password=="sam@1256"))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("da39a3ee5e6b4b0d3255bfef95601890afd80709"));
                    var signinCredential=new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims:new List<Claim>(),
                        expires:DateTime.Now.AddMinutes(5),
                        signingCredentials:signinCredential
                        );
                    var tokenString= new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new AuthenticateRespone {  Token = tokenString });    

                }
            }
            return Unauthorized();
           
        }
    }
}
