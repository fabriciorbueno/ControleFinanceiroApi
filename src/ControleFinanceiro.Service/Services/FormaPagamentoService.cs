using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Services
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly IFormaPagamentoRepository _repository;
        public FormaPagamentoService(IFormaPagamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FormaPagamento>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}
