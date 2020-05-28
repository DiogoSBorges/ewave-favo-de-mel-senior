namespace FavoDeMel.Domain.Exceptions
{
    public class ProdutoNaoEncontradoException : AppException
    {
        public ProdutoNaoEncontradoException() : base("O produto informado não foi encontrado.") { }
    }  
}
