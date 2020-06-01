namespace FavoDeMel.Domain.Exceptions
{
    public class PedidoNaoEncontradoException : AppException
    {
        public PedidoNaoEncontradoException() : base("O pedido informado não foi encontrado.") { }
    }

    public class PedidoComandaFechadaException : AppException
    {
        public PedidoComandaFechadaException() : base("A Comanda informada esta fechada.") { }
    }

    public class PedidoItemNaoEncontradoException : AppException
    {
        public PedidoItemNaoEncontradoException() : base("O item de pedido informado não foi encontrado.") { }
    }

    public class PedidoItemSituacaoInvalidaAoIniciarProducaoException : AppException
    {
        public PedidoItemSituacaoInvalidaAoIniciarProducaoException() : base("A situação do item é inválida para iniciar a produção.") { }
    }

    public class PedidoItemSituacaoInvalidaAoFinalizarProducaoException : AppException
    {
        public PedidoItemSituacaoInvalidaAoFinalizarProducaoException() : base("A situação do item é inválida para finalizar a produção.") { }
    }

    public class PedidoItemSituacaoInvalidaAoPriorizarProducaoException : AppException
    {
        public PedidoItemSituacaoInvalidaAoPriorizarProducaoException() : base("A situação do item é inválida para priorizar a produção.") { }
    }

    public class PedidoItemSituacaoInvalidaAoCancelarException : AppException
    {
        public PedidoItemSituacaoInvalidaAoCancelarException() : base("A situação do item é inválida para cancelar o mesmo.") { }
    }

    public class PedidoItemSituacaoInvalidaAoEntregarException : AppException
    {
        public PedidoItemSituacaoInvalidaAoEntregarException() : base("A situação do item é inválida para entregar o mesmo.") { }
    }
}
