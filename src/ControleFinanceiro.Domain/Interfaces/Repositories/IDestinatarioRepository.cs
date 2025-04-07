using ControleFinanceiro.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface IDestinatarioRepository : IBaseRepository<Destinatario>
    {
        Task<IEnumerable<Destinatario>> ObterTodosAsync();
    }
}
