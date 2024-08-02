using ControleFinanceiro.Domain.Dtos.Request;
using ControleFinanceiro.Domain.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repositories
{
    public interface IPrincipalRepository
    {
        Task<bool> InserirAsync(PrincipalRequest request);
        Task<IEnumerable<PrincipalResponse>> BuscarTodosAsync();
    }
}
