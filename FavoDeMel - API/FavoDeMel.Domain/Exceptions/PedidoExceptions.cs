namespace FavoDeMel.Domain.Exceptions
{
    public class PedidoComandaFechadaException : AppException
    {
        public PedidoComandaFechadaException() : base("A Comanda informada esta fechada.") { }
    }

  
}
