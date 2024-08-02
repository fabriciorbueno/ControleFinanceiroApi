namespace ControleFinanceiro.Domain.Dtos.Response
{
    public class ResponseGenerico<S, E> where S : class where E : class
    {
        public S ResponseSucesso { get; set; }
        public E ResponseErro { get; set; }
    }
}
