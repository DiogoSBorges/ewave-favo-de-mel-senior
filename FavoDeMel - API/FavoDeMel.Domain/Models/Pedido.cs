using System;

namespace FavoDeMel.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Observacao { get; set; }
        public DateTime Data { get; set; }

        public int ComandaMovimentoId { get; set; }
        public virtual ComandaMovimento Movimento { get; set; }

        public int SituacaoId { get; set; }
        public virtual PedidoSituacao Situacao { get; set; }
    }
}
