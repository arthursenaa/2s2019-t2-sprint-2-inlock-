using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogoController : Controller
    {
        JogoRepository JogoRepository = new JogoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult ListarJogos()
        {
            return Ok(JogoRepository.Listar());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult CadastrarJogo(Jogos jogos)
        {
            try
            {
                JogoRepository.Cadastrar(jogos);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ocorreu algum problema chefia, tamo ai na busca pra resolve essa parada. Aguarde um momento" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult AtualizarJogos(Jogos jogos)
        {
            try
            {
                if (jogos == null)
                {
                    return NotFound();
                }
                JogoRepository.Atualizar(jogos);
                return Ok();
            }
            catch (Exception ex )
            {
                return BadRequest(new { mensagem = "Ocorreu algum problema chefia, tamo ai na busca pra resolve essa parada. Aguarde um momento" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult DeletarJogos(int Id)
        {
            JogoRepository.Deletar(Id);
            return Ok();
        }

        //Extras

        [HttpGet("5jogos")]
        public IActionResult ListarTop5()
        {
            return Ok(JogoRepository.ListaTop5());
        }

        [HttpGet("data")]
        public IActionResult ListaPorData()
        {
            return Ok(JogoRepository.ListaPorData());
        }

        [HttpGet("{nome}")]
        public IActionResult BuscarJogoPorNome(string Nome)
        {
            return Ok(JogoRepository.BuscarPorNome(Nome));
        }

        
    }
}