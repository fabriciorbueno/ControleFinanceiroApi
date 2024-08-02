using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Domain.Models.Entities
{
    public class Entity : BaseEntity
    {
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
