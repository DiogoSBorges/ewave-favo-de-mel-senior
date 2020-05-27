using FavoDeMel.Infrastructure.Data;

namespace FavoDeMel.Domain.Models
{
    public class PedidoItem : IEntity
    {
        public int Id { get; set; }

        public string Observacao { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        public int SituacaoId { get; set; }
        public virtual PedidoItemSituacao Situacao { get; set; }
    }
}
