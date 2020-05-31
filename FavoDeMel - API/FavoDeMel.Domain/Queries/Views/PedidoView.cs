using System;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Queries.Views
{
    public class PedidoView
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public int SituacaoId { get; set; }
        public string Situacao { get; set; }

        public IEnumerable<PedidoItemDetalhadoView> Itens { get; set; } = new HashSet<PedidoItemDetalhadoView>();
    }
}
