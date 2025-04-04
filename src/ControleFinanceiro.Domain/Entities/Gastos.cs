using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Domain.Entities
{
    [Table("GASTOS")]
    public class Gastos
    {
        protected Gastos() { }
        public Gastos(
            decimal valor,
            int formaPagamento,
            int instituicao,
            int destinatario,
            int categoria,
            string? observacoes,
            int usuario
            )
        {
            Valor = valor;
            DataHora = DateTime.Now;
            FormaPagamento = formaPagamento;
            Instituicao = instituicao;
            Destinatario = destinatario;
            Categoria = categoria;
            Observacoes = observacoes;
            Usuario = usuario;
        }


        [Key]
        [Column("ID")]
        public int Id { get; private set; }
        [Column("VALOR")]
        public decimal Valor { get; private set; }
        [Column("DATA_HORA")]
        public DateTime DataHora { get; private set; }
        [Column("FORMA_PAGAMENTO")]
        public int FormaPagamento { get; private set; }
        [Column("INSTITUICAO")]
        public int Instituicao { get; private set; }
        [Column("DESTINATARIO")]
        public int Destinatario { get; private set; }
        [Column("CATEGORIA")]
        public int Categoria { get; private set; }
        [Column("OBSERVACOES")]
        public string? Observacoes { get; private set; }
        [Column("USUARIO")]
        public int Usuario { get; private set; }

        //internal void AtualizarDescricao(string descricao)
        //{
        //    Descricao = descricao;
        //}

        [ForeignKey(nameof(FormaPagamento))]
        public virtual FormaPagamento FormaPagamentoEntity { get; set; }
        [ForeignKey(nameof(Instituicao))]
        public virtual Instituicao InstituicaoEntity { get; set; }
        [ForeignKey(nameof(Destinatario))]
        public virtual Destinatario DestinatarioEntity { get; set; }
        [ForeignKey(nameof(Categoria))]
        public virtual Categoria CategoriaEntity { get; set; }
        [ForeignKey(nameof(Usuario))]
        public virtual Usuario UsuarioEntity { get; set; }
    }
}
