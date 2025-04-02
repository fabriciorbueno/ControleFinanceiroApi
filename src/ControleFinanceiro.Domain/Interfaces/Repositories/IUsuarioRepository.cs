using ControleFinanceiro.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<Usuario> AdicionarAsync(Usuario usuario);
        Task<Usuario> ObterPorCpfAsync(string cpf);
    }
}
