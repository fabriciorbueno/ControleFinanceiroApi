using System;

namespace ControleFinanceiro.Domain.Dtos
{
    public class GastosRequest
    {
        public decimal Valor { get; set; }
        public int FormaPagamento { get; set; }
        public int Instituicao { get; set; }
        public int Destinatario { get; set; }
        public int Categoria { get; set; }
        public string? Observacoes { get; set; }
        public string Usuario { get; set; }
    }

    public class GastosResponse
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
        public string FormaPagamento { get; set; }
        public string Instituicao { get; set; }
        public string Destinatario { get; set; }
        public string Categoria { get; set; }
        public string? Observacoes { get; set; }
        public string Usuario { get; set; }

    }
}
