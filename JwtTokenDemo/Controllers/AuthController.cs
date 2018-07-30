using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtTokenDemo.Data;
using JwtTokenDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtTokenDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private UserManager<User> userManager;

        public AuthController(UserManager<User> _userManager)
        {
            this.userManager = _userManager;//添加注释
        }

        [HttpPost]
        [HttpGet]
        [Route("login")]
        public async Task<ActionResult> Login(LoginModel model)
        {

            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,user.Id)
                };

                var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyJwtKsy123456!@#"));

                var token = new JwtSecurityToken(
                    //issuer: "http://www.baidu.com",
                    //audience: "http://www.baidu.com",
                    expires: DateTime.UtcNow.AddMinutes(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256)
                    );
                var result = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
                return Ok(result);
            }

            return Unauthorized();
        }

    }
}