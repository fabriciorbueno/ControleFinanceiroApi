using ControleFinanceiro.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IGastosService
    {
        Task<IEnumerable<GastosResponse>> ObterPorUsuarioAsync(string cpf);
        Task<bool> AdicionarAsync(GastosRequest request);
    }
}
