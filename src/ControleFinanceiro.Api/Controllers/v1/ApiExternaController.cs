using ControleFinanceiro.Domain.Dtos.Response.ApiExterna;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApiExternaController : Controller
    {

        private readonly ILogger<ApiExternaController> _logger;
        private readonly IApiExternaService _apiExternaService;
        public ApiExternaController
            (
            ILogger<ApiExternaController> logger,
            IApiExternaService apiExternaService
            )
        {
            _logger = logger;
            _apiExternaService = apiExternaService;

        }

        /// <summary>
        /// Realizar consulta de um favorecido cadastrado de acordo com o documento fornecido na requisicao
        /// </summary>
        /// <param name="cep">Documento de Identificacao</param>
        /// <returns>Favorito encontrado via documento</returns>
        /// <response code="200">Retorna item encontrado</response>
        /// <response code="204">Caso nao encontre nenhum item</response>    
        /// <response code="500">Erro interno na api</response>    
        [HttpGet("BuscarCep")]
        [ProducesResponseType(typeof(CepResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CepResponse>> BucarCep([Required] string cep)
        {
            var response = await _apiExternaService.BuscarCepAsync(cep);

            if (response == null)
            {
                return BadRequest();
            }
            else if (response.StatusCode == 404)
            {
                return NotFound(response.ResponseErro);
            }

            return Ok(response.ResponseSucesso);
        }


    }
}
