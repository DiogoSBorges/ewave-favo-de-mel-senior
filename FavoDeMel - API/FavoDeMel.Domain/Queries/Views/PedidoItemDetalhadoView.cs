using System;

namespace FavoDeMel.Domain.Queries.Views
{
    public class PedidoItemDetalhadoView
    {
        public int Id { get; set; }
        public string Obervacao { get; set; }
        public int SituacaoId { get; set; }
        public string Situacao { get; set; }
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public DateTime? ProducaoDataInicio { get; set; }
        public int? ProducaoPrioridadeId { get; set; }
        public string ProducaoPrioridade { get; set; }

    }
}
