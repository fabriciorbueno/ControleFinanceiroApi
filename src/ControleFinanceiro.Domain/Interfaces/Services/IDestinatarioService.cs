using ControleFinanceiro.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IDestinatarioService
    {
        Task<IEnumerable<Destinatario>> ObterTodosAsync();
    }
}
