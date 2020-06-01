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

    public class ComandaMovimentoAbertoNaoEncontradoException : AppException
    {
        public ComandaMovimentoAbertoNaoEncontradoException() : base("Não foi encontrado movimento aberto da comanda informada.") { }
    }

    public class ComandaPossuiPedidosNaoEntreguesException : AppException
    {
        public ComandaPossuiPedidosNaoEntreguesException() : base("Comanda possui pedidos os quais ainda não foram entregues.") { }
    }

    public class ComandaMovimentoAbertEncontradoException : AppException
    {
        public ComandaMovimentoAbertEncontradoException() : base("A comanda informada já possui um movimento em aberto.") { }
    }

    public class ComandaSituacaoInvalicaAoFecharException : AppException
    {
        public ComandaSituacaoInvalicaAoFecharException() : base("A situacao da Comanda informada é inválida ao fechar.") { }
    }
}
