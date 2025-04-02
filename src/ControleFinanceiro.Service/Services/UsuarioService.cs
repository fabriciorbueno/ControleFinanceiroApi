using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<UsuarioResponse> AdicionarAsync(UsuarioRequest request)
        {
            var usuario = new Usuario(request.Nome, request.Cpf);
            var response = await _repository.AdicionarAsync(usuario);
            if (response == null) return null;

            return new UsuarioResponse() { Id = response.Id };
        }

        public async Task<Usuario> ObterPorCpfAsync(string cpf)
        {
            return await _repository.ObterPorCpfAsync(cpf);
        }
    }
}
