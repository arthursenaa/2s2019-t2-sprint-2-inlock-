using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository EstudioRepository = new EstudioRepository();

        [HttpGet]
        public IActionResult ListarEstudios()
        {
            return Ok(EstudioRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarEstudio(Estudios estudio)
        {
            try
            {
                EstudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ocorreu algum problema chefia, tamo ai na busca pra resolve essa parada. Aguarde um momento" + ex.Message });
            }
        }

        [HttpPut]
        public IActionResult AtualizarEstudio(Estudios estudio)
        {
            try
            {
                Estudios EstudioEncontrado = EstudioRepository.BuscarPorId(estudio.EstudioId);

                if (EstudioEncontrado == null)
                {
                    return NotFound();
                }
                EstudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ocorreu algum problema chefia, tamo ai na busca pra resolve essa parada. Aguarde um momento" + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEstudio(int id)
        {
            EstudioRepository.Deletar(id);
            return Ok();
        }
    }
}