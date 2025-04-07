using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Services
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepository _repository;
        public InstituicaoService(IInstituicaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Instituicao>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}
