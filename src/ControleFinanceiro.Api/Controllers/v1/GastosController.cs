using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GastosController : Controller
    {
        private readonly IGastosService _service;
        public GastosController
            (
            IGastosService service
            )
        {
            _service = service;
        }

        /// <summary>
        /// Retornar todos os usuarios existentes
        /// </summary>
        /// <returns>Lista de usuarios cadastrados</returns>
        /// <response code="200">Lista de itens</response>
        /// <response code="204">Caso nao encontre nenhum item</response>    
        /// <response code="500">Erro interno na api</response>    
        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(IEnumerable<GastosResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorUsuario(string cpf)
        {
            var response = await _service.ObterPorUsuarioAsync(cpf);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        /// <summary>
        /// Retornar todos os usuarios existentes
        /// </summary>
        /// <returns>Lista de usuarios cadastrados</returns>
        /// <response code="200">Lista de itens</response>
        /// <response code="204">Caso nao encontre nenhum item</response>    
        /// <response code="500">Erro interno na api</response>    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar(GastosRequest request)
        {
            var response = await _service.AdicionarAsync(request);

            if (!response)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
