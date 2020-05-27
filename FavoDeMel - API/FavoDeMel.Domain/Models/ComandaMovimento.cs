﻿using System;

namespace FavoDeMel.Domain.Models
{
    public class ComandaMovimento
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }

        public int ComandaId { get; set; }
        public virtual Comanda Comanda { get; set; }
    }
}