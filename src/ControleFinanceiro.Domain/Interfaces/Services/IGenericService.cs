using ControleFinanceiro.Domain.Dtos.Request;
using ControleFinanceiro.Domain.Dtos.Response;
using ControleFinanceiro.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IGenericService
    {
        Task<IEnumerable<ResponseBase>> BuscarTodosAsync(TabelaEnum tabela);
        Task<bool> InserirAsync(TabelaEnum tabela, RequestBase categoriaRequest);
    }
}
