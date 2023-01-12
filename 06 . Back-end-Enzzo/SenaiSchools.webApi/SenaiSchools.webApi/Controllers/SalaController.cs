using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiSchools.webApi.Domains;
using SenaiSchools.webApi.Interfaces;
using SenaiSchools.webApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace SenaiSchools.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private ISalaRepository _salaRepository { get; set; }

        public SalaController()
        {
            _salaRepository = new SalaRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_salaRepository.ListarSalas());
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Sala novaSala)
        {
            try
            {
                _salaRepository.CadastrarSala(novaSala);

                return StatusCode(201);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Sala salaAtualizada)
        {
            try
            {
                _salaRepository.AtualizarSala(id, salaAtualizada);

                return StatusCode(202);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _salaRepository.DeletarSala(id);

                return StatusCode(204);

            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
