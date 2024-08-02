using System.Text.Json.Serialization;

namespace ControleFinanceiro.Domain.Dtos.Response.ApiExterna
{
    public class CepResponse
    {
        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("bairroId")]
        public int BairroId { get; set; }

        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        [JsonPropertyName("cidadeId")]
        public int CidadeId { get; set; }

        [JsonPropertyName("ibgeId")]
        public int IbgeId { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("siglaEstado")]
        public string SiglaEstado { get; set; }

        [JsonPropertyName("numeroCep")]
        public string NumeroCep { get; set; }
    }
}
