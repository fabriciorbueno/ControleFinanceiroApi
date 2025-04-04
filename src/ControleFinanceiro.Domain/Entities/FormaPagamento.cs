using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Domain.Entities
{
    [Table("FORMA_PAGAMENTO")]
    public class FormaPagamento
    {
        protected FormaPagamento() { }
        public FormaPagamento(
            string descricao
            )
        {
            Descricao = descricao;
        }


        [Key]
        [Column("ID")]
        public int Id { get; private set; }
        [Column("DESCRICAO")]
        public string Descricao { get; private set; }

        internal void AtualizarDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}
