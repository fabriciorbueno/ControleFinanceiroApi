using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Domain.Entities
{
    [Table("USUARIO")]
    public class Usuario
    {
        protected Usuario() { }
        public Usuario(
            string nome,
            string cpf
            )
        {
            Nome = nome;
            Cpf = cpf;
        }


        [Key]
        [Column("ID")]
        public int Id { get; private set; }
        [Column("NOME")]
        public string Nome { get; private set; }
        [Column("CPF")]
        public string Cpf { get; private set; }

        internal void AtualizarNome(string nome)
        {
            Nome = nome;
        }

        internal void AtualizarCpf(string cpf)
        {
            Cpf = cpf;
        }
    }
}
