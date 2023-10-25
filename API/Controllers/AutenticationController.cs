using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class AutenticationController : Controller
    {
        private readonly string? secretKey;
        public AutenticationController(IConfiguration config)
        {
            secretKey = config.GetSection("JWTsettings").GetSection("secretKey").ToString();
        }

        [HttpPost]
        public ActionResult<csResponse> Validar([FromBody] Usuario usuario)
        {
            if (usuario.Username == "rootHardcod" && usuario.Password == "admin") 
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Username));

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescription);

                var tokenCreated = tokenHandler.WriteToken(tokenConfig);

                return new csResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Autorizado",
                    Data = tokenCreated
                };

                //return StatusCode(StatusCodes.Status200OK, new { token = tokenCreated });
            }
            else
            {
                return new csResponse
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "No autorizado",
                    Data = null
                };
                //return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }



            return null;
        }
    }
}
