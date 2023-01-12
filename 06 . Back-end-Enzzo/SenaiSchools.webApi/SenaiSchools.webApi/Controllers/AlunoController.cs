using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiSchools.webApi.Controllers;
using SenaiSchools.webApi.Domains;
using SenaiSchools.webApi.Interfaces;
using SenaiSchools.webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Net.Http.Headers;

namespace SenaiSchools.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private IAlunoRepository _alunoRepository { get; set; }

        public AlunoController()
        {
            _alunoRepository = new AlunoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_alunoRepository.ListarAlunos());
            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Aluno alunoNovo)
        {
            try
            {
                /*var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    
                }*/

                _alunoRepository.CadastrarAluno(alunoNovo);

                return StatusCode(201);

            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno alunoAtualizado)
        {
            try
            {
                _alunoRepository.AtualizarAluno(id, alunoAtualizado);

                return StatusCode(202);
            }catch(Exception e)
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
                _alunoRepository.DeletarAluno(id);

                return StatusCode(204);
            }catch(Exception e){
                return BadRequest(e);
            }
        }
    }
}
