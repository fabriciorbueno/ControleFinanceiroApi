using Newtonsoft.Json;

namespace ControleFinanceiro.Domain.Dtos.Request
{
    public class RequestBase
    {
        [JsonProperty("Nome")]
        public string Nome { get; set; }
        [JsonProperty("Descricao")]
        public string Descricao { get; set; }
    }
}
