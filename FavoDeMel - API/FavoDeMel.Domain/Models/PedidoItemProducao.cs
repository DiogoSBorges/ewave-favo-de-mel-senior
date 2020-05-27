using System;

namespace FavoDeMel.Domain.Models
{
    public class PedidoItemProducao
    {
        public int Id { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int PedidoItemId { get; set; }
        public virtual PedidoItem PedidoItem { get; set; }

        public int PrioridadeId { get; set; }
        public virtual PedidoItemProducaoPrioridade Prioridade { get; set; }
    }
}
