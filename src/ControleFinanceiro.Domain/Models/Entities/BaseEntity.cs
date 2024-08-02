using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Domain.Models.Entities
{
    public class BaseEntity
    {
        [Column("ID")]
        public int Id { get; set; }
    }
}
