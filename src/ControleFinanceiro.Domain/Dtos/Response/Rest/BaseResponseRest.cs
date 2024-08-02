namespace ControleFinanceiro.Domain.Dtos.Response.Rest
{
    public class BaseResponseRest<S, E> where S : class where E : class
    {
        public int StatusCode { get; set; }
        public S ResponseSucesso { get; set; }
        public E ResponseErro { get; set; }
    }
}
