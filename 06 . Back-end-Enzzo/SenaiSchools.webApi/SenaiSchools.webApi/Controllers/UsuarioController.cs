using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiSchools.webApi.Domains;
using SenaiSchools.webApi.Repositories;
using SenaiSchools.webApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace SenaiSchools.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "0")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.CadastrarUsuario(novoUsuario);

                return StatusCode(201);
            } catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize(Roles = "0")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            } catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize(Roles = "0")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.DeletarUsuario(id);

                return StatusCode(202);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize(Roles = "0")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.AtualizarUsuario(id, usuarioAtualizado);

                return StatusCode(203);
            } catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                /*int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);*/

                _usuarioRepository.BuscarPorId(id);

                return StatusCode(201);
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}
