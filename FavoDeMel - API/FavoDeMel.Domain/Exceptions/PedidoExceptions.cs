﻿namespace FavoDeMel.Domain.Exceptions
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
}
