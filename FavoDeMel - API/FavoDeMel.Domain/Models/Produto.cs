namespace FavoDeMel.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public int? TempoPreparo { get; set; }
        public decimal Valor { get; set; }

        public int TipoId { get; set; }
        public virtual ProdutoTipo Tipo { get; set; }
    }
}
