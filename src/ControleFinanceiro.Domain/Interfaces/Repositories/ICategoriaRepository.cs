using ControleFinanceiro.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> ObterTodosAsync();
    }
}
