using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;
        public UsuarioController
            (
            IUsuarioService service
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
        [ProducesResponseType(typeof(IEnumerable<Usuario>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodos()
        {
            var response = await _service.ObterTodosAsync();

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        /// <summary>
        /// Cadastrar novo favorito
        /// </summary>
        /// <param name="request">Objeto de cadastro de novo favorito</param>
        /// <returns></returns>
        /// <response code="201">Favorito cadastrado com suceso</response>
        /// <response code="400">Nao foi possivel cadastrar o favorito</response>    
        /// <response code="500">Erro interno na api</response>   
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UsuarioResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Adicionar([FromBody][Required] UsuarioRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _service.AdicionarAsync(request);

            return Ok(response);
        }

        /// <summary>
        /// Retornar todos os usuarios existentes
        /// </summary>
        /// <returns>Lista de usuarios cadastrados</returns>
        /// <response code="200">Lista de itens</response>
        /// <response code="204">Caso nao encontre nenhum item</response>    
        /// <response code="500">Erro interno na api</response>    
        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodos(string cpf)
        {
            var response = await _service.ObterPorCpfAsync(cpf);

            if (response == null)
            {
                return NoContent();
            }

            return Ok(response);
        }


        ///// <summary>
        ///// Atualizar cadastro de favorito
        ///// </summary>
        ///// <param name="id">Identificador do cadastro</param>
        ///// <param name="request">Objeto de atualizacao do favorito</param>
        ///// <returns></returns>
        ///// <response code="204">Favorito atualizado com suceso</response>
        ///// <response code="400">Nao foi possível cadastrar o favorito</response>    
        ///// <response code="500">Erro interno na api</response>
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Put([Required] int id, [FromBody][Required] FavoritoRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogInformation("Alteração com erro: {request}", JsonConvert.SerializeObject(request));
        //        return BadRequest(ModelState);
        //    }

        //    _ = await _favoritoService.AlterarAsync(id, request);

        //    return NoContent();
        //}
    }
}
