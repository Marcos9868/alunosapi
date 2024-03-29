using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AlunosApi.Contracts;
using AlunosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AlunosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }
        [HttpPost]
        [Route("CriarAluno")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Aluno))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarAluno(Aluno aluno)
        {
            await _alunoService.CriarAluno(aluno);
            if (aluno is null)
                return BadRequest("Não foi possível criar o aluno");
            return Created("CriarAluno", aluno);
        }
        [HttpGet]
        [Route("ObterListaAlunos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> ObterListaAlunos()
        {
            try
            {
                var alunos = await _alunoService.ObterListaAlunos();
                return Ok(alunos);                
            }
            catch (System.Exception)
            {                
                return BadRequest("Não foi possível listar os alunos");
            }
        }
        [HttpGet]
        [Route("ObterListaAlunosPorNome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> ObterListaAlunosPorNome(string Nome)
        {
            try
            {
                var alunos = await _alunoService.ObterListaAlunosPeloNome(Nome);
                if (alunos is null)
                    return NotFound("Não foi possível listar os alunos");
                return Ok(alunos);                
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("ObterAluno")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ObterAluno(int Id)
        {
            try
            {
                var aluno = await _alunoService.ObterAlunoPeloId(Id);
                if (aluno is null)
                    return NotFound("Não foi possível encontrar o aluno");
                return Ok(aluno);                
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("EditarAluno")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarAluno(int Id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.Id == Id)
                {
                    await _alunoService.EditarAluno(aluno);
                    return Ok(aluno);                
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {
                return BadRequest("Não foi possível editar o aluno");
            }
        }
        [HttpDelete]
        [Route("RemoverAluno")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoverAluno(int Id)
        {
            var aluno = await _alunoService.RemoverAluno(Id);
            if (aluno is null)
                return BadRequest("Não foi possível remover o aluno");
            return Ok(aluno);
        }
    }
}