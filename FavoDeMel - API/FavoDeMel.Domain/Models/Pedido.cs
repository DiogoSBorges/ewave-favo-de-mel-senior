﻿using FavoDeMel.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Models
{
    public class Pedido : IEntity
    {
        public int Id { get; set; }
        public string Observacao { get; set; }
        public DateTime Data { get; set; }

        public int ComandaMovimentoId { get; set; }
        public virtual ComandaMovimento Movimento { get; set; }

        public int SituacaoId { get; set; }
        public virtual PedidoSituacao Situacao { get; set; }

        public virtual ICollection<PedidoItem> Itens { get; set; } = new HashSet<PedidoItem>();
    }
}
