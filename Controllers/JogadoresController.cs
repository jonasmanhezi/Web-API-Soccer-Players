using JogadoresApi.Models;
using JogadoresApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogadoresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private IJogadorService _jogadorService;

        public JogadoresController(IJogadorService jogadorService)
        {
            _jogadorService = jogadorService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Jogador>>> GetJogadores()
        {
            try
            {
                var jogadores = await _jogadorService.GetJogadores();
                return Ok(jogadores);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Jogadores");
            }
        }
        [HttpGet("JogadoresPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Jogador>>> GetJogadoresByName([FromQuery] string nome)
        {
            try
            {
                var jogadores = await _jogadorService.GetJogadoresByNome(nome);

                if (jogadores == null)

                    return NotFound($"Não existem jogadores com o criterio: {nome}");


                return Ok(jogadores);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Jogadores por nome");
            }

        }
        [HttpGet("{id:int}", Name = "GetJogador")]

        public async Task<ActionResult<Jogador>> GetJogador(int id)
        {
            try
            {
                var jogador = await _jogadorService.GetJogador(id);

                if (jogador == null)

                    return NotFound($"Não existem jogadores com o Id :  {id}");

                return Ok(jogador);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Jogadores por esse Id");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Jogador jogador)
        {
            try
            {
                await _jogadorService.CreateJogador(jogador);
                return CreatedAtAction("GetJogador", new { id = jogador.Id }, jogador);

            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Jogador jogador)
        {
            try
            {
                if (jogador.Id == id)
                {
                    await _jogadorService.UpdateJogador(jogador);
                    return Ok($"Jogador com o id = {id} foi atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Dados Invalidos");
                }
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var jogador = await _jogadorService.GetJogador(id);
                if (jogador != null)
                {
                    await _jogadorService.DeleteJogador(jogador);
                    return Ok($"Jogador de id = {id} foi excluido com sucesso!");
                }
                else
                {
                    return NotFound($"Jogador com o id = {id} não foi encontrado!");
                }
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }
    }
}
