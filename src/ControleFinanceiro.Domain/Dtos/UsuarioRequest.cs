namespace ControleFinanceiro.Domain.Dtos
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }

    public class UsuarioResponse
    {
        public int Id { get; set; }
    }
}
