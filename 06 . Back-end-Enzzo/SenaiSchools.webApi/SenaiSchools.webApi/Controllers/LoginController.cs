using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiSchools.webApi.Domains;
using SenaiSchools.webApi.Repositories;
using SenaiSchools.webApi.Interfaces;
using SenaiSchools.webApi.ViewModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace SenaiSchools.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método que irá logar o usuário ao sistema com suas devidas permissões
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuario userLogin = _usuarioRepository.Login(login.Email, login.Senha);

                if(userLogin == null)
                {
                    return NotFound("Email ou senha inválidos!");
                }

                var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Email, userLogin.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, userLogin.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, userLogin.TipoUsuario.ToString()),

                    new Claim("role", userLogin.TipoUsuario.ToString())

                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SenaiSchools-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Senai-Schools",
                    audience: "Senai-Schools",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
