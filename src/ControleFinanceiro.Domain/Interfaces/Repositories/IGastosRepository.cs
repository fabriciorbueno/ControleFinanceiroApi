using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface IGastosRepository : IBaseRepository<Gastos>
    {
        Task<IEnumerable<Gastos>> ObterTodosAsync();
        Task<IEnumerable<GastosResponse>> ObterPorUsuarioAsync(string cpf);
        Task<bool> AdicionarAsync(Gastos gastos);
    }
}
