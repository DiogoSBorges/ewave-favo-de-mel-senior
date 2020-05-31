using System.Collections.Generic;

namespace FavoDeMel.Domain.Queries.Views
{
    public class PedidoItemProducaoView
    {  
        public IEnumerable<PedidoItemProducaoDetalhadoView> ItensAguardandoProducao { get; set; } = new HashSet<PedidoItemProducaoDetalhadoView>();
        public IEnumerable<PedidoItemProducaoDetalhadoView> ItensEmProducao { get; set; } = new HashSet<PedidoItemProducaoDetalhadoView>();
    }
}
