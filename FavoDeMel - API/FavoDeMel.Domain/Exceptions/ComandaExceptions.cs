namespace FavoDeMel.Domain.Exceptions
{
    public class ComandaNaoEncontradaException : AppException
    {
        public ComandaNaoEncontradaException() : base("A Comanda informada não foi encontrada.") { }
    }

    public class ComandaJaAbertaException : AppException
    {
        public ComandaJaAbertaException() : base("A Comanda informada já esta aberta.") { }
    }

}
