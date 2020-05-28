using System;
using System.Collections.Generic;
using System.Text;

namespace FavoDeMel.Domain.Dto
{
    public class PedidoDto
    {
        public int ComandaId { get; set; }
        public string Observacao { get; set; }
        public List<PedidoItemDto> Itens { get; set; }
    }
}
