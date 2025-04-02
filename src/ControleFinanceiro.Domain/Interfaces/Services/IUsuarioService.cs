using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task<UsuarioResponse> AdicionarAsync(UsuarioRequest request);
        Task<Usuario> ObterPorCpfAsync(string cpf);
    }
}
