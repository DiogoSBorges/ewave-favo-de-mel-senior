﻿using System.Collections.Generic;

namespace FavoDeMel.Domain.Queries.Views
{
    public class ComandaView
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int SituacaoId { get; set; }
        public string Situacao { get; set; }
    }
}
