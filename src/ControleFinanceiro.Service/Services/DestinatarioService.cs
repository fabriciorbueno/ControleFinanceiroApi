using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Services
{
    public class DestinatarioService : IDestinatarioService
    {
        private readonly IDestinatarioRepository _repository;
        public DestinatarioService(IDestinatarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Destinatario>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}
