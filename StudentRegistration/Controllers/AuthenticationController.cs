using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentRegistration.Modles;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentRegistration.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost("{UserName},{Password}")]
        public ActionResult IssueToken(string UserName,string Password)
        {
            if(UserName == "admin" && Password == "admin")
            {
                var keyBytes = Encoding.UTF8.GetBytes(AuthConstants.Secret);
                var key=new SymmetricSecurityKey(keyBytes);

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, UserName),
                    new Claim("Id","AUTH_001")
                };
                var signingCredintials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                    AuthConstants.Issuer,
                    AuthConstants.Audience,
                    claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredintials
                    );

                var tokenString=new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(tokenString);

            }
            return Unauthorized();
        }
    }
}
