using ControleFinanceiro.Domain.Dtos.Request;
using ControleFinanceiro.Domain.Dtos.Response;
using ControleFinanceiro.Domain.Enums;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TipoPagamentoController : Controller
    {
        private readonly IGenericService _service;
        public TipoPagamentoController(IGenericService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retornar todos os cadastro de favoritos existentes
        /// </summary>
        /// <returns>Lista de favoritos cadastrados</returns>
        /// <response code="200">Lista de itens</response>
        /// <response code="204">Caso nao encontre nenhum item</response>    
        /// <response code="500">Erro interno na api</response>    
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResponseBase>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarTodos()
        {
            var response = await _service.BuscarTodosAsync(TabelaEnum.TipoPagamento);

            if (response == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Retornar todos os cadastro de favoritos existentes
        /// </summary>
        /// <returns>Lista de favoritos cadastrados</returns>
        /// <response code="200">Lista de itens</response>
        /// <response code="204">Caso nao encontre nenhum item</response>    
        /// <response code="500">Erro interno na api</response>    
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inserir(RequestBase categoriaRequest)
        {
            var response = await _service.InserirAsync(TabelaEnum.TipoPagamento, categoriaRequest);

            if (!response)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}