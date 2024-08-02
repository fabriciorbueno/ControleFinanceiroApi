using ControleFinanceiro.Domain.Dtos.Request;
using Newtonsoft.Json;

namespace ControleFinanceiro.Domain.Dtos.Response
{
    public class ResponseBase : RequestBase
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
