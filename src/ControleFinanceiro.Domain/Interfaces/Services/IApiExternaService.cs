using ControleFinanceiro.Domain.Dtos.Response.ApiExterna;
using ControleFinanceiro.Domain.Dtos.Response.Rest;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IApiExternaService
    {
        Task<BaseResponseRest<CepResponse, string>> BuscarCepAsync(string cep);
    }
}
