using System;

namespace ControleFinanceiro.Domain.Dtos.Response
{
    public class PrincipalResponse
    {
        public int Id { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string TipoPagamento { get; set; }

        public string Banco { get; set; }

        public string Local { get; set; }

        public string Destinatario { get; set; }

        public string SubCategoria { get; set; }

        public string Prioridade { get; set; }
    }
}
