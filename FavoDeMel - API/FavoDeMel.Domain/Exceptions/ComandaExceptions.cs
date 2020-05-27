namespace FavoDeMel.Domain.Exceptions
{
    public class ComandaNaoEncontradaException : AppException
    {
        public ComandaNaoEncontradaException() : base("A Comanda informada não foi encontrada.") { }
    }
}
