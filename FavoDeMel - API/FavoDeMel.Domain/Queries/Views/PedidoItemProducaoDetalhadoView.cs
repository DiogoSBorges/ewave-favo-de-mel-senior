using System;

namespace FavoDeMel.Domain.Queries.Views
{
    public class PedidoItemProducaoDetalhadoView
    {
        public int PedidoItemId { get; set; }
        public string Observacao { get; set; }
        public int SituacaoId { get; set; }
        public string Situacao { get; set; }
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public DateTime ProducaoDataInicio { get; set; }
        public int ProducaoPrioridadeId { get; set; }
        public string ProducaoPrioridade { get; set; }
        public int ComandaId { get; set; }
        public int ComandaNumero { get; set; }
        public int PedidoId { get; set; }
    }
}
