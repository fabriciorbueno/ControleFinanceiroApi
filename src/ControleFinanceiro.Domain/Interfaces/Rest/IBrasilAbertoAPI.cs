using ControleFinanceiro.Domain.Dtos.Response.Rest;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Rest
{
    public interface IBrasilAbertoAPI
    {
        Task<BaseResponseRest<CepRestResponse, CepRestResponseErro>> BuscarCepAsync(string cep);
    }
}
