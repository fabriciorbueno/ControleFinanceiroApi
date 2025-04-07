using ControleFinanceiro.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface IInstituicaoRepository : IBaseRepository<Instituicao>
    {
        Task<IEnumerable<Instituicao>> ObterTodosAsync();
    }
}
