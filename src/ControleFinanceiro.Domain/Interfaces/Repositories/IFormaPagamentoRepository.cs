using ControleFinanceiro.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface IFormaPagamentoRepository : IBaseRepository<FormaPagamento>
    {
        Task<IEnumerable<FormaPagamento>> ObterTodosAsync();
    }
}
