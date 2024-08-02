using AutoMapper;
using ControleFinanceiro.Domain.Dtos.Response.ApiExterna;
using ControleFinanceiro.Domain.Dtos.Response.Rest;
using ControleFinanceiro.Domain.Interfaces.Rest;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Services
{
    public class ApiExternaService : IApiExternaService
    {
        private readonly IBrasilAbertoAPI _brasilAbertoAPI;
        private readonly IMapper _mapper;

        public ApiExternaService
            (
                IBrasilAbertoAPI brasilAbertoAPI,
                IMapper mapper
            )
        {
            _brasilAbertoAPI = brasilAbertoAPI;
            _mapper = mapper;
        }

        public async Task<BaseResponseRest<CepResponse, string>> BuscarCepAsync(string cep)
        {
            var buscarCep = await _brasilAbertoAPI.BuscarCepAsync(cep);
            if (buscarCep == null)
            {
                return null;
            }

            var response = new BaseResponseRest<CepResponse, string>() { StatusCode = buscarCep.StatusCode };

            if (buscarCep.StatusCode == 200)
            {
                response.ResponseSucesso = _mapper.Map<CepResponse>(buscarCep.ResponseSucesso);

            }
            else if (buscarCep.StatusCode == 404)
            {
                response.ResponseErro = buscarCep.ResponseErro.Result.Message;
            }

            return response;
        }

    }
}
