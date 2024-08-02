using ControleFinanceiro.Domain.Dtos.Response.Rest;
using ControleFinanceiro.Domain.Interfaces.Rest;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Rest
{
    public class BrasilAbertoAPI : IBrasilAbertoAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrasilAbertoAPI
            (
                IHttpClientFactory httpClientFactory
            )
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<BaseResponseRest<CepRestResponse, CepRestResponseErro>> BuscarCepAsync(string cep)
        {
            //_logger.LogInformation("Operação => {operacao} | Iniciando Execução ao Serviço {servico} | Request: {request}...", nameof(GetCard), "cartoes-cpf", federalId);

            string cepSemFormatacao = Regex.Replace(cep, "[-.,_ ]", "", RegexOptions.None, TimeSpan.FromMilliseconds(100));

            var url = "/api/v1/zipcode/" + cepSemFormatacao;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");

            var response = new BaseResponseRest<CepRestResponse, CepRestResponseErro>();

            using (var client = _httpClientFactory.CreateClient("api-brasil-aberto"))
            {
                var responseApi = new HttpResponseMessage();
                try
                {
                    responseApi = await client.SendAsync(request);
                    var content = await responseApi.Content.ReadAsStringAsync();
                    response.StatusCode = (int)responseApi.StatusCode;
                    if (responseApi.IsSuccessStatusCode)
                    {
                        //_logger.LogInformation("Operação => {operacao} | Fim Execução do Serviço {servico}", nameof(GetCard), "cartoes-cpf");

                        var responseJSON = JsonSerializer.Deserialize<CepRestResponse>(content);

                        response.ResponseSucesso = responseJSON;

                        return response;
                    }
                    else if ((int)responseApi.StatusCode == 404)
                    {
                        //_logger.LogInformation("Operação => {operacao} | Fim Execução do Serviço {servico}", nameof(GetCard), "cartoes-cpf");

                        var responseJSON = JsonSerializer.Deserialize<CepRestResponseErro>(content);

                        response.ResponseErro = responseJSON;

                        return response;
                    }

                    //_logger.LogWarning("Operação => {operacao} | Falha ao {servico}. | StatusCode: {statusCode} | Response: {response}", nameof(GetCard), "cartoes-cpf", response.StatusCode, content);
                    return null;

                }
                catch (Exception ex)
                {
                    //_logger.LogWarning("Operação => {operacao} | Falha ao {servico}. | InnerException: {Message} | Response: {response}", nameof(GetCard), "Cartao/cartoes-cpf", ex.InnerException.Message, ex.Message);
                    return null;
                }
            }
        }
    }
}
