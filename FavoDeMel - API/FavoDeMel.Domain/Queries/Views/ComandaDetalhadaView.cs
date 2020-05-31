using System.Collections.Generic;

namespace FavoDeMel.Domain.Queries.Views
{
    public class ComandaDetalhadaView
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int SituacaoId { get; set; }
        public string Situacao { get; set; }

        public IEnumerable<PedidoView> Pedidos { get; set; } = new HashSet<PedidoView>();
    }
}
