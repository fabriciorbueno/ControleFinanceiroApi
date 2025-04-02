using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;
        public CategoriaController
            (
            ICategoriaService service
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
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Categoria>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.ObterTodosAsync();

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
