using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using BusinessObject;
using BusinessObject.Models;

using DataAccess.Interface;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceAPI.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase {
        private readonly IUserRepository _repoUser;

        public LoginController(IUserRepository repoUser)
        {
            _repoUser = repoUser;
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                User register = _repoUser.Create(user);
                return Ok(register);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Login(LoginModels loginModel)
        {
            try
            {
                User u = _repoUser.Login(loginModel);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1A^9dW4m$uRuNlI!$Jn8soNH$cKV0N$%"));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var claims = new Claim[] {
                        new("Role", u.IsSeller.ToString())
                    };
                var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: credentials
                    );
                var tokenHandler = new JwtSecurityTokenHandler();
                string access_token = tokenHandler.WriteToken(token);
               
                return Ok(access_token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
