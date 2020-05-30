using System;
using System.Collections.Generic;
using System.Text;

namespace FavoDeMel.Domain.Queries.Views
{
    public class ProdutoView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoId { get; set; }
        public string Tipo { get; set; }
    }
}
