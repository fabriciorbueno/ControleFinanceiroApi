using System;
using System.Text.Json.Serialization;

namespace ControleFinanceiro.Domain.Dtos.Request
{
    public class PrincipalRequest
    {
        public decimal Valor { get; set; }

        [JsonIgnore]
        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public int IdCategoria { get; set; }

        public int IdTipoPagamento { get; set; }

        public int IdBanco { get; set; }

        public int IdLocal { get; set; }

        public int IdDestinatario { get; set; }

        public int IdSubCategoria { get; set; }

        public int IdPrioridade { get; set; }
    }
}
