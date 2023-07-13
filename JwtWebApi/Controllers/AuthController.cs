using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography;

namespace JwtWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration) 
        {
            _configuration = configuration;  
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request) 
        {
        

            user.Username = request.Username;
            user.Password = request.Password;

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
           if (user.Username != request.Username)
            {
                return BadRequest("Usuário não encontrado. ");
            }
                
           if (user.Password != request.Password)
            {
                return BadRequest("Senha Incorreta");
            }


            return Ok("Login efeituado com sucesso");
        
        }
   
        }

    }

